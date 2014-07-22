using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Groups : BaseSublayout//System.Web.UI.UserControl
    {
        //GroupSummaryList rptGroupCards;

        

        protected override void OnInit(EventArgs e)
        {
            Item parentItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.ParentsGroupRecommended));
            string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
            ref_recommended_group.HRef = itemHref;
            litGroupsPrivacyLabel.Text = DictionaryConstants.GroupsPrivacyLabel;
            litParentGroupsLabel.Text = DictionaryConstants.ParentGroupsLabel;
            litShowGroupsMatchLabel.Text = DictionaryConstants.ShowMatchingGroupsLabel;
            litShowMore.Text = DictionaryConstants.ShowMoreLabel;
			btnSearch.Text = UnderstoodDotOrg.Common.DictionaryConstants.SearchButtonText;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

           // this.ProfileRedirect(Constants.UserPermission.CommunityUser);
           
            if (!IsPostBack)
            {
            
                // groupList.DataBind();



                ///Search criteria
                ///Checking
                Item currItem = Sitecore.Context.Item;

                Item[] items = null;
                //Child Issue Drop List
                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["ChildIssues"];
                if (childIssues != null)
                {
                    items = childIssues.GetItems();
                    //ddlChildIssues.Items.Add(new ListItem() {  Text=DictionaryConstants.ChildIssuesLabel, Value=""});

                    foreach (var item in items)
                    {

                        ddlChildIssues.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString().Equals("{9E988E8F-4036-49E7-B9ED-687C99A669F9}") ? string.Empty: item.ID.ToString() });
                    }

                    ddlChildIssues.DataBind();

                    ddlChildIssues.Items.Insert(0, new ListItem() { Text = DictionaryConstants.ChildIssuesLabel, Value = string.Empty });
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
                
                //States Drop List
                Sitecore.Data.Fields.MultilistField states = currItem.Fields["States"];
                if (states != null)
                {
                    items = states.GetItems();

                    //ddlStates.Items.Add(new ListItem() { Text = DictionaryConstants.StatesLabel, Value = "" });
                    foreach (var item in items)
                    {
                        ddlStates.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlStates.DataBind();

                    ddlStates.Items.Insert(0, new ListItem() { Text = DictionaryConstants.StateLabel, Value = string.Empty });

                }

                //Partners Drop List
                Sitecore.Data.Fields.MultilistField partners = currItem.Fields["Partners"];
                if (partners != null)
                {
                    items = partners.GetItems();
                    //ddlPartners.Items.Add(new ListItem() { Text = DictionaryConstants.PartnersLabel, Value = "" });
                    foreach (var item in items)
                    {
                        ddlPartners.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlPartners.DataBind();

                    ddlPartners.Items.Insert(0, new ListItem() { Text = DictionaryConstants.PartnerLabel, Value = string.Empty });

                }
                //Get all groups under parent folder
                //List<GroupItem> groups = currItem.Children.Where(x => x.TemplateID.ToString().Equals(Constants.Groups.GroupTemplateID)).Select(x => new GroupItem(x)).ToList<GroupItem>();
                
                //Convert sitecore group items to GroupCardModels

                var grpItems = Groups.FindGroups();

                Session["groupItems"] = grpItems;

                rptGroupCards.DataSource = grpItems.Take(10).ToList();
                rptGroupCards.DataBind();
            }
            

          
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string[] issue = String.IsNullOrEmpty(ddlChildIssues.SelectedValue)? new String[0]: new String[]{ddlChildIssues.SelectedValue} ;

            string[] topic = String.IsNullOrEmpty(ddlTopics.SelectedValue.ToString()) ? new String[0] : new String[] { ddlTopics.SelectedValue.ToString() };

            string[] grade = String.IsNullOrEmpty(ddlGrades.SelectedValue.ToString()) ? new String[0] : new String[] { ddlGrades.SelectedValue.ToString() }; 

            string[] state = String.IsNullOrEmpty(ddlStates.SelectedValue.ToString()) ? new String[0] : new String[] { ddlStates.SelectedValue.ToString() }; 

            string[] partner = String.IsNullOrEmpty(ddlPartners.SelectedValue.ToString()) ? new String[0] : new String[] { ddlPartners.SelectedValue.ToString() }; 

            

            //Perform search using criteria
            var groupResult = Groups.FindGroups( issue, topic, grade,state,partner);

            
            
            rptGroupCards.DataSource = groupResult.Take(10).ToList();
            rptGroupCards.DataBind();

        }

        protected void ShowMore(object sender, EventArgs e)
        {
            if (Session["groupItems"] is List<GroupCardModel>)
            {
                var grpItems =(List<GroupCardModel>) Session["groupItems"];
                rptGroupCards.DataSource = grpItems;
                rptGroupCards.DataBind();
            }
        }
    }
}