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
//using UnderstoodDotOrg.Services.AccessControlServices;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation;

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

        //we don't have any groups so you should log in?
        void lvGroupCards_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.EmptyItem)
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
                if (e.Item.DataItem is GroupCardModel)
                {
                    var item = (GroupCardModel)e.Item.DataItem;

                    bool viewDiscussions = TelligentService.IsUserInGroup(UserID, item.GroupID);

                    LinkButton joinView = (LinkButton)e.Item.FindControl("btnJoinGroup");
                    if (joinView != null)
                    {

                        //joinView.Text = viewDiscussions ? "View Discussions" : "Join this Group";
                        joinView.Text = viewDiscussions ? DictionaryConstants.ViewDiscussionsLabel : DictionaryConstants.JoinThisGroupLabel;
                        //If the user is to join group, then use Telligent group id, else use sitecore item id
                        joinView.CommandArgument = viewDiscussions ? item.ItemID : item.GroupID;
                        joinView.Attributes.Add("name", viewDiscussions ? "view" : "join");
                    }

                    HtmlAnchor titleLink = (HtmlAnchor)e.Item.FindControl("titleLink");
                    if (titleLink != null)
                    {
                        if (viewDiscussions)
                        {
                            if (e.Item.DataItem is GroupCardModel)
                            {
                                Item grpItem = Sitecore.Context.Database.GetItem(item.ItemID);
                                var link = LinkManager.GetItemUrl(grpItem);

                                titleLink.HRef = link;
                            }
                        }
                    }

                    var recommendationIcons = e.Item.FindControl("CommunityRecommendationIcons") as CommunityRecommendationIcons;
                    if (recommendationIcons != null)
                    {
                        recommendationIcons.MatchingChildrenIds = item.GrpItem.GetMatchingChildrenIds(this.CurrentMember);
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
            }
            catch (Exception ex)
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
            if (btn.Attributes["name"].ToString().Equals("view"))
            {
                try
                {

                    //Call view Discussion using sitecore group id
                    Sitecore.Data.ID grpItemID = Sitecore.Data.ID.Parse(btn.CommandArgument);
                    Item grpItem = Sitecore.Context.Database.GetItem(grpItemID);
                    string itemUrl = Sitecore.Links.LinkManager.GetItemUrl(grpItem);
                    Sitecore.Web.WebUtil.Redirect(itemUrl);
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in btnJoinGroup_Click for View Discussions function.\nError:\n" + ex.Message);
                }
            }
            else
            {
                try
                {
                    //TODO: Get test Cases for this redirect
                    //this.ProfileRedirect(UnderstoodDotOrg.Common.Constants.UserPermission.CommunityUser);
                    //Join the group using telligent group id
                    if (CommunityHelper.JoinGroup(btn.CommandArgument, UserID))
                    {
                        //Send Email
                        GroupItem grpItem = new GroupItem(Groups.ConvertGroupIDtoSitecoreItem(btn.CommandArgument));
                        GroupCardModel grpModel = Groups.GroupCardModelFactory(grpItem);

                        BaseReply reply = ExactTargetService.InvokeEM9GroupWelcome(new InvokeEM9GroupWelcomeRequest
                        {
                            PreferredLanguage = CurrentMember.PreferredLanguage,
                            GroupLeaderEmail = grpModel.ModeratorEmail,
                            GroupLink = grpItem.GetUrl(),
                            GroupTitle = grpItem.DisplayName,
                            ToEmail = CurrentMember.Email,

                            GroupModerator = new Moderator
                            {
                                groupModBioLink = grpModel.ModeratorBio,
                                groupModImgLink = grpModel.ModeratorAvatarUrl, //owner.Avatar,
                                groupModName = grpModel.ModeratorName
                            }
                        });



                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in btnJoinGroup_Click for joining Group function.\nError:\n" + ex.Message);

                }

            }

            DataBind();

        }
    }
}