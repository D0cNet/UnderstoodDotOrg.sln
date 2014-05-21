using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Groups : BaseSublayout<AccountGroupsPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var commentsList = CommunityHelper.ListUserComments(CurrentUser.UserName);
            subheadergroups.Items.Add(new ListItem("ADHD"));

            Comment cmItem = new Comment();
            cmItem.Body = "Comment 1 From Group ADHD";
            cmItem.ParentTitle = "Parent Title";
            cmItem.CommentDate = DateTime.Today;
            cmItem.Likes = "31";
            cmItem.CommentGroup = "ADHD";
            cmItem.CommentGroupUrl = "/";
            cmItem.ReplyCount = "12";
            cmItem.AuthorDisplayName = "Vance Floyd";
            List<Comment> commentsList = new List<Comment>();
            commentsList.Add(cmItem);

            cmItem = new Comment();
            cmItem.Body = "Comment 2 From Group ADHD";
            cmItem.ParentTitle = "Parent Title";
            cmItem.CommentDate = DateTime.Today;
            cmItem.Likes = "53";
            cmItem.CommentGroup = "ADHD";
            cmItem.CommentGroupUrl = "/";
            cmItem.ReplyCount = "7";
            cmItem.AuthorDisplayName = "Vance Floyd";
            commentsList.Add(cmItem);

            if (commentsList != null)
            {
                rptComments.DataSource = commentsList;
                rptComments.DataBind();
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Comment;
            HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
            hypCommentLink.NavigateUrl = "/";
            hypCommentLink.Text = item.Body;

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.CommentDate.ToString();

            Literal litRepliesCount = (Literal)e.Item.FindControl("litRepliesCount");
            litRepliesCount.Text = item.ReplyCount;

            HyperLink hypCommentAuthor = (HyperLink)e.Item.FindControl("hypCommentAuthor");
            hypCommentAuthor.NavigateUrl = "/";
            hypCommentAuthor.Text = item.AuthorDisplayName;
        }

        protected void subheadergroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}