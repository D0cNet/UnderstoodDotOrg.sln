using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountHeader : BaseSublayout<PublicAccountItem>
    {
        protected string ScreenName { get; set; }
        protected string CanConnectCss
        {
            get
            {
                return (_profileMember != null && _profileMember.allowConnections)
                    ? "can-connect"
                    : string.Empty;
            }
        }

        private Member _profileMember = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScreenName = Sitecore.Web.WebUtil.GetUrlName(0);

            MembershipManager mm = new MembershipManager();
            
            // TODO: ensure this is valid place to check for screen name
            _profileMember = mm.GetMemberByScreenName(ScreenName);

            if (_profileMember == null)
            {
                // TODO: show error message
                return;
            }
            BindEvents();
            InitView();
        }

        private void BindEvents()
        {
            btnThanks.Click += btnThanks_Click;
            btnThinking.Click += btnThinking_Click;
            rptChildren.ItemDataBound += rptChildren_ItemDataBound;
        }

        private void InitView()
        {
            ToggleDisabledConnectionMessage();
            ToggleConnectButtons();

            PopulateContent();
        }

        private void PopulateContent()
        {
            hlBackToHomepage.NavigateUrl = MainsectionItem.GetHomePageItem().GetUrl();

            // TODO: find member location?

            // Avatar
            var user = TelligentService.GetUser(ScreenName);
            if (user != null)
            {
                imgAvatar.ImageUrl = user.AvatarUrl;
            }
            else
            {
                // TODO: fallback image?
                imgAvatar.Visible = false;
            }

            pnlSupport.Visible = _profileMember.allowConnections;

            // Conditional content for logged in viewers
            if (!IsUserLoggedIn)
            {
                if (_profileMember.allowConnections && _profileMember.Children.Any())
                {
                    rptChildren.DataSource = _profileMember.Children;
                    rptChildren.DataBind();
                }
            }
            else
            {

            }
        }

        private void ToggleConnectButtons()
        {
            if (_profileMember.allowConnections)
            {
                cbAnonConnectWide.LoadState(ScreenName);
                cbConnectNarrow.LoadState(ScreenName);
                cbMemberConnectWide.LoadState(ScreenName);

                bool isConnected = (IsUserLoggedIn && !string.IsNullOrEmpty(CurrentMember.ScreenName))
                    ? CommunityHelper.CheckFriendship(CurrentMember.ScreenName, ScreenName)
                    : false;

                // Connect/friend button shared with anon and members
                pnlConnectNarrow.Visible = !isConnected;

                // Connect buttons unique to anon and members
                pnlMemberConnectWide.Visible = IsUserLoggedIn && !isConnected;
                pnlAnonConnectWide.Visible = !IsUserLoggedIn && !isConnected;

                // Friend buttons
                scFriendNarrow.Visible = scFriendWide.Visible = IsUserLoggedIn && isConnected;
            }
            else
            {
                pnlConnectNarrow.Visible = pnlMemberConnectWide.Visible = pnlAnonConnectWide.Visible
                    = scFriendWide.Visible = scFriendWide.Visible = false;
            }
        }

        private void ToggleDisabledConnectionMessage()
        {
            scNotConnectingNarrow.Visible = scNotConnectingWide.Visible = !_profileMember.allowConnections;
        }

        void btnThanks_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn && !string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                if (Services.CommunityServices.Members.SendThanks(CurrentMember.ScreenName, ScreenName))
                {
                    btnThanks.Text = UnderstoodDotOrg.Common.DictionaryConstants.RequestSent;
                }
            }
        }

        void btnThinking_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn && !string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                if (Services.CommunityServices.Members.SendThinkingOfYou(CurrentMember.ScreenName, ScreenName))
                {
                    btnThinking.Text = UnderstoodDotOrg.Common.DictionaryConstants.RequestSent;
                }
            }
        }

        protected void rptChildren_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Domain.Membership.Child child = (Domain.Membership.Child)e.Item.DataItem;

                Literal litGrade = e.FindControlAs<Literal>("litGrade");
                litGrade.Text = string.Empty;

                Literal litChild = e.FindControlAs<Literal>("litChild");
                string gradePrefix = string.Empty;

                var grade = child.Grades.FirstOrDefault();
                if (grade != null)
                {
                    GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Key);
                    if (gli != null)
                    {
                        string abbreviation = gli.AbbreviatedGrade.Rendered;

                        gradePrefix = abbreviation + ", ";

                        litGrade.Text = abbreviation;
                    }
                }

                // TODO: localize gender
                string gender = MembershipHelper.GetLocalizedGender(child.Gender);

                litChild.Text = String.Concat(gradePrefix, gender);

                // Issues
                Repeater rptIssues = e.FindControlAs<Repeater>("rptIssues");
                if (child.Issues.Any())
                {
                    rptIssues.DataSource = child.Issues;
                    rptIssues.DataBind();
                }
            }
        }

        protected void rptIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Issue issue = (Issue)e.Item.DataItem;

                Literal litIssue = e.FindControlAs<Literal>("litIssue");

                ChildIssueItem cii = Sitecore.Context.Database.GetItem(issue.Key);
                if (cii != null) 
                {
                    litIssue.Text = cii.IssueName.Rendered;
                }
            }
        }
    }
}