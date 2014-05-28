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
            var commentsList = CommunityHelper.ListUserComments(CurrentMember.ScreenName);
           
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
            hypCommentLink.NavigateUrl = item.Url;
            hypCommentLink.Text = item.CommentTitle;

            Literal litSection = (Literal)e.Item.FindControl("litSection");
            litSection.Text = item.Type;

            Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
            litCommentBody.Text = item.Body;

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.PublishedDate;

            Literal litLikes = (Literal)e.Item.FindControl("litLikes");
            litLikes.Text = item.Likes;

            HyperLink hypCommentGroup = (HyperLink)e.Item.FindControl("hypCommentGroup");
            hypCommentGroup.NavigateUrl = "/";
            hypCommentGroup.Text = item.ParentTitle;
        }
    }
}