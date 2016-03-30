using System.Collections.Generic;

namespace UsersGroups.Web.Services
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(int id);
        T Remove(int id);
        void Update(T item);
    }
}