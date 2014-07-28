namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using Sitecore.Data.Items;
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

            var filter = Session["Q&A_Filter"] as String;

            if (filter == "Featured")
            {
                questions = GetFeaturedQuestions();
            }
            else if (!String.IsNullOrEmpty(grades) || !String.IsNullOrEmpty(topics) || !String.IsNullOrEmpty(childIssues))
            {
                questions = Questions.FindQuestions(String.IsNullOrEmpty(childIssues) ? new string[] { } : new string[] { childIssues }, String.IsNullOrEmpty(topics) ? new string[] { } : new string[] { topics }, String.IsNullOrEmpty(grades) ? new string[] { } : new string[] { grades });
            }
            else
            {
                questions = TelligentService.GetQuestionsList(2, 100);
            }


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

        private List<Question> GetFeaturedQuestions()
        {
            List<Question> questions = new List<Question>();
            Item[] items = null;

            Sitecore.Data.Fields.MultilistField featuredQuestions = Sitecore.Context.Item.Fields["FeaturedQuestions"];
            if (featuredQuestions != null)
            {
                items = featuredQuestions.GetItems();
                foreach (var item in items)
                {
                    String wikiId = item["WikiId"];
                    String wikiPageId = item["WikiPageId"];
                    String contentId = item["ContentId"];

                    Question question = TelligentService.GetQuestion(wikiId, wikiPageId, contentId);

                    Sitecore.Data.Fields.MultilistField grades = item.Fields["Grade"];

                    if (grades != null)
                    {
                        foreach (Sitecore.Data.ID id in grades.TargetIDs)
                        {
                            Item targetItem = Sitecore.Context.Database.Items[id];
                            question.Grade = targetItem.Name;
                        }

                    }

                    Sitecore.Data.Fields.MultilistField topics = item.Fields["Topic"];

                    if (topics != null)
                    {
                        foreach (Sitecore.Data.ID id in topics.TargetIDs)
                        {
                            Item targetItem = Sitecore.Context.Database.Items[id];
                            question.Group = targetItem.Name;
                        }

                    }

                    Sitecore.Data.Fields.MultilistField issues = item.Fields["Issues"];

                    if (issues != null)
                    {
                        foreach (Sitecore.Data.ID id in issues.TargetIDs)
                        {
                            Item targetItem = Sitecore.Context.Database.Items[id];
                            question.Issues.Add(targetItem.Name);
                        }

                    } 


                    questions.Add(question);
                }
            }

            return questions;
        }

        protected void questionsRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (Question)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            hypUserProfileLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(item.Author);
        }
    }
}