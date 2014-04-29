using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using UnderstoodDotOrg.Common;
using System.Net.Sockets;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for RunPersonalizationService
    /// </summary>
    public class RunPersonalizationService : IHttpHandler
    {
        private Guid? _childId;
        private Guid? _memberId;
        private DateTime _simulatedDate;

        public void ProcessRequest(HttpContext context)
        {
            if (!HasAccessPrivileges(context))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(String.Format("Access denied - {0}", GetIpAddress()));
                return;
            }

            InitSearchParams();

            context.Response.ContentType = "text/html";
            context.Response.Write("Running personalization!!!!");
            context.Response.Write("<br>is this request coming from a local machine: " + context.Request.IsLocal.ToString()); 
        }

        private void InitSearchParams()
        {
            if (!DateTime.TryParse(Common.Helpers.HttpHelper.GetQueryString(Constants.HANDLER_TIMELY_DATE_QUERY_STRING), out _simulatedDate))
            {
                _simulatedDate = DateTime.UtcNow;
            }
            

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Restricts service to local server or allowed ips
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Boolean if a this service is allowed to run</returns>
        private bool HasAccessPrivileges(HttpContext context)
        {
            return context.Request.IsLocal || HasAllowedIp();
        }

        private string GetIpAddress()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]
                ?? HttpContext.Current.Request.UserHostAddress
                ?? String.Empty;
        }

        private bool HasAllowedIp()
        {
            string address = GetIpAddress();
            if (!String.IsNullOrEmpty(address))
            {
                List<string> allowedIps = Sitecore.Configuration.Settings.GetSetting(Constants.Settings.PersonalizationHandlerAllowedIps).Split(',').ToList<string>();

                return allowedIps.Contains(address);
            }

            return false;
        }
    }
}