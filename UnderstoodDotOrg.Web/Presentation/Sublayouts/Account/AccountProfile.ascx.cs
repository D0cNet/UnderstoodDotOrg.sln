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

        public string ProfileUrl { get; set; }
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
            return String.Format("{0}?{1}={2}", ProfileUrl, Constants.QueryStrings.PublicProfile.View, view);
        }

        protected string GetSelectedTabClass(int index)
        {
            return (index == _selectedTab) ? "active" : string.Empty;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            GetMember();
            InitView();
        }

        private void BindEvents()
        {
            ddlMobileTabs.SelectedIndexChanged += ddlMobileTabs_SelectedIndexChanged;
        }

        private void GetMember()
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
        }

        private void InitView()
        {
            ProfileUrl = MembershipHelper.GetPublicProfileUrl(_profileMember);

            // Determine if member is viewing own profile and impersonating a view
            string viewMode = Request.QueryString[Constants.VIEW_MODE] ?? string.Empty;
            bool isImpersonatingVisitor = false;
            bool isImpersonatingMember = false;
            if (IsUserLoggedIn && CurrentMember.ScreenName == _profileMember.ScreenName)
            {
                isImpersonatingMember = viewMode == Constants.VIEW_MODE_MEMBER;
                isImpersonatingVisitor = viewMode == Constants.VIEW_MODE_VISITOR;
            }

            ucAccountHeader.ProfileMember = ucAccountNonFriendProfile.ProfileMember = _profileMember;

            ucAccountHeader.IsImpersonatingVistor = isImpersonatingVisitor;

            // Check friendship
            if (IsUserLoggedIn
                && !string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                // Short circuit friends display to visitor/member view
                if (isImpersonatingVisitor || isImpersonatingMember)
                {
                    ucAccountNonFriendProfile.IsImpersonatingMember = isImpersonatingMember;
                    ucAccountNonFriendProfile.IsImpersonatingVistor = isImpersonatingVisitor;
                    ucAccountNonFriendProfile.Visible = true;
                    return;
                }

                // Display friends view
                if (CurrentMember.ScreenName == _profileMember.ScreenName
                    || TelligentService.IsApprovedFriend(CurrentMember.ScreenName, _profileMember.ScreenName))
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

            litCommentCount.Text = TelligentService.GetTotalUserComments(_profileMember.ScreenName).ToString();

            if (!IsPostBack)
            {
                // Dropdown list
                List<ListItem> tabs = new List<ListItem>();
                tabs.Add(new ListItem(DictionaryConstants.ProfileLabel, string.Empty));
                tabs.Add(new ListItem(DictionaryConstants.ConnectionsLabel, Constants.QueryStrings.PublicProfile.ViewConnections));
                tabs.Add(new ListItem(DictionaryConstants.CommentsLabel, Constants.QueryStrings.PublicProfile.ViewComments));

                tabs[_selectedTab].Selected = true;

                ddlMobileTabs.DataSource = tabs;
                ddlMobileTabs.DataTextField = "Text";
                ddlMobileTabs.DataValueField = "Value";
                ddlMobileTabs.DataBind();
            }
        }

        void ddlMobileTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlMobileTabs.SelectedValue;
            if (!String.IsNullOrEmpty(selectedValue))
            {
                Response.Redirect(GetProfileViewUrl(selectedValue));
            }
            else
            {
                Response.Redirect(ProfileUrl);
            }
        }

        
    }
}