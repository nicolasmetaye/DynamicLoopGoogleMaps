using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Common.Extensions;
using DynamicLoopGoogleMaps.Common.Helpers;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ActionResult Index(BooksListSuccessMessage message = BooksListSuccessMessage.None)
        {
            var books = _bookRepository.GetAll();
            var model = Mapper.Map<IEnumerable<Book>, BooksListModel>(books);
            if (message != BooksListSuccessMessage.None)
                model.SuccessMessage = message.GetDescriptionAttributeValue();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var isbnFiltered = ISBNFilter.Filter(search);
            var books = _bookRepository.SearchFor(book => book.ISBN.Contains(isbnFiltered) || book.Title.Contains(search)).ToList();
            var model = Mapper.Map<IEnumerable<Book>, BooksListModel>(books);
            return View(model);
        }
    }
}
