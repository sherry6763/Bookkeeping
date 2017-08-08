using Bookkeeping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookkeeping.Controllers
{
    public class TallyController : Controller
    {

        public ActionResult Index()
        {
            return View(new TallyRecord());
        }


        [ChildActionOnly]
        public ActionResult Detail()
        {

            var model = new List<TallyRecord>();
            var count = 10;
            Random rnd = new Random();

            for (var i =1; i <= count; i ++)
            {
                model.Add(new TallyRecord()
                {
                    No = i,
                    Category = (i % 3 == 0) ? EnumTypes.支出 : EnumTypes.收入,
                    Date = DateTime.Now.Date.AddDays(count - i),
                    Money = rnd.Next(100, 2000)
                });
            }
            return View(model);
        }



    }
}