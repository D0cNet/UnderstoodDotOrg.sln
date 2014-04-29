using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnderstoodDotOrg.Common.Helpers
{
    public class HttpHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Query string key</param>
        /// <param name="defaultValue">Value to return if key does not exist</param>
        /// <returns>Value of query string or default value if the key does not exist</returns>
        public static string GetQueryString(string key, string defaultValue)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.QueryString[key] ?? defaultValue;
            }

            return defaultValue;
        }
    }
}
