using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using Sitecore.Links;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountBody : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userEmail = "";
            if (!Request.QueryString["account"].IsNullOrEmpty())
            {
                userEmail = Request.QueryString["account"];
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }
            var membershipManager = new MembershipManager();
            var thisMember = new Member();
            thisMember = membershipManager.GetMember(userEmail);
            var thisUser = membershipManager.GetUser(thisMember.MemberId, true);
            if (thisMember != null)
            {
                if (IsUserLoggedIn)
                {

                }
                else
                {
                    if (!thisMember.allowConnections)
                    {
                        divNotSignedIn.Visible = true;
                    }
                    else
                    {
                        divPrivateProfile.Visible = true;
                    }
                }
            }
            else
            {

            }
        }
    }
}