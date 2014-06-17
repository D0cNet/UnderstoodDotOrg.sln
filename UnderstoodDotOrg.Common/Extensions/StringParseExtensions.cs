using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Extensions
{
    public static class StringParseExtensions
    {
        public static int AsInt(this string source)
        {
            var number = 0.0;
            double.TryParse(source, out number);
            return (int)number;
        }

        public static Guid? AsNGuid(this string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                Guid guid;
                if (Guid.TryParse(source, out guid))
                {
                    return guid;
                }
            }
            return null;
        }

        public static DateTime? AsNDateTime(this string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                DateTime dateTime;
                if (DateTime.TryParse(source, out dateTime))
                {
                    return dateTime;
                }
            }
            return null;
        }
    } 
}
