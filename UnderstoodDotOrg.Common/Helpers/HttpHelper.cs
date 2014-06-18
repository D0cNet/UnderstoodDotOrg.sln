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
        public static string GetQueryString(string key, string defaultValue = "")
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.QueryString[key] ?? defaultValue;
            }

            return defaultValue;
        }

        public static string GetIpAddress()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]
                ?? HttpContext.Current.Request.UserHostAddress
                ?? String.Empty;
        }

        /// <summary>
        /// Returns a formatted URL with query string variables appended
        /// </summary>
        /// <param name="baseUrl">Base URL excluding any query string variables</param>
        /// <param name="queryParams">Dictionary with key, value paris where key is the query string variable name</param>
        /// <returns>Formatted URL string</returns>
        public static string AssembleUrl(string baseUrl, Dictionary<string, string> queryParams)
        {
            var pairs = (from qp in queryParams
                         where !String.IsNullOrEmpty(qp.Value)
                         select String.Format("{0}={1}", qp.Key, Uri.EscapeDataString(qp.Value))).ToArray();

            string queryString = (pairs.Any()) ?
                String.Concat("?", String.Join("&", pairs)) :
                String.Empty;

            // Handle parentheses
            queryString = queryString.Replace("(", "%28").Replace(")", "%29");

            return String.Concat(baseUrl, queryString);
        }
    }
}
