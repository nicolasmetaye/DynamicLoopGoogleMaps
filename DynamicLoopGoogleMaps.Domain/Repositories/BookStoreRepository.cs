using DynamicLoopGoogleMaps.Domain.Entities;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class BookStoreRepository : Repository<BookStore>, IBookStoreRepository
    {
        private readonly IBookRepository _bookRepository;

        public BookStoreRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override BookStore CreateNew()
        {
            return new BookStore(_bookRepository);
        }
    }
}