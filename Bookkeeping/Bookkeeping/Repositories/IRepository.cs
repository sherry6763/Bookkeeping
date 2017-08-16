using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Linq.Expressions;

namespace Bookkeeping.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        T GetSingle(Expression<Func<T, bool>> filter);

        void Insert(T entity);

        void Delete(T entity);

        void Save();
    }
}
