using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the value of the Description attribute of the given Enum value (falls back to the name of the value).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary>
        /// Gets all items for an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>() where T : struct
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }
    }
}
