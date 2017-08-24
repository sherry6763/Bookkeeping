using Bookkeeping.Models;
using Bookkeeping.Repositories;
using Bookkeeping.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookkeeping.Controllers
{
    public class TallyController : Controller
    {
        private readonly TallyService _tallyService;
        private int pageSize = 6;

        public TallyController()
        {
            var unitOfWork = new EFUnitOfWork();
            _tallyService = new TallyService(unitOfWork);

        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Detail(int? page)
        {
            int currentPage = page ?? 1;
            var model = _tallyService.Lookup().ToPagedList(currentPage, pageSize);
       
            return PartialView("Detail", model);
        }



    }
}