using System.Collections.Generic;
using System.Linq;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly DataContext _dataContext;

        public BookStoreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(BookStore entity)
        {
            _dataContext.BookStores.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Save(BookStore entity)
        {
            _dataContext.SaveChanges();
        }

        public void Delete(BookStore entity)
        {
            _dataContext.BookStores.Remove(entity);
            _dataContext.SaveChanges();
        }

        public IEnumerable<BookStore> GetAll()
        {
            return _dataContext.BookStores.OrderBy(store => store.Name).ToList();
        }

        public BookStore Get(int id)
        {
            return _dataContext.BookStores.FirstOrDefault(bookStore => bookStore.Id == id);
        }
    }
}