using DynamicLoopGoogleMaps.Common.Extensions;
using DynamicLoopGoogleMaps.Domain.Entities;
using DynamicLoopGoogleMaps.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicLoopGoogleMaps.Tests
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void A_Clone_Should_Have_Identital_Values()
        {
            var author = new Author()
                             {
                                 Id = 12,
                                 FirstName = "Bruce",
                                 LastName = "Wayne"
                             };
            var clone = new Author();
            author.Clone(clone);

            Assert.AreEqual(12, clone.Id);
            Assert.AreEqual("Bruce", clone.FirstName);
            Assert.AreEqual("Wayne", clone.LastName);
        }

        [TestMethod]
        public void The_Original_Should_Be_Modified_Without_Changing_The_Clone()
        {
            var author = new Author()
            {
                Id = 12,
                FirstName = "Bruce",
                LastName = "Wayne"
            };
            var clone = new Author();
            author.Clone(clone);

            author.Id = 13;
            author.FirstName = "Dick";
            author.LastName = "Grayson";

            Assert.AreEqual(12, clone.Id);
            Assert.AreEqual("Bruce", clone.FirstName);
            Assert.AreEqual("Wayne", clone.LastName);
        }

        [TestMethod]
        public void The_Clone_Should_Be_Lazy_Loaded()
        {
            var authorRepository = new AuthorRepository();
            var bookRepository = new BookRepository(authorRepository);

            var author = new Author()
            {
                FirstName = "Bruce",
                LastName = "Wayne"
            };
            author = authorRepository.Insert(author);

            var book = bookRepository.CreateNew();
            book.AuthorId = author.Id;
            book.ISBN = "1234567890123";
            book.Title = "Where is the batcave key?";
            book.Author.FirstName = "Dick";
            book.Author.LastName = "Grayson";
            book.Id = 24;

            var clone = bookRepository.CreateNew();
            book.Clone(clone);

            Assert.AreEqual(24, clone.Id);
            Assert.AreEqual("1234567890123", clone.ISBN);
            Assert.AreEqual("Where is the batcave key?", clone.Title);
            Assert.AreEqual(author.Id, clone.AuthorId);
            Assert.AreEqual("Bruce", clone.Author.FirstName);
            Assert.AreEqual("Wayne", clone.Author.LastName);
        }
    }
}
