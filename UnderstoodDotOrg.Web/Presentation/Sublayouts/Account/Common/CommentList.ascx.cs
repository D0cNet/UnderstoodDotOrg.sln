using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Common
{
    public partial class CommentList : System.Web.UI.UserControl
    {
        private int commentCharLimit = 300;
        public bool DisplayAuthorInfo { get; set; }
        public List<Comment> Comments { get; set; }
        public Member ProfileMember { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Comments != null && Comments.Any())
            {
                rptComments.DataSource = Comments;
                rptComments.DataBind();
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Comment comment = (Comment)e.Item.DataItem;
                Panel pnlAuthor = (Panel)e.FindControlAs<Panel>("pnlAuthor");
                Panel pnlComment = (Panel)e.FindControlAs<Panel>("pnlComment");

                HyperLink hlTitle = e.FindControlAs<HyperLink>("hlTitle");
                ContentPageItem item = Sitecore.Context.Database.GetItem(comment.SitecoreId);
                if (item != null)
                {
                    hlTitle.NavigateUrl = item.GetUrl();
                    hlTitle.Text = item.PageTitle.Rendered;
                }

                Literal litDate = e.FindControlAs<Literal>("litDate");
                litDate.Text = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(comment.CommentDate);

                Literal litComment = e.FindControlAs<Literal>("litComment");
                litComment.Text = UnderstoodDotOrg.Common.Helpers.TextHelper.TruncateText(
                    Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(comment.Body)), commentCharLimit);

                Literal litLikeCount = e.FindControlAs<Literal>("litLikeCount");
                litLikeCount.Text = comment.Likes;

                if (e.Item.ItemIndex == 0 && DisplayAuthorInfo && ProfileMember != null)
                {
                    pnlAuthor.Visible = true;

                    Literal litScreenName = e.FindControlAs<Literal>("litScreenName");
                    litScreenName.Text = ProfileMember.ScreenName;

                    Literal litLastUpdated = e.FindControlAs<Literal>("litLastUpdated");
                    MembershipManager mm = new MembershipManager();
                    var user = mm.GetUser(ProfileMember.MemberId);
                    litLastUpdated.Text = user.LastActivityDate.ToString("hh:mmtt on MMM dd yyyy");
                }
                else
                {
                    pnlComment.CssClass += " offset-6";
                }
            }
        }
    }
}