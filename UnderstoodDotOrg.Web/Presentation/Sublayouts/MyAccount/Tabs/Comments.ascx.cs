using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Comments : BaseSublayout<AccountCommentsPageItem>
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //var commentsList = CommunityHelper.ListUserComments(CurrentUser.UserName);

            Comment cmItem = new Comment();
            cmItem.Body = "Autem ipsa quis quisquam cumque consequatur deleniti est sit autem ut cumque quis hic. aut aut sit autem ut magni at optio non quidem necessitatibus. maxime cupiditate sed mollitia et unde fugit sunt illo dolorem similique commodi quas modi. culpa magni amet eos sunt harum porro libero laborum. voluptas eius nemo quam aut eaque assumenda veritatis quam officia. inventore eius quibusdam et repellat veniam perferendis est provident. commodi dolorem sunt nam vero";
            cmItem.ParentTitle = "Q&A";
            cmItem.CommentDate = DateTime.Today;
            cmItem.Likes = "31";
            cmItem.CommentGroup = "Parent Questions";
            cmItem.CommentTitle = "Est ducimus aut aut asperiores eveniet ut reprehenderit fuga corrupti quia quis neque minima ab quis dolorum consectetur dolore earum";
            cmItem.CommentGroupUrl = "/";
            cmItem.ReplyCount = "12";
            cmItem.AuthorDisplayName = "Vance Floyd";
            List<Comment> commentsList = new List<Comment>();
            commentsList.Add(cmItem);

            cmItem = new Comment();
            cmItem.Body = "Natus quia voluptatem ea quaerat et saepe dolorum rerum dolore aut sit eaque illo ut. repudiandae magnam dignissimos et earum velit quia quidem quaerat. voluptate qui laudantium debitis non omnis molestiae et error vitae. officiis qui necessitatibus quae minima blanditiis qui totam esse expedita qui numquam saepe. harum vitae est minima ducimus voluptatibus modi veniam dolore ipsa tempora. mollitia cum nesciunt blanditiis nostrum quia";
            cmItem.ParentTitle = "Article";
            cmItem.CommentDate = DateTime.Today;
            cmItem.Likes = "53";
            cmItem.CommentTitle = "Repudiandae magnam dignissimos et earum velit quia quidem quaerat.";
            cmItem.CommentGroup = "Parent Questions";
            cmItem.CommentGroupUrl = "/";
            cmItem.ReplyCount = "7";
            cmItem.AuthorDisplayName = "Vance Floyd";
            commentsList.Add(cmItem);

            cmItem = new Comment();
            cmItem.Body = "Natus quia voluptatem ea quaerat et saepe dolorum rerum dolore aut sit eaque illo ut. repudiandae magnam dignissimos et earum velit quia quidem quaerat. voluptate qui laudantium debitis non omnis molestiae et error vitae. officiis qui necessitatibus quae minima blanditiis qui totam esse expedita qui numquam saepe. harum vitae est minima ducimus voluptatibus modi veniam dolore ipsa tempora. mollitia cum nesciunt blanditiis nostrum quia";
            cmItem.ParentTitle = "Slideshow";
            cmItem.CommentDate = DateTime.Today;
            cmItem.Likes = "8";
            cmItem.CommentGroup = "Parent Questions";
            cmItem.CommentGroupUrl = "/";
            cmItem.CommentTitle = "Blanditiis qui totam esse expedita qui numquam saepe";
            
            cmItem.ReplyCount = "97";
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
            hypCommentLink.Text = item.CommentTitle;

            Literal litSection = (Literal)e.Item.FindControl("litSection");
            litSection.Text = item.ParentTitle;

            Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
            litCommentBody.Text = item.Body;

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.CommentDate.ToString();

            Literal litLikes = (Literal)e.Item.FindControl("litLikes");
            litLikes.Text = item.Likes;

            HyperLink hypCommentGroup = (HyperLink)e.Item.FindControl("hypCommentGroup");
            hypCommentGroup.NavigateUrl = "/";
            hypCommentGroup.Text = item.CommentGroup;
        }
    }
}