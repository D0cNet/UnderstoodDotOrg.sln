using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class AdvocacyLandingPage : BaseSublayout<AdvocacyLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var globalsItem = MainsectionItem.GetGlobals();
            var advocacyLinks = globalsItem.GetAdvocacyLinksFolder().GetAdvocacyLinks();

            rptArticles.DataSource = this.Model.GetAdvocacyArticles().OrderByDescending(x => x.DefaultArticlePage.ReviewedDate.DateTime);
            rptArticles.DataBind();

            rptrActionAlerts.DataSource = advocacyLinks;
            rptrActionAlerts.DataBind();
        }

        protected void btnActNow_Click(object sender, EventArgs e)
        {
            var btnActNow = sender as HtmlButton;
            var url = btnActNow.Attributes["data-url"];
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
        }

        protected void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as AdvocacyArticlePageItem;

            HyperLink hypArticleThumbnailLink = (HyperLink)e.Item.FindControl("hypArticleThumbnailLink");
            hypArticleThumbnailLink.NavigateUrl = item.InnerItem.GetUrl();

            HyperLink hypArticleLink = (HyperLink)e.Item.FindControl("hypArticleLink");
            hypArticleLink.NavigateUrl = item.InnerItem.GetUrl();
            hypArticleLink.Text = item.DefaultArticlePage.ContentPage.BasePageNEW.NavigationTitle.Rendered;
            
            Image articleThumbnail = (Image)e.Item.FindControl("articleThumbnail");
            articleThumbnail.ImageUrl = item.DefaultArticlePage.ContentThumbnail.MediaItem != null ? item.DefaultArticlePage.ContentThumbnail.MediaUrl : item.DefaultArticlePage.FeaturedImage.MediaUrl;
        }
    }
}