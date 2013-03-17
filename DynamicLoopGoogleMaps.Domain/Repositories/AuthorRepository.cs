using DynamicLoopGoogleMaps.Domain.Entities;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public override Author CreateNew()
        {
            return new Author();
        }
    }
}