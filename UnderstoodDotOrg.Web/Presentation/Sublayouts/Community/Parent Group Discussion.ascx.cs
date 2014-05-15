using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Discussion : System.Web.UI.UserControl
    {
        GroupDiscussionList rptGroupDiscussion;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptGroupDiscussion = (GroupDiscussionList)Page.LoadControl("~/Presentation/Sublayouts/Common/GroupDiscussionList.ascx");
            rptGroupDiscussion.ID = "rptGroupCards";
            plhGroupDiscussions.Controls.Add(rptGroupDiscussion);

            if (!IsPostBack)
            {
                txtBody.Attributes.Add("placeholder", "Join the discussion");
                txtBody.Attributes.Add("id", "join-discussion-text");
               
            }
                txtBody.Text = "";
                Item currItem = Sitecore.Context.Item;
                if (currItem != null)
                {
                    GroupDiscussionItem grpDItem = new GroupDiscussionItem(currItem);
                    if (grpDItem != null)
                    {
                        Session["discussionItem"] = grpDItem;
                        string forumID = grpDItem.ForumID.Text;
                        string threadID = grpDItem.ThreadID.Text;
                        try
                        {
                            ThreadModel thModel = new ThreadModel(forumID, threadID);

                            //Populate the initial Post
                            lblSubject.Text = thModel.Subject;
                            imgAvatar.ImageUrl = thModel.Author.AvatarUrl;
                            lblName.Text = thModel.Author.UserName;
                            lblLocation.Text = thModel.Author.UserLocation;
                            litComment.Text = thModel.Body;
                            litNumReplies.Text = thModel.ReplyCount;
                            rptChildCard.DataSource = thModel.Author.Children;
                            rptChildCard.DataBind();
                            rptGroupDiscussion.DataSource = thModel.Replies;
                            rptGroupDiscussion.DataBind();
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                
            }
                //var grpDitem = Session["discussionItem"] as GroupDiscussionItem;
                //if (grpDitem != null)
                //{
                //    string forumID = grpDitem.ForumID.Text;
                //    string threadID = grpDitem.ThreadID.Text;
                //    var replies = CommunityHelper.ReadReplies(forumID, threadID);
                //    rptGroupDiscussion.DataSource = replies;
                //    rptGroupDiscussion.DataBind();
                //}
          

        }

        protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
            if (childIssues_repeater != null)
            {
                childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
                childIssues_repeater.DataBind();
            }
        }

        protected void lbSubmitReply_Click(object sender, EventArgs e)
        {
            var grpDitem= Session["discussionItem"] as GroupDiscussionItem;
            if( grpDitem !=null)
            {
                string forumID = grpDitem.ForumID.Text;
                string threadID = grpDitem.ThreadID.Text;
                string body = txtBody.Text;
                if(!String.IsNullOrEmpty(body))
                    CommunityHelper.PostReply(forumID, threadID ,body);
                var replies = CommunityHelper.ReadReplies(forumID, threadID);
                rptGroupDiscussion.DataSource = replies;
                rptGroupDiscussion.DataBind();

            }
        }
    }
}