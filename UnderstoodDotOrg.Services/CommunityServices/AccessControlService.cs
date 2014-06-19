using Sitecore.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class AccessControlService
    {
        static public string redirectSessionKey
        {
            get { return "URLReferrer"; }
        }

        /// <summary>
        /// Function to save the current page reference in session and redirect to signup/signin page
        /// </summary>
        /// <param name="currentPage"></param>
        static public void ProfileRedirect(UserControl currentPage,bool communityFunction=false)
        {
            ProfileRedirect(currentPage, null, communityFunction);
        }

        static public void ProfileRedirect(UserControl currentPage,string UrlToGoto=null,bool communityFunction=false)
        {
            //Check current user
            if (currentPage is BaseSublayout)
            {
                BaseSublayout page = ((BaseSublayout)currentPage);
                page.Session[redirectSessionKey] = ((BaseSublayout)currentPage).Page.Request.UrlReferrer;


                if (page.CurrentMember == null)
                {

                    page.Page.Response.Redirect(UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignInLink());
                  
                }
                else
                {
                    //Is this context a community related function
                    if (communityFunction)
                    {
                        if (page.CurrentMember.ScreenName == null)
                        {
                            //Redirect to complete profile
                            page.Page.Response.Redirect(page.CurrentMember.GetMemberPublicProfile());
                        }
                        
                    }
                }
                if (!String.IsNullOrEmpty(UrlToGoto))
                {
                    //Reset the session reference
                    page.Page.Session[redirectSessionKey] = null;
                    page.Page.Response.Redirect(UrlToGoto);
                }
            }
        }
        /// <summary>
        /// Function to retrieve referral page from session
        /// </summary>
        /// <param name="contextPage"></param>
        /// <returns></returns>
        static public string GetReferrerUrl(UserControl contextPage)
        {
            string url = null;
            if (contextPage.Page.Session[redirectSessionKey] != null)
            {
                url = contextPage.Page.Session[redirectSessionKey].ToString();

                //Reset the session reference
                contextPage.Page.Session[redirectSessionKey] = null;
            }
            return url;
        }
    }
    
}
