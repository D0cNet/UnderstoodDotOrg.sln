using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountHeader : BaseSublayout<ViewProfileItem>
    {
        protected string ScreenName { get; set; }
        public Member ProfileMember { get; set; }

        protected string CanConnectCss
        {
            get
            {
                return (ProfileMember != null && ProfileMember.allowConnections)
                    ? "can-connect"
                    : string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProfileMember == null)
            {
                return;
            }

            ScreenName = ProfileMember.ScreenName;

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
            litLocation.Text = GeoTargeting.GetStateByZip(ProfileMember.ZipCode);

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

            // Hide support from user viewing their own profile
            if (IsUserLoggedIn
                && !string.IsNullOrEmpty(CurrentMember.ScreenName)
                && CurrentMember.ScreenName == ScreenName)
            {
                pnlSupport.Visible = false;
            }
            else
            {
                pnlSupport.Visible = ProfileMember.allowConnections;
            }

            // Conditional content for logged in viewers
            if (!IsUserLoggedIn)
            {
                if (ProfileMember.allowConnections && ProfileMember.Children.Any())
                {
                    rptChildren.DataSource = ProfileMember.Children;
                    rptChildren.DataBind();
                }
            }
            else
            {

            }
        }

        private void ToggleConnectButtons()
        {
            if (ProfileMember.allowConnections)
            {
                // Controls that require screen name targets
                ucConnectNarrow.TargetScreenName 
                    = ucAnonConnectWide.TargetScreenName 
                    = ucMemberConnectWide.TargetScreenName
                    = ucPrivateMessageNarrow.TargetScreenName
                    = ucPrivateMessageWide.TargetScreenName 
                    = ScreenName;

                bool isConnected = (IsUserLoggedIn && !string.IsNullOrEmpty(CurrentMember.ScreenName))
                    ? CommunityHelper.CheckFriendship(CurrentMember.ScreenName, ScreenName)
                    : false;

                // Connect/friend button shared with anon and members
                pnlConnectNarrow.Visible = true;

                // Connect buttons unique to anon and members
                pnlMemberConnectWide.Visible = IsUserLoggedIn;
                pnlAnonConnectWide.Visible = !IsUserLoggedIn;

                // Friend buttons
                ucPrivateMessageNarrow.Visible = ucPrivateMessageWide.Visible = IsUserLoggedIn && isConnected;
            }
            else
            {
                pnlConnectNarrow.Visible = pnlMemberConnectWide.Visible = pnlAnonConnectWide.Visible
                    = ucPrivateMessageNarrow.Visible = ucPrivateMessageWide.Visible = false;
            }
        }

        private void ToggleDisabledConnectionMessage()
        {
            scNotConnectingNarrow.Visible = scNotConnectingWide.Visible = !ProfileMember.allowConnections;
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
            else
            {
                // TODO: redirect
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
            else
            {
                // TODO: redirect
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