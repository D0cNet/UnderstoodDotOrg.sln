﻿using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Discussion : BaseSublayout//System.Web.UI.UserControl
    {
       // GroupDiscussionList rptGroupDiscussion;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbSubmitReply.Text = DictionaryConstants.SubmitButtonText;

          //  rptGroupDiscussion = (GroupDiscussionList)Page.LoadControl("~/Presentation/Sublayouts/Common/GroupDiscussionList.ascx");
         //   rptGroupDiscussion.ID = "rptGroupCards";
         //   plhGroupDiscussions.Controls.Add(rptGroupDiscussion);

            //if (!IsPostBack)
            //{
                txtBody.Attributes.Add("placeholder", "Join the discussion");
                txtBody.Attributes.Add("id", "join-discussion-text");
               
            
               
                Item currItem = Sitecore.Context.Item;
                if (currItem != null)
                {
                    hrfBack.HRef = LinkManager.GetItemUrl(currItem.Parent);
                    litBack.Text = currItem.Parent.Name;
                    GroupDiscussionItem grpDItem = new GroupDiscussionItem(currItem);
                    if (grpDItem != null)
                    {
                        Session["discussionItem"] = grpDItem;
                        string forumID = grpDItem.ForumID.Text;
                        string threadID = grpDItem.ThreadID.Text;
                        try
                        {
                            ThreadModel thModel = UnderstoodDotOrg.Services.CommunityServices.Threads.ThreadModelFactory(forumID, threadID);

                            //Populate the initial Post
                            ProfileCommentCard.LoadState(thModel.Author);

                            rptGroupDiscussion.DataSource = thModel.Replies;
                            rptGroupDiscussion.DataBind();

                            if (thModel.Author!=null)
                            {


                                ThanksButton.LoadState(thModel.Author.UserName);
                                ThinkingOfYouButton.LoadState(thModel.Author.UserName);
                            }
                                
                            lblSubject.Text = thModel.Subject;

                            litComment.Text = thModel.Body;
                            litNumReplies.Text = thModel.ReplyCount;
                            LikeButton.LoadState(thModel.ContentId, thModel.ContentTypeId);
                            litMemberCount.Text = thModel.Replies.Select(m => m.AuthorName).Distinct().Count().ToString();

                            
                        }
                        catch (Exception ex)
                        {
                            Sitecore.Diagnostics.Error.LogError("Error Retrieving replies Page_Load Parent Group Discussions.\nError" + ex.Message);
                        }

                    }
                }
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
            if( grpDitem !=null && CurrentMember!=null)
            {
                string forumID = grpDitem.ForumID.Text;
                string threadID = grpDitem.ThreadID.Text;
                string body = txtBody.Text;
                if(!String.IsNullOrEmpty(body))
                    TelligentService.PostReply(forumID, threadID ,body,CurrentMember.ScreenName);
                var replies = TelligentService.ReadReplies(forumID, threadID);
                litNumReplies.Text = replies.Count.ToString();
              
                rptGroupDiscussion.DataSource = replies;
                rptGroupDiscussion.DataBind();
                txtBody.Text = "";

            }
        }
    }
}