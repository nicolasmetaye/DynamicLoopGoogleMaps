using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using DynamicLoopGoogleMaps.Models.Models;

namespace DynamicLoopGoogleMaps.Controllers
{
    public class MapController : Controller
    {
        private readonly IBookStoreRepository _bookStoreRepository;

        public MapController(IBookStoreRepository bookStoreRepository)
        {
            _bookStoreRepository = bookStoreRepository;
        }

        public ActionResult Index()
        {
            var bookStores = _bookStoreRepository.GetAll();
            var model = Mapper.Map<IEnumerable<BookStore>, MapModel>(bookStores);
            return View(model);
        }
    }

}
