using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Applicanty.API.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescriptionAttributeValue(Type type, string enumValue)
        {
            
            MemberInfo[] memInfo = type.GetMember(enumValue);

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumValue;
        }
    }
}
