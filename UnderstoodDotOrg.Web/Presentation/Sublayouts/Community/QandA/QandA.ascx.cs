namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A
{
    using Sitecore.Data.Items;
    using Sitecore.Links;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Helpers;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

    public partial class QandA : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            //Item parentItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.ParentsGroupRecommended));
            //string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
            litSearch.Text = UnderstoodDotOrg.Common.DictionaryConstants.SearchButtonText;
            litFilterBy.Text = UnderstoodDotOrg.Common.DictionaryConstants.FilterByLabel;
            litFeatured.Text = UnderstoodDotOrg.Common.DictionaryConstants.Featured;
            litNeedAnswers.Text = UnderstoodDotOrg.Common.DictionaryConstants.NeedAnswersLabel;
            litAnswered.Text = UnderstoodDotOrg.Common.DictionaryConstants.AnsweredLabel;
            litRecommended.Text = UnderstoodDotOrg.Common.DictionaryConstants.RecommendedLabel;

            SetSelectMenu();

            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Q&A_Filter"] = null;

                Item currItem = Sitecore.Context.Item;

                Item[] items = null;

                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["ChildIssues"];
                if (childIssues != null)
                {
                    items = childIssues.GetItems();
                    //ddlChildIssues.Items.Add(new ListItem() {  Text=DictionaryConstants.ChildIssuesLabel, Value=""});

                    foreach (var item in items)
                    {

                        ddlChildIssues.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString().Equals("{9E988E8F-4036-49E7-B9ED-687C99A669F9}") ? string.Empty : item.ID.ToString() });
                    }

                    ddlChildIssues.DataBind();

                    ddlChildIssues.Items.Insert(0, new ListItem() { Text = DictionaryConstants.ChildIssuesLabel, Value = string.Empty });
                }


                //Grades Drop List
                Sitecore.Data.Fields.MultilistField grades = currItem.Fields["Grades"];
                if (grades != null)
                {
                    items = grades.GetItems();
                    //ddlGrades.Items.Add(new ListItem() { Text = DictionaryConstants.GradesLabel, Value = "" });
                    foreach (var item in items)
                    {
                        ddlGrades.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString().Equals("{7DD838FD-8BD3-4861-8E1E-540E6ED9BBE9}") ? string.Empty : item.ID.ToString() });
                    }

                    ddlGrades.DataBind();

                    ddlGrades.Items.Insert(0, new ListItem() { Text = DictionaryConstants.GradeLabel, Value = string.Empty });

                }


                //Topic Drop List
                Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
                if (topics != null)
                {
                    items = topics.GetItems();
                    //ddlTopics.Items.Add(new ListItem() { Text = DictionaryConstants.TopicsLabel, Value = "" });
                    foreach (var item in items)
                    {
                        ddlTopics.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlTopics.DataBind();

                    ddlTopics.Items.Insert(0, new ListItem() { Text = DictionaryConstants.TopicLabel, Value = string.Empty });

                }


            }
            else
            {
                string target = Request.Params.Get("__EVENTTARGET") ?? String.Empty;

                // Check controls
                if (!string.IsNullOrEmpty(target))
                {

                    if (target.Contains("Featured"))
                    {
                        Session["Q&A_Filter"] = "Featured";

                    }
                    else if (target.Contains("Recommended"))
                    {
                        Session["Q&A_Filter"] = "Recommended";
            
                    }
                    else if (target.Contains("NeedAnswers"))
                    {
                        Session["Q&A_Filter"] = "Need Answers";

                    }
                    else if (target.Contains("Answered"))
                    {
                        Session["Q&A_Filter"] = "Answered";
                    }
                    else if (target == "main_0$questiontoolbar_0$lnkAnswer")
                    {
                        Session["Q&A_Filter"] = "Need Answers";
                    }
                    else if (target == "main_0$questiontoolbar_0$lnkDiscover")
                    {
                        Session["Q&A_Filter"] = "Answered";
                    }
                }
            }

            SetSelectMenu();

        }

        /*
        protected void lnkFeatured_Click(object sender, EventArgs e)
        {
            Session["Q&A_Filter"] = "Featured";

            SetSelectMenu();
        }

        protected void lnkRecommended_Click(object sender, EventArgs e)
        {
            Session["Q&A_Filter"] = "Recommended";

            SetSelectMenu();
        }

        protected void lnkNeedAnswers_Click(object sender, EventArgs e)
        {            
            Session["Q&A_Filter"] = "Need Answers";

            SetSelectMenu();
        }

        protected void lnkAnswered_Click(object sender, EventArgs e)
        {
            Session["Q&A_Filter"] = "Answered";

            SetSelectMenu();
        }
        */

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string[] issue = String.IsNullOrEmpty(ddlChildIssues.SelectedValue) ? new String[0] : new String[] { ddlChildIssues.SelectedValue };

            string[] topic = String.IsNullOrEmpty(ddlTopics.SelectedValue.ToString()) ? new String[0] : new String[] { ddlTopics.SelectedValue.ToString() };

            string[] grade = String.IsNullOrEmpty(ddlGrades.SelectedValue.ToString()) ? new String[0] : new String[] { ddlGrades.SelectedValue.ToString() }; 

            string query = TextHelper.RemoveHTML(txtSearch.Text);
            //Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{B1EFCAA6-C79A-4908-84D0-B4BDFA5E25A3}")) + "?q=" + query + "&a=" + Constants.TelligentSearchParams.Question);

        }

        private void SetSelectMenu()
        {
            var filter = Session["Q&A_Filter"] as String;

            if (String.IsNullOrEmpty(filter))
            {
                litSelectedMenu.Text = UnderstoodDotOrg.Common.DictionaryConstants.FilterByLabel;
            }
            else
            {
                litSelectedMenu.Text = filter;
            }
        }

    }
}