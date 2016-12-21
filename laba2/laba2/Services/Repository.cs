using System;
using System.Data.Entity;
using System.Linq;
using laba2.DB;
using laba2.Model;

namespace laba2.Services
{
    class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BankContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
            this._context = new BankContext();
            this._dbSet = _context.Set<T>();
        }

        public int Add(T entity)
        {
            var addedEntity = _dbSet.Add(entity);
            return addedEntity.Id;
        }

        public bool Delete(int id)
        {
            try
            {
                var deletedEntity = this.GetById(id);
                _dbSet.Remove(deletedEntity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            return this.Delete(entity.Id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity.Id;
        }

        public void SaveChanged()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void AddOrUpdate(T entity)
        {
            if(!_dbSet.Any(x => x.Id == entity.Id))
            {
                this.Add(entity);
            }
            else
            {
                this.Update(entity);
            }
        }
    }
}