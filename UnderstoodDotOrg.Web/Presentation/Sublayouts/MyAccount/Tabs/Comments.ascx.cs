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
            var nodes = CommunityHelper.ReadUserComments(CurrentMember.ScreenName);

            if (nodes != null)
            {
                var comments = nodes.SelectNodes("Comments[position()<=10] ");

                List<Comment> commentsDataSource = new List<Comment>();
                foreach (XmlNode item in comments)
                {
                    Comment cItem = new Comment();

                    var descNode = item.SelectSingleNode("//Content/HtmlDescription");
                    cItem.Body = descNode != null ? descNode.InnerText : string.Empty;

                    var titleNode = item.SelectSingleNode("//Content/HtmlName");
                    cItem.ParentTitle = titleNode != null ? titleNode.InnerText : string.Empty;

                    var urlNode = item.SelectSingleNode("//Content/Url");
                    cItem.Url = urlNode != null ? urlNode.InnerText : string.Empty;

                    cItem.CommentDate = DateTime.Today;

                    cItem.ParentTitle = "Q&A";

                    cItem.CommentGroup = "Parent Questions";

                    cItem.CommentGroupUrl = "/";

                    commentsDataSource.Add(cItem);
                }

                rptComments.DataSource = commentsDataSource;
                rptComments.DataBind();
            }
        }
        
        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (Comment)e.Item.DataItem as Comment;
            HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
            hypCommentLink.NavigateUrl = ((Comment)e.Item.DataItem).ParentTitleUrl;
            hypCommentLink.Text = ((Comment)e.Item.DataItem).ParentTitle;

            Literal litSection = (Literal)e.Item.FindControl("litSection");
            litSection.Text = ((Comment)e.Item.DataItem).ParentTitle;

            Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
            litCommentBody.Text = ((Comment)e.Item.DataItem).Body;

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = ((Comment)e.Item.DataItem).CommentDate.ToString();

            Literal litLikes = (Literal)e.Item.FindControl("litLikes");
            litLikes.Text = ((Comment)e.Item.DataItem).Likes.ToString();

            HyperLink hypCommentGroup = (HyperLink)e.Item.FindControl("hypCommentGroup");
            hypCommentGroup.NavigateUrl = ((Comment)e.Item.DataItem).CommentGroupUrl;
            hypCommentGroup.Text = ((Comment)e.Item.DataItem).CommentGroup;
        }
    }
}