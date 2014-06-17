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

        /// <summary>
        /// Parses this string as an Enum of the specified type
        /// </summary>
        /// <typeparam name="T">An enumerated type</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="defaultValue">The default value if the given value cannot be parsed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">T must be an enumerated type.</exception>
        public static T AsEnum<T>(this string value, bool ignoreCase = true, int defaultValue = 0) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            T parsed;
            if (Enum.TryParse<T>(value, ignoreCase, out parsed))
            {
                return parsed;
            }

            return (T)Enum.ToObject(typeof(T), defaultValue);
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
