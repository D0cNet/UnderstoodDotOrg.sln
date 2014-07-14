using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountProfile : BaseSublayout<ViewProfileItem>
    {
        private Member _profileMember = null;
        private int _selectedTab = 0;

        public string ProfileUrl
        {
            get { return Model.GetUrl(); }
        }
        public string ProfileConnectionsUrl
        {
            get { return GetProfileViewUrl(Constants.QueryStrings.PublicProfile.ViewConnections); }
        }
        public string ProfileCommentsUrl
        {
            get { return GetProfileViewUrl(Constants.QueryStrings.PublicProfile.ViewComments); }
        }

        private string GetProfileViewUrl(string view)
        {
            return String.Format("{0}?{1}={2}", Model.GetUrl(), Constants.QueryStrings.PublicProfile.View, view);
        }

        protected string GetSelectedTabClass(int index)
        {
            return (index == _selectedTab) ? "active" : string.Empty;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            InitView();
        }

        private void InitView()
        {
            string screenName = Sitecore.Web.WebUtil.GetUrlName(0);

            // Verify user exists in telligent
            var telligentUser = TelligentService.GetUser(screenName);
            if (telligentUser == null || telligentUser.Username != screenName)
            {
                // TODO: display error?

                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
                return;
            }

            // Check member account
            MembershipManager mm = new MembershipManager();
            _profileMember = mm.GetMemberByScreenName(screenName);

            if (_profileMember == null)
            {
                // TODO: display error?

                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
                return;
            }

            ucAccountHeader.ProfileMember = ucAccountNonFriendProfile.ProfileMember = _profileMember;

            // Check friendship
            if (IsUserLoggedIn
                && !string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                var status = TelligentService.IsFriend(CurrentMember.ScreenName, screenName);
                if (status == UnderstoodDotOrg.Common.Constants.TelligentFriendStatus.Approved)
                {
                    InitFriendsView();
                    return;
                }
            }

            ucAccountNonFriendProfile.Visible = true;
        }

        private void InitFriendsView()
        {
            ucAccountNonFriendProfile.Visible = false;
            pnlFriends.Visible = true;

            string view = Request.QueryString[Constants.QueryStrings.PublicProfile.View];

            if (!string.IsNullOrEmpty(view))
            {
                switch (view)
                {
                    case Constants.QueryStrings.PublicProfile.ViewConnections:
                        _selectedTab = 1;
                        ucAccountFriendConnections.Visible = true;
                        ucAccountFriendConnections.ProfileMember = _profileMember;
                        break;
                    case Constants.QueryStrings.PublicProfile.ViewComments:
                        _selectedTab = 2;
                        ucAccountFriendComments.Visible = true;
                        ucAccountFriendComments.ProfileMember = _profileMember;
                        break;
                    default:
                        Response.Redirect(ProfileUrl);
                        break;
                }
            }
            else
            {
                ucAccountFriendProfile.Visible = true;
                ucAccountFriendProfile.ProfileMember = _profileMember;
            }

            // Dropdown list
            List<ListItem> tabs = new List<ListItem>();
            tabs.Add(new ListItem(DictionaryConstants.ProfileLabel, string.Empty));
            tabs.Add(new ListItem(DictionaryConstants.ConnectionsLabel, Constants.QueryStrings.PublicProfile.ViewConnections));
            tabs.Add(new ListItem(DictionaryConstants.CommentsLabel, Constants.QueryStrings.PublicProfile.ViewComments));

            ddlMobileTabs.DataSource = tabs;
            ddlMobileTabs.DataTextField = "Text";
            ddlMobileTabs.DataValueField = "Value";
            ddlMobileTabs.DataBind();

            
        }
    }
}