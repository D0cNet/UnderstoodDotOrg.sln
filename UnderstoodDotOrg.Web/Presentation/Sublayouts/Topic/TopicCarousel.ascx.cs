using System;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using System.Linq;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic
{
    public partial class TopicCarousel : BaseSublayout<TopicLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var items = Model.GetGalleryArticles();
            if (items.Any())
            {
                rptTopicCarousel.DataSource = items;
                rptTopicCarousel.DataBind();
            }
            else
            {
                this.Visible = false;
            }
        }

        protected void rptTopicCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem item = e.Item.DataItem as DefaultArticlePageItem;

                System.Web.UI.WebControls.Image imgFeatured = e.FindControlAs<System.Web.UI.WebControls.Image>("imgFeatured");
                imgFeatured.ImageUrl = item.GetArticleFeaturedThumbnailUrl(630, 354);

                Literal litNavigationTitle = e.FindControlAs<Literal>("litNavigationTitle");
                litNavigationTitle.Text = item.ContentPage.BasePageNEW.NavigationTitle.Rendered;

                HyperLink hlImageLink = e.FindControlAs<HyperLink>("hlImageLink");
                hlImageLink.NavigateUrl = item.GetUrl();
            }
        }
    }
}