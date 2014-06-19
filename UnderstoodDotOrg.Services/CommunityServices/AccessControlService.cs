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
        static public void ProfileRedirect(UserControl currentPage)
        {
            //Check current user
            if (currentPage is BaseSublayout)
            {
                ((BaseSublayout)currentPage).Session["URLReferrer"] = ((BaseSublayout)currentPage).Page.Request.UrlReferrer;


                if (((BaseSublayout)currentPage).CurrentMember == null)
                {

                    ((BaseSublayout)currentPage).Page.Response.Redirect(UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignInLink());
                }
                else
                {
                    if (((BaseSublayout)currentPage).CurrentMember.ScreenName == null)
                    {
                        ((BaseSublayout)currentPage).Page.Response.Redirect(UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignUpLink());
                    }
                    else
                    {
                      //  ((BaseSublayout)currentPage).Page.Response.Redirect(((BaseSublayout)currentPage).CurrentMember.GetMemberPublicProfile());
                    }
                }
                //return ((BaseSublayout)currentPage).Page.Request.UrlReferrer.ToString();
            }
        }
        
    }
}
