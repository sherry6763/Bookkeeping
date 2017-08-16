using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Bookkeeping.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork;
        public DbSet<T> Set;

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Set = UnitOfWork.Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Set;
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return Set.FirstOrDefault(filter);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return Set.Where(filter);
        }

        public void Insert(T entity)
        {
            Set.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }

      
    }
}