using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Groups : System.Web.UI.UserControl
    {
        GroupSummaryList rptGroupCards;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptGroupCards = (GroupSummaryList)Page.LoadControl("~/Presentation/Sublayouts/Common/GroupSummaryList.ascx");
            rptGroupCards.ID = "rptGroupCards";
            groupList.Controls.Add(rptGroupCards);
            if (!IsPostBack)
            {
                ///Search criteria
                ///Checking
                Item currItem = Sitecore.Context.Item;
                Item[] items = null;
                //Child Issue Drop List
                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["ChildIssues"];
                if (childIssues != null)
                {
                    items = childIssues.GetItems();

                    foreach (var item in items)
                    {
                        ddlChildIssues.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlChildIssues.DataBind();
                }
                //Topic Drop List
                Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
                if (topics != null)
                {
                    items = topics.GetItems();

                    foreach (var item in items)
                    {
                        ddlTopics.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlTopics.DataBind();
                }
                //Grades Drop List
                Sitecore.Data.Fields.MultilistField grades = currItem.Fields["Grades"];
                if (grades != null)
                {
                    items = grades.GetItems();

                    foreach (var item in items)
                    {
                        ddlGrades.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlGrades.DataBind();
                }
                
                //States Drop List
                Sitecore.Data.Fields.MultilistField states = currItem.Fields["States"];
                if (states != null)
                {
                    items = states.GetItems();

                    foreach (var item in items)
                    {
                        ddlStates.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlStates.DataBind();
                }

                //Partners Drop List
                Sitecore.Data.Fields.MultilistField partners = currItem.Fields["Partners"];
                if (partners != null)
                {
                    items = partners.GetItems();

                    foreach (var item in items)
                    {
                        ddlPartners.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlPartners.DataBind();
                }
                //Get all groups under parent folder
                List<GroupItem> groups = currItem.Children.Where(x => x.TemplateID.ToString().Equals(Constants.Groups.GroupTemplateID)).Select(x => new GroupItem(x)).ToList<GroupItem>();
                
                //Convert sitecore group items to GroupCardModels
                var grpItems = groups.Select(x => new GroupCardModel(x)).ToList<GroupCardModel>();
                Session["groupItems"] = grpItems;
                rptGroupCards.DataSource = grpItems;
                rptGroupCards.DataBind();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
    
            string issue = ddlChildIssues.SelectedValue.ToString();

            string topic = ddlTopics.SelectedValue.ToString();

            string grade = ddlGrades.SelectedValue.ToString();

            string state = ddlStates.SelectedValue.ToString();

            string partner = ddlPartners.SelectedValue.ToString();

            //Perform search using criteria
            var test = FindGroups( issue, topic, grade,state,partner); ///TODO: To decide on logic to find groups
            rptGroupCards.DataSource = test;
            rptGroupCards.DataBind();
        }

        private List<GroupCardModel> FindGroups(string issue, string topic, string grade, string state, string partner)
        {
            List<GroupCardModel> results = new List<GroupCardModel>();
            if (Session["groupItems"] is List<GroupCardModel>)
            {

                //throw new NotImplementedException();
                ///TODO: Implement search results
                results=(List<GroupCardModel>)Session["groupItems"] ;
            }

            return results;
        }
    }
}