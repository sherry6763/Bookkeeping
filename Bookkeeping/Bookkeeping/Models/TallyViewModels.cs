using Bookkeeping.Filters;
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
        [Required]
        public EnumTypes Category { get; set; }

        [Display(Name = "金額")]
        [Required, Range(0, int.MaxValue, ErrorMessage = "只能輸入正整數")]
        public int Money { get; set; }

        [Display(Name = "日期")]
        [Required]
        [DataType(DataType.Date, ErrorMessage ="請輸入有效日期")]
        [DateRange(ErrorMessage ="日期不可大於今天")]        
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [Required, StringLength(100, ErrorMessage = "最多輸入{1}個字元")]
        public string Description { get; set; }
    }

    public enum EnumTypes
    {
        [Display(Name = "收入")]
        Income = 0,
        [Display(Name = "支出")]
        Expend = 1
    }
}