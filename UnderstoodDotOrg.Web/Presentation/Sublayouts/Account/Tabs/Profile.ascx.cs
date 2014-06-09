using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs
{
    public partial class Profile : BaseSublayout<PublicAccountProfileItem>
    {
        public List<Child> TempList = new List<Child>();
        public int ListTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindAccountMenu();
            
            string userEmail = "";
            
            if (!Request.QueryString[Constants.ACCOUNT_EMAIL].IsNullOrEmpty())
            {
                userEmail = Request.QueryString[Constants.ACCOUNT_EMAIL];
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }

            var membershipManager = new MembershipManager();
            var thisMember = new Member();
            thisMember = membershipManager.GetMember(userEmail);
            var thisUser = membershipManager.GetUser(thisMember.MemberId, true);

            if ((IsUserLoggedIn) && (CommunityHelper.CheckFriendship(CurrentMember.ScreenName, thisMember.ScreenName)))
            {
                ListTotal = thisMember.Children.Count;
                if (ListTotal != 0)
                {
                    rptChildren.DataSource = thisMember.Children;
                    rptChildren.DataBind();
                }
                if ((thisMember.Interests != null) && (thisMember.Interests.Count != 0))
                {
                    rptInterests.DataSource = thisMember.Interests;
                    rptInterests.DataBind();
                }
                List<GroupModel> groupsList = CommunityHelper.GetUserGroups(thisMember.ScreenName);

                if (groupsList != null)
                {
                    rptGroups.DataSource = groupsList;
                    rptGroups.DataBind();
                }
            }
            else
            {
                Response.Redirect(string.Format(MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetUrl() + "?{0}={1}", Constants.ACCOUNT_EMAIL, Request.QueryString[Constants.ACCOUNT_EMAIL]));
            }
        }

        private void BindAccountMenu()
        {
            var publicAccountPage = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage();
            hypCommentsTab.NavigateUrl = publicAccountPage.GetPublicAccountCommentsPage().GetUrl();
            hypConnectionsTab.NavigateUrl = publicAccountPage.GetPublicAccountConnectionsPage().GetUrl();
            hypProfileTab.NavigateUrl = publicAccountPage.GetPublicAccountProfilePage().GetUrl();
        }

        protected void rptChildren_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Child dataItem = e.Item.DataItem as Child;
                Repeater rptRow = e.FindControlAs<Repeater>("rptRow");

                if (TempList.Count < 2)
                {
                    TempList.Add(dataItem);
                    if (TempList.Count == 2)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                        TempList.Clear();
                    }
                    if (e.Item.ItemIndex + 1 == ListTotal)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                    }
                }
            }
        }

        protected void rptRow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = (Child)e.Item.DataItem;
                Literal litGrade = e.Item.FindControl("litGrade") as Literal;
                Literal litGender = e.Item.FindControl("litGender") as Literal;
                Literal litEvaluationStatus = e.Item.FindControl("litEvaluationStatus") as Literal;

                var grade = item.Grades.FirstOrDefault();
                if (grade != null)
                {
                    litGrade.Text = grade.Value;
                }
                litGender.Text = item.Gender;
                litEvaluationStatus.Text = getItemName(item.EvaluationStatus);
                Repeater rptChildIssues = (Repeater)e.Item.FindControl("rptChildIssues");
                rptChildIssues.DataSource = item.Issues;
                rptChildIssues.DataBind();
            }
        }

        protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (GroupModel)e.Item.DataItem;
            HyperLink hypGroup = (HyperLink)e.Item.FindControl("hypGroup");
            hypGroup.NavigateUrl = item.Url;
            hypGroup.Text = item.Title;
        }
    }
}