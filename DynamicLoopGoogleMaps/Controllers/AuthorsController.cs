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
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
            var author = _authorRepository.Get(id);
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
                var author = _authorRepository.Get(model.Id);
                if (author == null)
                    return RedirectToAction("Index");
                author = Mapper.Map(model, author);
                _authorRepository.Save(author);
                return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorEditedSuccesfully });
            }
            model.IsEditMode = true;
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var author = _authorRepository.Get(id);
            if (author == null)
                return RedirectToAction("Index");
            if (author.Books.Any())
                return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorNotDeletedSuccesfully });
            _authorRepository.Delete(author);
            return RedirectToAction("Index", new { message = (int)AuthorsListSuccessMessage.AuthorDeletedSuccesfully });
        }
    }
}
