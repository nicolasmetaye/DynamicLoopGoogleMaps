using System;
using System.Collections.Generic;
using System.Linq;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;

namespace DynamicLoopGoogleMaps.DataGenerator
{
    public class Generator
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookStoreRepository _bookStoreRepository;

        public Generator(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookStoreRepository bookStoreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookStoreRepository = bookStoreRepository;
        }

        public void Generate()
        {
            GenerateCormacBooks();
            GenerateHarlanBooks();
            GenerateJohnBooks();
            GenerateGeorgesBooks();
            GenerateJRRBooks();
            GenerateBookStores();
        }

        private void GenerateCormacBooks()
        {
            var cormac = _authorRepository.CreateNew();
            cormac.FirstName = "Cormac";
            cormac.LastName = "McCarthy";
            cormac = _authorRepository.Insert(cormac);

            var theRoad = _bookRepository.CreateNew();
            theRoad.AuthorId = cormac.Id;
            theRoad.Title = "The Road";
            theRoad.ISBN = "9780330468464";
            _bookRepository.Insert(theRoad);

            var bloodMeridian = _bookRepository.CreateNew();
            bloodMeridian.AuthorId = cormac.Id;
            bloodMeridian.Title = "Blood Meridian";
            bloodMeridian.ISBN = "9780330510940";
            _bookRepository.Insert(bloodMeridian);

            var noCountry = _bookRepository.CreateNew();
            noCountry.AuthorId = cormac.Id;
            noCountry.Title = "No Country For Old Men";
            noCountry.ISBN = "9780330454537";
            _bookRepository.Insert(noCountry);

            var outerDark = _bookRepository.CreateNew();
            outerDark.AuthorId = cormac.Id;
            outerDark.Title = "Outer Dark";
            outerDark.ISBN = "9780330511223";
            _bookRepository.Insert(outerDark);
        }

        private void GenerateHarlanBooks()
        {
            var harlan = _authorRepository.CreateNew();
            harlan.FirstName = "Harlan";
            harlan.LastName = "Coben";
            harlan = _authorRepository.Insert(harlan);

            var tellNoOne = _bookRepository.CreateNew();
            tellNoOne.AuthorId = harlan.Id;
            tellNoOne.Title = "Tell No One";
            tellNoOne.ISBN = "9781409117025";
            _bookRepository.Insert(tellNoOne);

            var stayClose = _bookRepository.CreateNew();
            stayClose.AuthorId = harlan.Id;
            stayClose.Title = "Stay Close";
            stayClose.ISBN = "9781409117223";
            _bookRepository.Insert(stayClose);

            var caught = _bookRepository.CreateNew();
            caught.AuthorId = harlan.Id;
            caught.Title = "Caught";
            caught.ISBN = "9781409117209";
            _bookRepository.Insert(caught);

            var gone = _bookRepository.CreateNew();
            gone.AuthorId = harlan.Id;
            gone.Title = "Gone For Good";
            gone.ISBN = "9781409117087";
            _bookRepository.Insert(gone);
        }

        private void GenerateJohnBooks()
        {
            var john = _authorRepository.CreateNew();
            john.FirstName = "John";
            john.LastName = "Grisham";
            john = _authorRepository.Insert(john);

            var theConfession = _bookRepository.CreateNew();
            theConfession.AuthorId = john.Id;
            theConfession.Title = "The confession";
            theConfession.ISBN = "9780099545798";
            _bookRepository.Insert(theConfession);

            var theLitigators = _bookRepository.CreateNew();
            theLitigators.AuthorId = john.Id;
            theLitigators.Title = "The Litigators";
            theLitigators.ISBN = "9781444729726";
            _bookRepository.Insert(theLitigators);

            var thePartners = _bookRepository.CreateNew();
            thePartners.AuthorId = john.Id;
            thePartners.Title = "The Partners";
            thePartners.ISBN = "9780099537151";
            _bookRepository.Insert(thePartners);

            var theRainmakers = _bookRepository.CreateNew();
            theRainmakers.AuthorId = john.Id;
            theRainmakers.Title = "The Rainmakers";
            theRainmakers.ISBN = "9780099537175";
            _bookRepository.Insert(theRainmakers);
        }

        private void GenerateGeorgesBooks()
        {
            var georges = _authorRepository.CreateNew();
            georges.FirstName = "George R. R.";
            georges.LastName = "Martin";
            georges = _authorRepository.Insert(georges);

            var aSong = _bookRepository.CreateNew();
            aSong.AuthorId = georges.Id;
            aSong.Title = "A Song Of Ice And Fire";
            aSong.ISBN = "9780007428540";
            _bookRepository.Insert(aSong);

            var aClash = _bookRepository.CreateNew();
            aClash.AuthorId = georges.Id;
            aClash.Title = "A Clash Of Kings";
            aClash.ISBN = "9780007447831";
            _bookRepository.Insert(aClash);

            var aStorm = _bookRepository.CreateNew();
            aStorm.AuthorId = georges.Id;
            aStorm.Title = "A Storm Of Swords";
            aStorm.ISBN = "9780007447855";
            _bookRepository.Insert(aStorm);

            var dance = _bookRepository.CreateNew();
            dance.AuthorId = georges.Id;
            dance.Title = "Dance With Dragons";
            dance.ISBN = "9780007466061";
            _bookRepository.Insert(dance);
        }

