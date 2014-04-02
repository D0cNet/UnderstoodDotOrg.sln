using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for RunPersonalizationService
    /// </summary>
    public class RunPersonalizationService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Running personalization!!!!");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}