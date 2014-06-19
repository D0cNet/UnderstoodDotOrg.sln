using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using Sitecore.Links;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Services.CommunityServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupSummaryList : BaseSublayout//System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            lvGroupCards.ItemDataBound += lvGroupCards_ItemDataBound;
            lvGroupCards.ItemCreated += lvGroupCards_ItemCreated;
            base.OnInit(e);
        }

        void lvGroupCards_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                Literal emptyDataText = (Literal)e.Item.FindControl("litEmptyDataText");
                if (emptyDataText != null)
                {
                    emptyDataText.Text = String.Format(DictionaryConstants.EmptyGroupsListText, UnderstoodDotOrg.Common.Helpers.MembershipHelper.SignInLink());

                }
            }
        }
        void lvGroupCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {


            if (e.Item.DataItem != null)
            {

                bool viewDiscussions = CommunityHelper.IsUserInGroup(UserID, ((GroupCardModel)e.Item.DataItem).GroupID);
                
                ///
                LinkButton joinView = (LinkButton)e.Item.FindControl("btnJoinGroup");
                if (joinView != null)
                {
                   
                    joinView.Text = viewDiscussions ? "View Discussions" : "Join this Group";
                    //If the user is to join group, then use Telligent group id, else use sitecore item id
                    joinView.CommandArgument = viewDiscussions ? ((GroupCardModel)e.Item.DataItem).GroupItemID : ((GroupCardModel)e.Item.DataItem).GroupID;
                    joinView.Attributes.Add("name", viewDiscussions ? "view" : "join");
                }

                HtmlAnchor titleLink =(HtmlAnchor) e.Item.FindControl("titleLink");
                if(titleLink!=null)
                {
                    if (viewDiscussions)
                    {
                        if (e.Item.DataItem is GroupCardModel)
                        {
                            Item grpItem = Sitecore.Context.Database.GetItem(((GroupCardModel)e.Item.DataItem).GroupItemID);
                            var link = LinkManager.GetItemUrl(grpItem);

                            titleLink.HRef = link;
                        }
                    }
                }
            }

             


        }


        ///TODO:Get current user id in session
        public string UserID
        {
            get
            {
                if (CurrentMember != null)
                    return CurrentMember.ScreenName;
                else
                    return String.Empty;
                    //throw new Exception("No current user available");
                //if (Session["username"] == null)
                //{
                //    MembershipManager mem = new MembershipManager();
                //    Member member = mem.GetMember("myName");

                //   // Member member = mem.GetMember(Guid.Empty);
                //    Session["username"] = member.ScreenName;
                //    return member.ScreenName;
                //}
                //else
                //    return Session["username"].ToString();
              // return CurrentMember.ScreenName;
            }
        }

        public List<GroupCardModel> DataSource
        {
            set
            {
                lvGroupCards.DataSource = value;
            }
            get
            {
                return lvGroupCards.DataSource as List<GroupCardModel>;
            }
        }

        public string EmptyText { get; set; }
        public override void DataBind()
        {
            try
            {
                lvGroupCards.DataBind();
            }catch(Exception ex)
            {
                Sitecore.Diagnostics.Error.LogError("Error in DataBind() function of GroupSummaryList.ascx.cs. \nMessage:\n" + ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             
            
            ///TODO:Get current user id in session
            //string UserID = Guid.Empty;

        }

        protected void btnJoinGroup_Click(object sender, EventArgs e)
        {

            LinkButton btn = ((LinkButton)sender);
            if(btn.Attributes["name"].ToString().Equals("view"))
            {
                try
                {
                   
                    //Call view Discussion using sitecore group id
                    Sitecore.Data.ID grpItemID = Sitecore.Data.ID.Parse(btn.CommandArgument);
                    Item grpItem = Sitecore.Context.Database.GetItem(grpItemID);
                    string itemUrl = Sitecore.Links.LinkManager.GetItemUrl(grpItem);
                    Sitecore.Web.WebUtil.Redirect(itemUrl);
                }catch(Exception)
                {
                    
                }
            }
            else
            {
                try
                {
                    //TODO: Get test Cases for this redirect
                    AccessControlService.ProfileRedirect(this,true);
                    //Join the group using telligent group id
                    if (CommunityHelper.JoinGroup(btn.CommandArgument, UserID))
                    {

                    }
                }catch(Exception)
                {
                    
                }

            }
             
            DataBind();

        }
    }
}