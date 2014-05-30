using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for FacebookLogin
    /// </summary>
    public class FacebookLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session != null)
            {
                var accessToken = context.Request["accessToken"];
                context.Session[Common.Constants.currentUserFacebookAccessToken] = accessToken != null ? accessToken : null;
            }

            var returnUrl = context.Request.UrlReferrer;

            context.Response.Redirect(returnUrl.ToString(), false);
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