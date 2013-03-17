using DynamicLoopGoogleMaps.Domain.Repositories;

namespace DynamicLoopGoogleMaps.DataGenerator
{
    public class Generator
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public Generator(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public void Generate()
        {
            GenerateCormacBooks();
            GenerateHarlanBooks();
            GenerateJohnBooks();
            GenerateGeorgesBooks();
            GenerateJRRBooks();
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
            theFellowship.ISBN = "978-0007203543";
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
    }
}
