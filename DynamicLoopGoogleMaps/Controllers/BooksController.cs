using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public ActionResult Add()
        {
            var model = new BookModel
                            {
                                IsEditMode = false
                            };
            model = Mapper.Map(_authorRepository.GetAll(), model);
            return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return RedirectToAction("Index", "Home");

            var model = Mapper.Map<Book, BookModel>(book);
            model = Mapper.Map(_authorRepository.GetAll(), model);
            model.IsEditMode = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<BookModel, Book>(model);
                _bookRepository.Insert(book);
                return RedirectToAction("Index", "Home", new { message = (int)BooksListSuccessMessage.BookAddedSuccesfully });
            }
            return Add();
        }

        [HttpPost]
        public ActionResult Edit(BookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _bookRepository.Get(model.Id);
                if (book == null)
                    return RedirectToAction("Index", "Home");
                book = Mapper.Map(model, book);
                _bookRepository.Save(book);
                return RedirectToAction("Index", "Home", new { message = (int)BooksListSuccessMessage.BookEditedSuccesfully });
            }
            return Edit(model.Id);
        }

        public ActionResult Delete(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return RedirectToAction("Index", "Home");
            _bookRepository.Delete(book);
            return RedirectToAction("Index", "Home", new { message = (int)BooksListSuccessMessage.BookDeletedSuccesfully });
        }
    }
}
