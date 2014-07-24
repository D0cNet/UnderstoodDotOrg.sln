namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using Sitecore.Web.UI.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG;
    using UnderstoodDotOrg.Services.Models.Telligent;
    using UnderstoodDotOrg.Services.TelligentService;

    public partial class FeaturedQuestions : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            List<Question> dataSource = TelligentService.GetQuestionsList(2, 100);

            var filter = Session["Q&A_Filter"] as String;

            if (filter == "Answered")
            {
                dataSource = dataSource.FindAll(q => q.CommentCount != "0");
            }
            else if (filter == "Need Answers")
            {
                dataSource = dataSource.FindAll(q => q.CommentCount == "0");
            }

            var control = Page.FindControl("main_0$ddlChildIssues") as DropDownList;

            String childIssues = String.Empty;
            String grades = String.Empty;
            String topics = String.Empty;
            String search = String.Empty;

            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                childIssues = control.SelectedItem.Text;
            }

            control = Page.FindControl("main_0$ddlGrades") as DropDownList;

            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                grades = control.SelectedItem.Text;
            }

            control = Page.FindControl("main_0$ddlTopics") as DropDownList;

            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                topics = control.SelectedItem.Text;
            }

            var searchControl = Page.FindControl("main_0$txtSearch") as TextBox;

            if (searchControl != null && !String.IsNullOrEmpty(searchControl.Text))
            {
                search = searchControl.Text;

                dataSource = dataSource.FindAll(q => q.Title.ToLower().Contains(search.ToLower()));

            }



            questionsRepeater.DataSource = dataSource;
            questionsRepeater.DataBind();
        }

        protected void questionsRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (Question)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            hypUserProfileLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(item.Author);
        }
    }
}