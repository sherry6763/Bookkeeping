﻿using Bookkeeping.Models;
using Bookkeeping.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Bookkeeping.Services
{
    public class TallyService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountBook> _accountBook;

        public TallyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBook = new Repository<AccountBook>(unitOfWork);   
        }

        public IQueryable<TallyRecord> Lookup()
        {
            var source = _accountBook.GetAll();
            var result = source.OrderByDescending(r => r.Dateee).Select(
                r => new TallyRecord
                {
                    Category = (r.Categoryyy + 1 == 1) ? EnumTypes.Income : EnumTypes.Expend,
                    Money = r.Amounttt,
                    Date = r.Dateee,
                    Description = r.Remarkkk
                });

            return result;   
        }
    }
}