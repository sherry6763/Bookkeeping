using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookkeeping.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }

        void Save();
    }
}