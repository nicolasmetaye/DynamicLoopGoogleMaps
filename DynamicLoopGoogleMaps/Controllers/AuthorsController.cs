using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Extensions;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorsController(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public ActionResult Add()
        {
            return View("Edit", new AuthorModel
                                                  {
                                                      IsEditMode = false
                                                  });
        }

        public ActionResult Edit(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null)
                return RedirectToAction("Index");
            
            var model = Mapper.Map<Author, AuthorModel>(author);
            model.IsEditMode = true;
            return View(model);
        }

        public ActionResult Index(AuthorsListSuccessMessage message = AuthorsListSuccessMessage.None)
        {
            var authors = _authorRepository.GetAll();

            var model = Mapper.Map<IEnumerable<Author>, AuthorsListModel>(authors);
            if (message != AuthorsListSuccessMessage.None)
                model.SuccessMessage = message.GetDescriptionAttributeValue();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                var author = Mapper.Map<AuthorModel, Author>(model);
                _authorRepository.Insert(author);
                return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorAddedSuccesfully });
            }
            model.IsEditMode = false;
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                var author = Mapper.Map<AuthorModel, Author>(model);
                _authorRepository.Save(author);
                return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorEditedSuccesfully });
            }
            model.IsEditMode = true;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (_bookRepository.Any(book => book.AuthorId == id))
                return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorNotDeletedSuccesfully });
            _authorRepository.Delete(id);
            return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorDeletedSuccesfully });
        }
    }
}
