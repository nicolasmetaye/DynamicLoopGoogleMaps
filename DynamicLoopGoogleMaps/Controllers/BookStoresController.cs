using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Extensions;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IBookRepository _bookRepository;

        public BookStoresController(IBookStoreRepository bookStoreRepository, IBookRepository bookRepository)
        {
            _bookStoreRepository = bookStoreRepository;
            _bookRepository = bookRepository;
        }

        public ActionResult Index(BookStoresListSuccessMessage message = BookStoresListSuccessMessage.None)
        {
            var bookStores = _bookStoreRepository.GetAll();

            var model = Mapper.Map<IEnumerable<BookStore>, BookStoresListModel>(bookStores);
            if (message != BookStoresListSuccessMessage.None)
                model.SuccessMessage = message.GetDescriptionAttributeValue();

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new BookStoreModel
                            {
                                IsEditMode = false
                            };
            model = Mapper.Map(_bookRepository.GetAll(), model);
            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var bookStore = _bookStoreRepository.Get(id);
            if (bookStore == null)
                return RedirectToAction("Index");

            var model = Mapper.Map<BookStore, BookStoreModel>(bookStore);
            model = Mapper.Map(_bookRepository.GetAll(), model);
            model.IsEditMode = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BookStoreModel model)
        {
            if (ModelState.IsValid)
            {
                var bookStore = Mapper.Map<BookStoreModel, BookStore>(model);
                if (model.BooksIds != null && model.BooksIds.Any())
                    bookStore.Books = _bookRepository.GetAll().Where(book => model.BooksIds.Contains(book.Id)).ToList();
                _bookStoreRepository.Insert(bookStore);
                return RedirectToAction("Index", new { message = (int)BookStoresListSuccessMessage.BookStoreAddedSuccesfully });
            }
            return Add();
        }

        [HttpPost]
        public ActionResult Edit(BookStoreModel model)
        {
            if (ModelState.IsValid)
            {
                var bookStore = _bookStoreRepository.Get(model.Id);
                if (bookStore == null)
                    return RedirectToAction("Index");
                bookStore = Mapper.Map(model, bookStore);
                bookStore.Books.Clear();
                if (model.BooksIds != null && model.BooksIds.Any())
                    bookStore.Books = _bookRepository.GetAll().Where(book => model.BooksIds.Contains(book.Id)).ToList();
                _bookStoreRepository.Save(bookStore);
                return RedirectToAction("Index", new { message = (int)BookStoresListSuccessMessage.BookStoreEditedSuccesfully });
            }
            return Edit(model.Id);
        }

        public ActionResult Delete(int id)
        {
            var bookStore = _bookStoreRepository.Get(id);
            if (bookStore == null)
                return RedirectToAction("Index");
            _bookStoreRepository.Delete(bookStore);
            return RedirectToAction("Index", new { message = (int)BookStoresListSuccessMessage.BookStoreDeletedSuccesfully });
        }
    }
}
