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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Comments : BaseSublayout<AccountCommentsPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

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

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as Comment;
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
    }
}