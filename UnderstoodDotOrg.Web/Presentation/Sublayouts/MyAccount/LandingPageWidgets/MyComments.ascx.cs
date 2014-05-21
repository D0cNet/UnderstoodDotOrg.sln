using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var commentsList = CommunityHelper.ListUserComments(CurrentUser.UserName);
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountComments);
            hypCommentsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
            
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

            lblCount.Text = commentsList.Count.ToString();

            if (commentsList != null)
            {
                rptComments.DataSource = commentsList;
                rptComments.DataBind();
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
                hypCommentLink.NavigateUrl = "/";
                hypCommentLink.Text = ((Comment)e.Item.DataItem).ParentTitle;

                Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
                litCommentBody.Text = ((Comment)e.Item.DataItem).Body.Truncate(30, true, false);
            }
        }

    }
}