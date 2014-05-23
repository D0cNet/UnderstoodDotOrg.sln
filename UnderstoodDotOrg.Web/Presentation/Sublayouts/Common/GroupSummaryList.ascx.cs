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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupSummaryList : BaseSublayout//System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            rptGroupCards.ItemDataBound += rptGroupCards_ItemDataBound;

            base.OnInit(e);
        }
        void rptGroupCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            if (e.Item.DataItem != null)
            {
                
                ///
                LinkButton joinView = e.FindControlAs<LinkButton>("btnJoinGroup");//(LinkButton)e.Item.FindControl("btnJoinGroup");
                if (joinView != null)
                {
                    bool viewDiscussions=CommunityHelper.IsUserInGroup(UserID, ((GroupCardModel)e.Item.DataItem).GroupID) ;
                    joinView.Text = viewDiscussions ? "View Discussions" : "Join this Group";
                    //If the user is to join group, then use Telligent group id, else use sitecore item id
                    joinView.CommandArgument = viewDiscussions ? ((GroupCardModel)e.Item.DataItem).GroupItemID : ((GroupCardModel)e.Item.DataItem).GroupID;
                    joinView.Attributes.Add("name", viewDiscussions ? "view" : "join");
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
                rptGroupCards.DataSource = value;
            }
            get
            {
                return rptGroupCards.DataSource as List<GroupCardModel>;
            }
        }

        public string EmptyText { get; set; }
        public override void DataBind()
        {
            rptGroupCards.DataBind();
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