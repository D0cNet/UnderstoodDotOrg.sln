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
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                litSearch.Text = UnderstoodDotOrg.Common.DictionaryConstants.SearchButtonText;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{B1EFCAA6-C79A-4908-84D0-B4BDFA5E25A3}")) + "?q=" + query + "&a=" + Constants.TelligentSearchParams.Question);

        }
    }
}