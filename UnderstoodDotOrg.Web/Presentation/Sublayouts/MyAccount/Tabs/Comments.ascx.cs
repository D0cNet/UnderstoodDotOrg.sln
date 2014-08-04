using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Comments : BaseSublayout<AccountCommentsPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var items = CommunityHelper.GetMyAccountCommentsSortOptions();

                foreach (var item in items)
                {

                    ddlSort.Items.Add(new ListItem() { Text = item.Description, Value = item.Value });
                }

                ddlSort.DataBind();

                foreach (ListItem item in ddlSort.Items)
                {
                    if (item.Value == UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.MostRecent.ToString())
                    {
                        ddlSort.SelectedValue = item.Value;
                        break;
                    }
                }

                SortComments();

            }

            if (string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                pnlNoProfile.Visible = true;
                //TODO: add navigate URL for hypCompleteYourProfile
            }
            else
            {
                int totalComments;

                var commentsList = TelligentService.GetUserCommentsByScreenName(CurrentMember.ScreenName, 1, Constants.PUBLIC_PROFILE_COMMENTS_PER_PAGE, out totalComments);

                if ((commentsList != null) && (commentsList.Count != 0))
                {
                    pnlComments.Visible = true;
                    rptComments.DataSource = commentsList;
                    rptComments.DataBind();
                }
                else
                {
                    pnlNoComments.Visible = true;
                }
            }
        }

        private void SortComments()
        {
            String sort = ddlSort.SelectedValue;

            int totalComments;

            List<Services.Models.Telligent.Comment> commentsList = TelligentService.GetUserCommentsByScreenName(CurrentMember.ScreenName, 1, Constants.PUBLIC_PROFILE_COMMENTS_PER_PAGE, out totalComments);

            if (sort == UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.MostRecent.ToString())
            {
                commentsList = commentsList.OrderByDescending(x => x.CommentDate).ToList();
            }
            else if (sort == UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.OldestToNewest.ToString())
            {
                commentsList = commentsList.OrderBy(x => x.CommentDate).ToList();
            }
            else if (sort == UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.NumberOfComments.ToString())
            {
                commentsList = commentsList.OrderByDescending(x => x.ReplyCount).ToList();
            }
            else if (sort == UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.RecentComments.ToString())
            {
                //commentsList.OrderBy(x => x.RecentCommentDate);
            }

            if ((commentsList != null) && (commentsList.Count != 0))
            {
                pnlComments.Visible = true;
                rptComments.DataSource = commentsList;
                rptComments.DataBind();
            }
            else
            {
                pnlNoComments.Visible = true;
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Services.Models.Telligent.Comment;
            HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
            hypCommentLink.Text = item.CommentTitle;

            Literal litSection = (Literal)e.Item.FindControl("litSection");
            litSection.Text = item.Type;

            Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
            litCommentBody.Text = Regex.Replace(Regex.Replace(item.Body, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ");

            Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
            litCommentTime.Text = item.PublishedDate;

            Literal litLikes = (Literal)e.Item.FindControl("litLikes");
            litLikes.Text = item.Likes;

            HtmlGenericControl commentGroupSpan = (HtmlGenericControl)e.Item.FindControl("commentGroupSpan");
            HyperLink hypCommentGroup = (HyperLink)e.Item.FindControl("hypCommentGroup");

            Item parent = Sitecore.Context.Database.GetItem(item.SitecoreId);

            if (parent != null)
            {
                hypCommentGroup.NavigateUrl = hypCommentLink.NavigateUrl = parent.GetUrl();
                hypCommentGroup.Text = parent.DisplayName;
            }
            else
                commentGroupSpan.Visible = false;
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortComments();
        }
    }
}