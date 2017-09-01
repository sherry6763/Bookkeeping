using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookkeeping.Filters
{
    public sealed class DateRangeAttribute : ValidationAttribute, IClientValidatable
    {
        public DateTime Input { get; set; }

        public DateRangeAttribute()
        {
            this.Input = DateTime.Now;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if(value is DateTime)
            {
                if(this.Input.CompareTo(value) < 0)
                {
                    return false;
                }
            }
            return true;

        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "daterange",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()) 
            };
    
            rule.ValidationParameters["input"] = Input.ToString("yyyy-MM-dd");
            yield return rule;
        }
    }
}