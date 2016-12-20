using System;
using System.Linq;

namespace laba2.Services
{
    interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        void SaveChanged();
    }
}
