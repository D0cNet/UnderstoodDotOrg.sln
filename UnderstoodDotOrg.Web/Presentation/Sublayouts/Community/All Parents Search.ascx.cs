using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{

    
    public partial class All_Parents_Search : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            rptMemberCards.ItemDataBound += rptMemberCards_ItemDataBound;
            
            base.OnInit(e);
        }


       
        void rptMemberCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                if (e.Item.DataItem != null)
                {
                    Label emptyText = (Label)e.Item.FindControl("txtEmpty");
                    if (emptyText != null)
                    {
                        emptyText.Text = "There are no community members within your selections, try to remove a filter option for better results";


                    }
                }
            }
            else if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (e.Item.DataItem != null)
                {
                    Image avaturl = (Image)e.Item.FindControl("UserAvatar");
                    if (avaturl != null)
                    {
                        avaturl.ImageUrl = ((MemberCardModel)e.Item.DataItem).AvatarUrl;


                    }

                    Literal username = (Literal)e.Item.FindControl("UserName");
                    if (username != null)
                    {
                        username.Text = ((MemberCardModel)e.Item.DataItem).UserName;


                    }

                    HtmlControl divImg = (HtmlControl)e.Item.FindControl("lblImg"); 
                    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                    if (userlbl != null)
                    {
                        userlbl.Text = ((MemberCardModel)e.Item.DataItem).UserLabel;
                        divImg.Visible = true;

                    }

                    Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                    if (userloc != null)
                    {
                        userloc.Text = ((MemberCardModel)e.Item.DataItem).UserLocation;


                    }

                   
                    if (e.Item.DataItem is List<ChildCardModel>)
                    { 
                        Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
                        childModel_repeater.DataSource = ((List<ChildCardModel>)e.Item.DataItem);
                        childModel_repeater.DataBind();
                    }
                }

            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item currItem = Sitecore.Context.Item;

                //Child Issue Drop List
                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["Child Issues"];
                Item[] items = childIssues.GetItems();

                lvChildIssues.DataSource = items;
                lvChildIssues.DataBind();

                //Topic Drop List
                Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
                items = topics.GetItems();

                lvTopics.DataSource = items;
                lvTopics.DataBind();

                MembershipManager mem = new MembershipManager();
                var members = mem.GetMembers();

                List<MemberCardModel> memberCardSrc = new List<MemberCardModel>();
                List<ChildCardModel> childCardSrc = new List<ChildCardModel>();
                foreach (var member in members)
                {

                    MemberCardModel mm = new MemberCardModel();
                    mm.AvatarUrl = UnderstoodDotOrg.Common.Constants.Settings.AnonymousAvatar;

                    //TODO: This is to change once we figure out retrieving users by roleid
                    mm.UserLabel = "UserLabel";

                    mm.UserLocation = UnderstoodDotOrg.Common.Constants.Settings.DefaultLocation;
                    mm.UserName = member.ScreenName;

                    ChildCardModel cm = new ChildCardModel();
                    cm.IssueList = new List<ChildCardModel.Issue>();
                    foreach (var child in member.Children)
                    {
                        cm.Gender = child.Gender;
                        cm.Grade = child.Grades.First().Value;


                        foreach (var issue in child.Issues)
                        {
                            ChildCardModel.Issue iss = new ChildCardModel.Issue();
                            iss.IssueName = issue.Value;
                            cm.IssueList.Add(iss);

                            iss = null;
                        }
                        childCardSrc.Add(cm);
                        cm = null;
                        
                    }
                    mm.Children = childCardSrc;

                    memberCardSrc.Add(mm);
                    mm = null;
                }

                rptMemberCards.DataSource = memberCardSrc;
                rptMemberCards.DataBind();

            }
            
        }
    }
}