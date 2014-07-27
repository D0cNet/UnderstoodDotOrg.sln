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
    using UnderstoodDotOrg.Services.CommunityServices;
    using UnderstoodDotOrg.Services.Models.Telligent;
    using UnderstoodDotOrg.Services.TelligentService;

    public partial class FeaturedQuestions : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {

            String grades = String.Empty;
            String topics = String.Empty;
            String childIssues = String.Empty;
            String search = String.Empty;
            
            var control = Page.FindControl("main_0$ddlChildIssues") as DropDownList;


            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                childIssues = control.SelectedItem.Value;
            }

            control = Page.FindControl("main_0$ddlGrades") as DropDownList;

            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                grades = control.SelectedItem.Value;
            }

            control = Page.FindControl("main_0$ddlTopics") as DropDownList;

            if (control != null && !String.IsNullOrEmpty(control.SelectedValue))
            {
                topics = control.SelectedItem.Value;
            }

            List<Question> questions = new List<Question>();

            if (!String.IsNullOrEmpty(grades) || !String.IsNullOrEmpty(topics) || !String.IsNullOrEmpty(childIssues))
            {
                questions = Questions.FindQuestions(String.IsNullOrEmpty(childIssues) ? new string[] { } : new string[] { childIssues }, String.IsNullOrEmpty(topics) ? new string[] { } : new string[] { topics }, String.IsNullOrEmpty(grades) ? new string[] { } : new string[] { grades });
            }
            else
            {
                questions = TelligentService.GetQuestionsList(2, 100);
            }

            var filter = Session["Q&A_Filter"] as String;

            if (filter == "Answered")
            {
                questions = questions.FindAll(q => q.CommentCount != "0");
            }
            else if (filter == "Need Answers")
            {
                questions = questions.FindAll(q => q.CommentCount == "0");
            }


            var searchControl = Page.FindControl("main_0$txtSearch") as TextBox;

            if (searchControl != null && !String.IsNullOrEmpty(searchControl.Text))
            {
                search = searchControl.Text;

                questions = questions.FindAll(q => q.Title.ToLower().Contains(search.ToLower()));

            }



            questionsRepeater.DataSource = questions;
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