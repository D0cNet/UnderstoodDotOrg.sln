using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountFriendProfile : BaseSublayout<ViewProfileItem>
    {
        public Member ProfileMember { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // NOTE: back-end code similar to non friend view, but markup is different enough
            if (ProfileMember == null)
            {
                return;
            }

            BindEvents();
            PopulateContent();
        }

        private void BindEvents()
        {
            lvChildren.ItemDataBound += lvChildren_ItemDataBound;
            rptInterests.ItemDataBound += rptInterests_ItemDataBound;
        }

        void rptInterests_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Interest interest = (Interest)e.Item.DataItem;

                Literal litInterest = e.FindControlAs<Literal>("litInterest");
                ParentInterestItem pii = Sitecore.Context.Database.GetItem(interest.Key);
                if (pii != null)
                {
                    litInterest.Text = pii.InterestName.Raw;
                }
            }
        }

        void lvChildren_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Child child = (Child)e.Item.DataItem;

                Literal litChild = (Literal)e.Item.FindControl("litChild");

                var grade = child.Grades.FirstOrDefault();
                if (grade != null)
                {
                    GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Key);
                    litChild.Text = String.Format("{0}, {1}", gli.Name.Rendered, MembershipHelper.GetLocalizedGender(child.Gender));
                }

                Repeater rptIssues = (Repeater)e.Item.FindControl("rptIssues");
                if (child.Issues.Any())
                {
                    rptIssues.DataSource = child.Issues;
                    rptIssues.DataBind();
                }
            }
        }

        private void PopulateContent()
        {
            if (ProfileMember.Children.Any())
            {
                lvChildren.DataSource = ProfileMember.Children;
                lvChildren.DataBind();
            }

            if (ProfileMember.Interests.Any())
            {
                rptInterests.DataSource = ProfileMember.Interests;
                rptInterests.DataBind();
            }

            List<GroupModel> groups = CommunityHelper.GetUserGroups(ProfileMember.ScreenName);
            if (groups.Any())
            {
                rptGroups.DataSource = groups;
                rptGroups.DataBind();
            }
        }

        protected void rptIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Issue issue = (Issue)e.Item.DataItem;

                Literal litIssue = (Literal)e.FindControlAs<Literal>("litIssue");

                ChildIssueItem cii = Sitecore.Context.Database.GetItem(issue.Key);
                if (cii != null)
                {
                    litIssue.Text = cii.IssueName.Raw;
                }
            }
        }
    }
}