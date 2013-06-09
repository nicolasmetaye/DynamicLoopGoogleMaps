using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Domain;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class MapController : Controller
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IBookRepository _bookRepository;

        public MapController(IBookStoreRepository bookStoreRepository, IBookRepository bookRepository)
        {
            _bookStoreRepository = bookStoreRepository;
            _bookRepository = bookRepository;
        }

        public ActionResult Index()
        {
            var bookStores = _bookStoreRepository.GetAll();
            var model = Mapper.Map<IEnumerable<BookStore>, MapModel>(bookStores);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var books = _bookRepository.Search(search);
            var model = Mapper.Map<IEnumerable<BookStore>, MapModel>(books.SelectMany(book => book.BookStores).Distinct());
            return View(model);
        }
    }

}
