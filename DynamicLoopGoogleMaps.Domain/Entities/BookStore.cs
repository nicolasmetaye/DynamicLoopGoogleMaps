using System.Collections.Generic;
using System.Linq;
using DynamicLoopGoogleMaps.Domain.Repositories;

namespace DynamicLoopGoogleMaps.Domain.Entities
{
    public class BookStore : Entity
    {
        private readonly IBookRepository _bookRepository;

        private List<Book> _books;

        public BookStore(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string Name { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public List<int> BooksIds { get; set; }

        public List<Book> Books
        {
            get
            {
                if (BooksIds == null)
                    _books = new List<Book>();
                else if (_books == null || !_books.Select(book => book.Id).SequenceEqual(BooksIds))
                    _books = _bookRepository.SearchFor(book => BooksIds.Contains(book.Id)).ToList();
                return _books;
            }
        }
    }
}