        private void GenerateJRRBooks()
        {
            var jrr = _authorRepository.CreateNew();
            jrr.FirstName = "J. R. R.";
            jrr.LastName = "Tolkien";
            jrr = _authorRepository.Insert(jrr);

            var theHobbit = _bookRepository.CreateNew();
            theHobbit.AuthorId = jrr.Id;
            theHobbit.Title = "The Hobbit";
            theHobbit.ISBN = "9780007487288";
            _bookRepository.Insert(theHobbit);

            var theFellowship = _bookRepository.CreateNew();
            theFellowship.AuthorId = jrr.Id;
            theFellowship.Title = "The Fellowship Of The Ring";
            theFellowship.ISBN = "9780007203543";
            _bookRepository.Insert(theFellowship);

            var theTwoTowers = _bookRepository.CreateNew();
            theTwoTowers.AuthorId = jrr.Id;
            theTwoTowers.Title = "The Two Towers";
            theTwoTowers.ISBN = "9780007203550";
            _bookRepository.Insert(theTwoTowers);

            var theReturn = _bookRepository.CreateNew();
            theReturn.AuthorId = jrr.Id;
            theReturn.Title = "The Return Of The King";
            theReturn.ISBN = "9780007203567";
            _bookRepository.Insert(theReturn);
        }

        private void GenerateBookStores()
        {
            var bookStores = new List<BookStore>();

            var daunt = _bookStoreRepository.CreateNew();
            daunt.Name = "Daunt Books";
            daunt.City = "London";
            daunt.Longitude = -0.151985M;
            daunt.Latitude = 51.52048M;
            bookStores.Add(daunt);

            var persephone = _bookStoreRepository.CreateNew();
            persephone.Name = "Persephone Books";
            persephone.City = "London";
            persephone.Longitude = -0.11879M;
            persephone.Latitude = 51.522109M;
            bookStores.Add(persephone);

            var londonReview = _bookStoreRepository.CreateNew();
            londonReview.Name = "London Review Books";
            londonReview.City = "London";
            londonReview.Longitude = -0.12409M;
            londonReview.Latitude = 51.518164M;
            bookStores.Add(londonReview);

            var foyles = _bookStoreRepository.CreateNew();
            foyles.Name = "Foyles";
            foyles.City = "London";
            foyles.Longitude = -0.129755M;
            foyles.Latitude = 51.515353M;
            bookStores.Add(foyles);

            var waterstones = _bookStoreRepository.CreateNew();
            waterstones.Name = "Waterstones Piccadilly";
            waterstones.City = "London";
            waterstones.Longitude = -0.135065M;
            waterstones.Latitude = 51.509237M;
            bookStores.Add(waterstones);

            var tabernacle = _bookStoreRepository.CreateNew();
            tabernacle.Name = "Tabernacle Bookshop";
            tabernacle.City = "London";
            tabernacle.Longitude = -0.097911M;
            tabernacle.Latitude = 51.493275M;
            bookStores.Add(tabernacle);

            var whsmith = _bookStoreRepository.CreateNew();
            whsmith.Name = "WHSmith";
            whsmith.City = "London";
            whsmith.Longitude = -0.088942M;
            whsmith.Latitude = 51.512522M;
            bookStores.Add(whsmith);

            var bookForCooks = _bookStoreRepository.CreateNew();
            bookForCooks.Name = "Books for Cooks";
            bookForCooks.City = "London";
            bookForCooks.Longitude = -0.202861M;
            bookForCooks.Latitude = 51.515339M;
            bookStores.Add(bookForCooks);

            var bookart = _bookStoreRepository.CreateNew();
            bookart.Name = "Bookart";
            bookart.City = "London";
            bookart.Longitude = -0.083234M;
            bookart.Latitude = 51.526375M;
            bookStores.Add(bookart);

            var stanfords = _bookStoreRepository.CreateNew();
            stanfords.Name = "Stanfords";
            stanfords.City = "London";
            stanfords.Longitude = -0.125216M;
            stanfords.Latitude = 51.511634M;
            bookStores.Add(stanfords);

            var penguin = _bookStoreRepository.CreateNew();
            penguin.Name = "Penguin Books";
            penguin.City = "London";
            penguin.Longitude = -0.121574M;
            penguin.Latitude = 51.510183M;
            bookStores.Add(penguin);

            var john = _bookStoreRepository.CreateNew();
            john.Name = "John Sandoe";
            john.City = "London";
            john.Longitude = -0.160766M;
            john.Latitude = 51.49103M;
            bookStores.Add(john);

            var allBooks = _bookRepository.GetAll().ToList();

            var random = new Random();
            foreach (var bookStore in bookStores)
            {
                bookStore.BooksIds = allBooks
                    .OrderBy(x => random.Next())
                    .Take(random.Next(5, 15))
                    .Select(book => book.Id)
                    .ToList();
                _bookStoreRepository.Insert(bookStore);
            }
        }
    }
}
