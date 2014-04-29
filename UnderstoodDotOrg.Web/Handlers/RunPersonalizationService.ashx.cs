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
        private DateTime? _simulatedDate;

        public void ProcessRequest(HttpContext context)
        {
            if (!HasAccessPrivileges(context))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(String.Format("Access denied - {0}", GetIpAddress()));
                return;
            }



            context.Response.ContentType = "text/html";
            context.Response.Write("Running personalization!!!!");
            context.Response.Write("<br>is this request coming from a local machine: " + context.Request.IsLocal.ToString()); 
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
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                IPAddress address = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

                if (address != null)
                {
                    return address.ToString();
                }
            }

            return String.Empty;
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