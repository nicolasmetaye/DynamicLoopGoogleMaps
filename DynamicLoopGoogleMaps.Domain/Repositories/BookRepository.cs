using System;
using System.Collections.Generic;
using System.Linq;
using DynamicLoopGoogleMaps.Common.Helpers;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Book entity)
        {
            _dataContext.Books.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Save(Book entity)
        {
            _dataContext.SaveChanges();
        }

        public void Delete(Book entity)
        {
            entity.BookStores.Clear();
            _dataContext.Books.Remove(entity);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _dataContext.Books.OrderBy(book => book.Title).ToList();
        }

        public Book Get(int id)
        {
            return _dataContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> Search(string search)
        {
            var isbnFiltered = ISBNFilter.Filter(search);
            return _dataContext.Books.Where(book =>
                book.ISBN.Contains(isbnFiltered) || book.Title.Contains(search) || 
                book.Author.FirstName.Contains(search) || book.Author.LastName.Contains(search) ||
                (book.Author.FirstName + " " + book.Author.LastName).Contains(search) ||
                (book.Author.LastName + " " + book.Author.FirstName).Contains(search)).ToList();
        }
    }
}