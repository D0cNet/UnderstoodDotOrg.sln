using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!IsPostBack)
            {
                List<GroupModel> groupsList = CommunityHelper.GetUserGroups(CurrentMember.ScreenName);
                ddlGroups.DataSource = groupsList;
                ddlGroups.DataValueField = "Url";
                ddlGroups.DataTextField = "Title";
                ddlGroups.DataBind();

                var commentsList = CommunityHelper.ReadComments();

                if (commentsList != null)
                {
                    rptComments.DataSource = commentsList.Where(x => x.ParentTitle == ddlGroups.SelectedItem.Text);
                    rptComments.DataBind();
                }
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Comment;
            HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
            hypCommentLink.NavigateUrl = "/";
            hypCommentLink.Text = Regex.Replace(Regex.Replace(item.Body, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ");

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.CommentDate.ToString();

            Literal litRepliesCount = (Literal)e.Item.FindControl("litRepliesCount");
            litRepliesCount.Text = item.ReplyCount;

            HyperLink hypCommentAuthor = (HyperLink)e.Item.FindControl("hypCommentAuthor");
            hypCommentAuthor.NavigateUrl = "/";
            hypCommentAuthor.Text = item.AuthorDisplayName;
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            var commentsList = CommunityHelper.ReadComments();

            if (commentsList != null)
            {
                rptComments.DataSource = commentsList.Where(x => x.ParentTitle == ddlGroups.SelectedItem.Text);
                rptComments.DataBind();
            }
        }
    }
}