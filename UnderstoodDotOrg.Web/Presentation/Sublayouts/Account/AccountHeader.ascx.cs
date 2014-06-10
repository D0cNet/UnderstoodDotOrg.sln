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
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountHeader : BaseSublayout<PublicAccountItem>
    {
        protected string screenName = "";
        private string viewMode = "";
        private MembershipManager membershipManager = new MembershipManager();
        private Member thisMember = new Member();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            viewMode = Request.QueryString[Constants.VIEW_MODE].IsNullOrEmpty() ? "" : Request.QueryString[Constants.VIEW_MODE];

            string userEmail = "";
            if (!Request.QueryString["account"].IsNullOrEmpty())
            {
                userEmail = Request.QueryString["account"];
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }

            thisMember = membershipManager.GetMember(userEmail);
            var thisUser = membershipManager.GetUser(thisMember.MemberId, true);

            if (!thisMember.ScreenName.IsNullOrEmpty())
            {
                screenName = thisMember.ScreenName;
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }
            if (thisMember.ScreenName != null)
            {
                if (IsUserLoggedIn)
                {
                    if ((CurrentMember.ScreenName == thisMember.ScreenName))
                    {
                        SetVisibilityBasedOnViewMode();
                    }
                }
                else
                {
                    if (!thisMember.allowConnections)
                    {
                        pnlNotSignedInView.Visible = true;
                        rptChildren.DataSource = thisMember.Children;
                        rptChildren.DataBind();
                    }
                    else
                    {
                        pnlPrivateUser.Visible = true;
                    }
                }
            }
            else
            {
                pnlPrivateUser.Visible = true;
            }
        }

        private void SetVisibilityBasedOnViewMode()
        {
            if (viewMode == Constants.VIEW_MODE_VISITOR)
            {
                pnlNotSignedInView.Visible = true;
            }
            if (viewMode == Constants.VIEW_MODE_MEMBER)
            {
                if (CurrentMember.allowConnections)
                {
                    pnlSignedIn.Visible = true;
                    divNotConnected.Visible = true;
                }
                else
                {
                    pnlPrivateUser.Visible = true;
                }
            }
            if (viewMode == Constants.VIEW_MODE_FRIEND)
            {
                pnlSignedIn.Visible = true;
                divConnected.Visible = true;
            }
        }

        protected void rptChildren_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (Child)e.Item.DataItem;
            Literal litGrade = e.Item.FindControl("litGrade") as Literal;
            Literal litGrade2 = e.Item.FindControl("litGrade2") as Literal;
            Literal litGender = e.Item.FindControl("litGender") as Literal;
            
            var grade = item.Grades.FirstOrDefault();
            if (grade != null)
            {
                litGrade.Text = AddOrdinal(Int32.Parse(Regex.Match(grade.Value, @"\d+").Value));
                litGrade2.Text = grade.Value;
            }
            litGender.Text = item.Gender;
            Repeater rptChildIssues = (Repeater)e.Item.FindControl("rptChildIssues");
            rptChildIssues.DataSource = item.Issues;
            rptChildIssues.DataBind();
        }

        public string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            if (CurrentMember.ScreenName != thisMember.ScreenName)
            {
                CommunityHelper.CreateFriendship(CurrentMember.ScreenName, thisMember.ScreenName);
            }
        }
    }
}