﻿using Bookkeeping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bookkeeping.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {

        public DbContext Context { get; set; }

        public EFUnitOfWork()
        {
            Context = new BookkeepingEntities();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }


    }
}