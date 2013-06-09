using System.Collections.Generic;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> Search(string search);
    }
}
