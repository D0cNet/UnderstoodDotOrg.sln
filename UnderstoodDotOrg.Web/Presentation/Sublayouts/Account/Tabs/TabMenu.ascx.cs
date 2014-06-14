using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs
{
    public partial class TabMenu : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindAccountMenu();
            var viewMode = Request.QueryString[Constants.VIEW_MODE].IsNullOrEmpty() ? "" : Request.QueryString[Constants.VIEW_MODE];
            string userScreenName = "";

            if (!Request.QueryString[Constants.ACCOUNT_EMAIL].IsNullOrEmpty())
            {
                userScreenName = Request.QueryString[Constants.ACCOUNT_EMAIL];
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }

            var membershipManager = new MembershipManager();
            var thisMember = new Member();
            thisMember = membershipManager.GetMemberByScreenName(userScreenName);
            
            if (IsUserLoggedIn)
            {
                if ((IsUserLoggedIn) && (CommunityHelper.CheckFriendship(CurrentMember.ScreenName, thisMember.ScreenName)) || (((CurrentMember.ScreenName == thisMember.ScreenName) && (viewMode == Constants.VIEW_MODE_FRIEND))))
                {
                    var commentsList = CommunityHelper.ListUserComments(thisMember.ScreenName);

                    if ((commentsList != null) && (commentsList.Count != 0))
                    {
                        litCommentsCount.Text = commentsList != null ? commentsList.Count.ToString() : "0";
                    }
                }
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetPublicAccountProfilePage().InnerItem.TemplateID.ToString())
            {
                profileTab.Attributes["class"] += "active";
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetPublicAccountCommentsPage().InnerItem.TemplateID.ToString())
            {
                commentsTab.Attributes["class"] += "active";
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetPublicAccountConnectionsPage().InnerItem.TemplateID.ToString())
            {
                connectionsTab.Attributes["class"] += "active";
            }
        }

        private void BindAccountMenu()
        {
            var publicAccountPage = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage();
            hypCommentsTab.NavigateUrl = publicAccountPage.GetPublicAccountCommentsPage().GetUrl() + "?" + Request.QueryString;
            hypConnectionsTab.NavigateUrl = publicAccountPage.GetPublicAccountConnectionsPage().GetUrl() + "?" + Request.QueryString;
            hypProfileTab.NavigateUrl = publicAccountPage.GetPublicAccountProfilePage().GetUrl() + "?" + Request.QueryString;
        }
    }
}