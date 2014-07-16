using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class MemberProfileCard : System.Web.UI.UserControl
    {
        public string ColumnCss { get; set; }
        public User ProfileUser { get; set; }

        protected string ProfileUrl { get; set; }
        protected string ProfileActivityUrl { get; set; }

        private Member _member;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProfileUser != null)
            {
                // TODO: since we manage telligent users, we should be storing data on our member to avoid
                // unneeded api lookups
                var mm = new MembershipManager();
                _member = mm.GetMemberByScreenName(ProfileUser.Username);

                if (_member == null)
                {
                    return;
                }

                ProfileUrl = MembershipHelper.GetPublicProfileUrl(ProfileUser.Username);
                ProfileActivityUrl = MembershipHelper.GetPublicProfileActivityUrl(ProfileUser.Username);
            
                BindEvents();
                PopulateContent();
            }
        }

        private void BindEvents()
        {
            rptChildren.ItemDataBound += rptChildren_ItemDataBound;
        }

        private void PopulateContent()
        {
            litLocation.Text = Services.CommunityServices.GeoTargeting.GetStateByZip(_member.ZipCode);

            // TODO: store avatar at member level
            imgAvatar.ImageUrl = ProfileUser.AvatarUrl;

            // Children
            if (_member.Children.Any())
            {
                rptChildren.DataSource = _member.Children;
                rptChildren.DataBind();
            }
        }

        void rptChildren_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Child child = (Child)e.Item.DataItem;

                Literal litGrade = (Literal)e.Item.FindControl("litGrade");
                Literal litChildInfo = (Literal)e.Item.FindControl("litChildInfo");

                string childPrefix = string.Empty;

                var grade = child.Grades.FirstOrDefault();
                if (grade != null)
                {
                    GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Key);
                    if (gli != null)
                    {
                        litGrade.Text = gli.AbbreviatedGrade.Raw;
                        childPrefix = String.Concat(gli.Name.Raw, ", ");
                    }
                }

                litChildInfo.Text = String.Concat(childPrefix, MembershipHelper.GetLocalizedGender(child.Gender));

                Repeater rptIssues = e.FindControlAs<Repeater>("rptIssues");
                if (child.Issues.Any())
                {
                    var issues = child.Issues.Select(x => (ChildIssueItem)Sitecore.Context.Database.GetItem(x.Key))
                                    .Where(x => x != null);

                    rptIssues.DataSource = issues;
                    rptIssues.DataBind();
                }
            }
        }
    }
}