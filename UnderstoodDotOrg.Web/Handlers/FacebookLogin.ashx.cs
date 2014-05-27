using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for FacebookLogin
    /// </summary>
    public class FacebookLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var accessToken = context.Request["accessToken"];
            context.Session["AccessToken"] = accessToken;

            context.Response.Redirect(context.Request.UrlReferrer.ToString());
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