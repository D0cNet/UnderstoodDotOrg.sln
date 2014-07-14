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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountBody : BaseSublayout<ViewProfileItem>
    {
        public Member ProfileMember;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitViews();
            
        }

        private void InitViews()
        {
            if (IsUserLoggedIn)
            {
                pnlMemberOpen.Visible = true;
            }
            else
            {
                pnlAnonymousClosed.Visible = !ProfileMember.allowConnections;
                pnlAnonymousOpen.Visible = ProfileMember.allowConnections;
                pnlMemberOpen.Visible = false;
            }
        }

        private void SetVisibilityBasedOnViewMode()
        {
            //if (viewMode == Constants.VIEW_MODE_VISITOR)
            //{
            //    divNotSignedIn.Visible = true;
            //}
            //if (viewMode == Constants.VIEW_MODE_MEMBER)
            //{
            //    divNotConnected.Visible = true;
            //}
            //if (viewMode == Constants.VIEW_MODE_FRIEND)
            //{
            //    Response.Redirect(string.Format(
            //        MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetPublicAccountProfilePage().GetUrl()
            //        + "?{0}={1}",
            //        Constants.VIEW_MODE,
            //        Constants.VIEW_MODE_FRIEND));
            //}
        }

        protected void rptChildren_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Child dataItem = e.Item.DataItem as Child;
                Repeater rptRow = e.FindControlAs<Repeater>("rptRow");

                //if (TempList.Count < 2)
                //{
                //    TempList.Add(dataItem);
                //    if (TempList.Count == 2)
                //    {
                //        rptRow.DataSource = TempList;
                //        rptRow.DataBind();
                //        TempList.Clear();
                //    }
                //    else if (e.Item.ItemIndex + 1 == ListTotal)
                //    {
                //        rptRow.DataSource = TempList;
                //        rptRow.DataBind();
                //    }
                //}
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