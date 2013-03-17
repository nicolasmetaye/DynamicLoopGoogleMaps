using DynamicLoopGoogleMaps.Domain.Entities;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        IAuthorRepository _authorRepository;

        public BookRepository(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public override Book CreateNew()
        {
            return new Book(_authorRepository);
        }
    }
}