using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Extensions;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly IBookStoreRepository _bookStoreRepository;

        public BookStoresController(IBookStoreRepository bookStoreRepository)
        {
            _bookStoreRepository = bookStoreRepository;
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
            var model = Mapper.Map<BookStore, BookStoreModel>(_bookStoreRepository.CreateNew());
            model.IsEditMode = false;
            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var bookStore = _bookStoreRepository.GetById(id);
            if (bookStore == null)
                return RedirectToAction("Index");

            var model = Mapper.Map<BookStore, BookStoreModel>(bookStore);
            model.IsEditMode = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BookStoreModel model)
        {
            if (ModelState.IsValid)
            {
                var bookStore = _bookStoreRepository.CreateNew();
                bookStore = Mapper.Map(model, bookStore);
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
                var bookStore = _bookStoreRepository.CreateNew();
                bookStore = Mapper.Map(model, bookStore);
                _bookStoreRepository.Save(bookStore);
                return RedirectToAction("Index", new { message = (int)BookStoresListSuccessMessage.BookStoreEditedSuccesfully });
            }
            return Edit(model.Id);
        }

        public ActionResult Delete(int id)
        {
            _bookStoreRepository.Delete(id);
            return RedirectToAction("Index", new { message = (int)BookStoresListSuccessMessage.BookStoreDeletedSuccesfully });
        }
    }
}
