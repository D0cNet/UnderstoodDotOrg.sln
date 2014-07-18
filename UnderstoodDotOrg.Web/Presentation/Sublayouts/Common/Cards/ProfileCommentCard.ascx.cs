using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class ProfileCommentCard : System.Web.UI.UserControl
    {
        public MemberCardModel Member
        {
            get
            {
                return (MemberCardModel)ViewState["_member"];
            }
            set
            {
                ViewState["_member"] = value;
            }
        }
        private string _profileLink;

        private string ProfileLink
        {
            get
            {
                if (string.IsNullOrEmpty(_profileLink))
                {
                    _profileLink = MembershipHelper.GetPublicProfileUrl(this.Member.UserName);
                }
                return _profileLink;
            }
            set { _profileLink = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //imgAvatar.ImageUrl = !string.IsNullOrEmpty(this.Member.AvatarUrl) ? this.Member.AvatarUrl :  ;
            if (this.Member != null)
            {

                imgAvatar.ImageUrl = this.Member.AvatarUrl;
                imgAvatar.AlternateText = this.Member.UserName;

                hypName.NavigateUrl = this.ProfileLink;
                hypName.Text = this.Member.UserName;

                litLocation.Text = this.Member.UserLocation;

                btnConnect.LoadState(this.Member.UserName);

                if (this.Member.Children != null && this.Member.Children.Count > 0)
                {
                    rptChildCard.DataSource = this.Member.Children;
                    rptChildCard.DataBind();
                }

            }

        }

        /// <summary>
        /// binds each child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem is ChildCardModel)
            {
                var child = e.Item.DataItem as ChildCardModel;
                if (child != null)
                {
                    var hypChildGrade = e.Item.FindControl("hypChildGrade") as HyperLink;
                    if (hypChildGrade != null)
                    {
                        hypChildGrade.NavigateUrl = "";
                        hypChildGrade.Text = UnderstoodDotOrg.Common.Helpers.MembershipHelper.AddOrdinalIndicator(Constants.GradesByGuid[child.Grade]);
                    }

                    var litGrade = e.Item.FindControl("litGrade") as Literal;
                    var litGender = e.Item.FindControl("litGender") as Literal;
                    if (litGender != null && litGrade != null)
                    {
                        litGender.Text = child.Gender;
                        litGrade.Text = DictionaryConstants.GradeLabel + "&nbsp;" + Constants.GradesByGuid[child.Grade];
                    }

                    var rptChildIssues = e.Item.FindControl("rptChildIssues") as Repeater;
                    if (rptChildIssues != null)
                    {
                        rptChildIssues.DataSource = child.IssueList;
                        rptChildIssues.DataBind();
                    }

                    //check speckle/test plan for these
                    var hypViewProfile = e.Item.FindControl("hypViewProfile") as HyperLink;
                    var hypSeeActivity = e.Item.FindControl("hypSeeActivity") as HyperLink;
                    if (hypViewProfile != null && hypSeeActivity != null)
                    {
                        hypViewProfile.Text = DictionaryConstants.ViewProfileLabel;
                        hypSeeActivity.Text = DictionaryConstants.SeeActivityLabel;

                        hypSeeActivity.NavigateUrl = this.ProfileLink;
                        hypViewProfile.NavigateUrl = this.ProfileLink;
                    }
                }
            }
        }

        /// <summary>
        /// binds each child issue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptChildIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem is ChildCardModel.Issue)
            {
                var issue = e.Item.DataItem as ChildCardModel.Issue;

                if (issue != null)
                {
                    var litChildIssue = e.Item.FindControl("litChildIssue") as Literal;
                    if (litChildIssue != null)
                    {
                        litChildIssue.Text = issue.IssueName;
                    }
                }
            }
        }
    }
}