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
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : BaseSublayout
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
                MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;
                var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountComments);
                hypCommentsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
                hypCommentsTab.Text = context.SeeAllCommentsText;

                int totalComments;

                List<Services.Models.Telligent.Comment> comments = TelligentService.GetUserComments(CurrentMember.ScreenName, 1, 2, out totalComments);

                // TODO: comment count needs to retrieved from the TotalCount attribute, this returns the number of paged results
                litCount.Text = totalComments.ToString();

                if (comments.Any())
                {
                    pnlComments.Visible = true;
                    rptComments.DataSource = comments;
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
            if (e.Item.DataItem != null)
            {
                var comment = e.Item.DataItem as Services.Models.Telligent.Comment;
                HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");

                ContentPageItem item = Sitecore.Context.Database.GetItem(comment.SitecoreId);
                if (item != null)
                {
                    hypCommentLink.NavigateUrl = item.GetUrl();
                    hypCommentLink.Text = item.PageTitle.Rendered;
                }

                Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
                litCommentBody.Text = UnderstoodDotOrg.Common.Helpers.TextHelper.TruncateText(
                    Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(comment.Body)), 30); // TODO: use constant
            }
        }

    }
}