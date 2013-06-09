using System.Collections.Generic;

namespace DynamicLoopGoogleMaps.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Save(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
