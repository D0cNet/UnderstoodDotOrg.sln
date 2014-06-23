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
namespace UnderstoodDotOrg.Services.AccessControlServices
{
    public static class AccessControlService
    {
        static private string redirectSessionKey
        {
            get { return "URLReferrer"; }
        }


        /// <summary>
        /// Function to save the current page reference in session and redirect to signup/signin page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="permission">Defines user permission for current action to be performed</param>
        static public void ProfileRedirect(this BaseSublayout page, UnderstoodDotOrg.Common.Constants.UserPermission permission = UnderstoodDotOrg.Common.Constants.UserPermission.AnonymousUser)
        {
            ProfileRedirect(page,permission, null);
        }
        /// <summary>
        /// Function to save the current page reference in session and redirect to signup/signin page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="permission">Defines user permission for current action to be performed</param>
        /// <param name="UrlToGoto">Alternative URL to be redirected (Note: Session reference to previous page will be cleared).</param>
        static public void ProfileRedirect(this BaseSublayout page, UnderstoodDotOrg.Common.Constants.UserPermission permission, string UrlToGoto = null)
        {
            
               page.Session[redirectSessionKey] = page.Page.Request.UrlReferrer;


                switch (permission)
                {
                    case UnderstoodDotOrg.Common.Constants.UserPermission.CommunityUser:
                        if (page.CurrentMember == null)
                        {
                            //TODO: redirect to custom signup page to allow both signup/signin and community registration
                            page.Page.Response.Redirect(UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignInLink());

                        }
                        else
                        {
                            
                            if (String.IsNullOrEmpty (page.CurrentMember.ScreenName))
                            {
                                //Redirect to complete profile
                                page.Page.Response.Redirect(page.CurrentMember.GetCommuityRegistrationProfile());
                            }


                        }
                        break;
                    case UnderstoodDotOrg.Common.Constants.UserPermission.RegisteredUser:
                        if (page.CurrentMember == null)
                        {

                            page.Page.Response.Redirect(UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignInLink());

                        }
                        break;
                    case UnderstoodDotOrg.Common.Constants.UserPermission.AnonymousUser:
                        break;
                    case UnderstoodDotOrg.Common.Constants.UserPermission.AdminUser:
                        break;

                    case UnderstoodDotOrg.Common.Constants.UserPermission.Moderator:
                        break;
                    case UnderstoodDotOrg.Common.Constants.UserPermission.Blogger:
                        break;
                    case UnderstoodDotOrg.Common.Constants.UserPermission.Expert:
                        break;
                    
                    default:
                        break;
                }

            
                if (!String.IsNullOrEmpty(UrlToGoto))
                {
                    //Reset the session reference
                    page.Page.Session[redirectSessionKey] = null;
                    page.Page.Response.Redirect(UrlToGoto);
                }
            
        }
        /// <summary>
        /// Function to retrieve referral page from session
        /// </summary>
        /// <param name="contextPage"></param>
        /// <returns></returns>
        static public void ReturnRedirect(this BaseSublayout contextPage)
        {
            string url = null;
            if (contextPage.Page.Session[redirectSessionKey] != null)
            {
                url = contextPage.Page.Session[redirectSessionKey].ToString();
                if (!String.IsNullOrEmpty(url))
                {
                    //url = contextPage.Page.Session[redirectSessionKey].ToString();

                    //Reset the session reference
                    contextPage.Page.Session[redirectSessionKey] = null;
                    contextPage.Page.Response.Redirect(url);
                }
            }
            
        }
    }
    
}
