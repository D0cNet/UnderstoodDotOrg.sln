using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Framework.UI
{
    public static class BaseSublayoutExtension
    {
        /// <summary>
        /// Function to save the current page reference in session and redirect to signup/signin page
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="permission">Defines user permission for current action to be performed</param>
        /// <param name="UrlToGoto">Alternative URL to be redirected (Note: Session reference to previous page will be cleared).</param>
        static public void ProfileRedirect(this BaseSublayout page, UnderstoodDotOrg.Common.Constants.UserPermission permission, string UrlToGoto = null, bool preserveURL = false)
        {
            // only set redirect if we don't already have a place to go back to - this will allow us to "chain" permission checks without losing original return URL
            if (page.Session[Constants.SessionPreviousUrl] == null && !preserveURL)
            {
                page.Session[Constants.SessionPreviousUrl] = page.Page.Request.RawUrl;    
            }

            switch (permission)
            {
                case Constants.UserPermission.CommunityUser:
                    //is user logged in?
                    if (page.CurrentMember == null)
                    {
                        //not logged in, please log in
                        page.Page.Response.Redirect(SignInPageItem.GetSignInPage().GetUrl());
                    }
                    else
                    {
                        //is user registered for community?
                        if (String.IsNullOrEmpty(page.CurrentMember.ScreenName))
                        {
                            //redirect to community sign-up
                            redirect(page, RegisterCommunityProfileItem.GetRegisterCommunityProfilePage().GetUrl());
                        }
                    }
                    break;
                case Constants.UserPermission.RegisteredUser:
                    //is user logged in?
                    if (page.CurrentMember == null)
                    {
                        //not logged in, please log in
                        redirect(page, SignInPageItem.GetSignInPage().GetUrl());
                    }
                    break;
                case Constants.UserPermission.AnonymousUser:
                    break;
                case Constants.UserPermission.AdminUser:
                    break;
                case Constants.UserPermission.Moderator:
                    break;
                case Constants.UserPermission.Blogger:
                    break;
                case Constants.UserPermission.Expert:
                    break;
                case Constants.UserPermission.InternationalUser:
                    //redirect to international user page
                    if (page.isInternationalUser == Constants.GeoIPLookup.InternationalStatus.UnknownInternationalUser)
                    {
                        redirect(page, InternationalUserPageItem.GetInternationalUserPage().GetUrl());
                    }                        
                    break;
                case Constants.UserPermission.AgreedToTerms:
                    //redirect to T&C if they have not agreed yet
                    if (page.CurrentMember != null && !page.CurrentMember.AgreedToSignUpTerms)
                    {
                        redirect(page, TermsandConditionsItem.GetTermsAndConditionsPage().GetUrl());
                    }
                    break;
                case Constants.UserPermission.CanPersonalize:
                    if (page.CurrentMember == null)
                    {
                        redirect(page, SignInPageItem.GetSignInPage().GetUrl());
                    }
                    else
                    {
                        if (page.CurrentMember.Children == null || page.CurrentMember.Children.Count == 0)
                        {
                            redirect(page, RegisterChildInformationItem.GetRegisterChildInfoPage().GetUrl());
                        }
                    }

                    break;
                default:
                    break;
            }

            if (!preserveURL)
            {
                //everything's fine, redirect to page if it was passed
                page.Page.Session[Constants.SessionPreviousUrl] = null;
            }

            if (!String.IsNullOrEmpty(UrlToGoto))
            {
                redirect(page, UrlToGoto);
            }
        }

        /// <summary>
        /// Internal method for redirecting, no need to keep writing this out all the time
        /// </summary>
        /// <param name="page"></param>
        /// <param name="Url"></param>
        static private void redirect(BaseSublayout page, string Url)
        {
            page.Page.Response.Redirect(Url, true);
        }

        /// <summary>
        /// Function to retrieve referral page from session
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        static public void ReturnRedirect(this BaseSublayout page)
        {
            string url = null;
            if (page.Page.Session[Constants.SessionPreviousUrl] != null)
            {
                url = page.Page.Session[Constants.SessionPreviousUrl].ToString();
                if (!String.IsNullOrEmpty(url) && url != page.Page.Request.RawUrl)
                {
                    //url = contextPage.Page.Session[redirectSessionKey].ToString();

                    //Reset the session reference
                    page.Page.Session[Constants.SessionPreviousUrl] = null;
                    redirect(page, url);
                }
            }
        }
    }
}
