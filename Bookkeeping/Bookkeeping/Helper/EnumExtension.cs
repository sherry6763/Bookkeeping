using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Bookkeeping.Helper
{
    public static class EnumExtension
    {
        public static string DisplayName(this object value)
        {
            var enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            if (enumValue == null) return "";
            var member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
                outString = ((DisplayAttribute)attrs[0]).GetName();
            return outString;
        }

    }
}