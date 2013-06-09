using System.Collections.Generic;
using System.Linq;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _dataContext;

        public AuthorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Author entity)
        {
            _dataContext.Authors.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Save(Author entity)
        {
            _dataContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            _dataContext.Authors.Remove(entity);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _dataContext.Authors.OrderBy(author => author.FirstName + " " + author.LastName).ToList();
        }

        public Author Get(int id)
        {
            return _dataContext.Authors.FirstOrDefault(author => author.Id == id);
        }
    }
}