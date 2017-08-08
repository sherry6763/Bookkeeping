using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookkeeping.Models
{
    public class TallyRecord
    {
        [Display(Name = "#")]
        public int No { get; set; }

        [Display(Name = "類別")]
        public EnumTypes Category { get; set; }

        [Display(Name = "金額")]
        public int? Money { get; set; }

        [Display(Name = "日期")]
        public DateTime? Date { get; set; }

        [Display(Name = "備註")]
        public string Description { get; set; }
    }

    public enum EnumTypes
    {
        收入 = 1,
        支出 = 2
    }
}