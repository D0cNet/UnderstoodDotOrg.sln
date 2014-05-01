using System;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using System.Linq;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic {
    public partial class TopicCarousel : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            TopicLandingPageItem contextItem = Sitecore.Context.Item;
            if (contextItem != null && contextItem.CuratedFeaturedcontent != null) {
                var curatedFeaturedContent = contextItem.CuratedFeaturedcontent.ListItems;
                if (curatedFeaturedContent != null && curatedFeaturedContent.Count > 0) {
                    rptTopicCarousel.DataSource = curatedFeaturedContent.Take(4);
                    rptTopicCarousel.DataBind();
                }
                else {
                    this.Visible = false;
                }
            }
            else {
                this.Visible = false;
            }
        }

        protected void rptTopicCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                 Item item = e.Item.DataItem as Item;
                 if (item != null && item.InheritsFromType(DefaultArticlePageItem.TemplateId)) {
                     DefaultArticlePageItem content = new DefaultArticlePageItem(item);
                     
                     Sitecore.Web.UI.WebControls.Image scThumbnailImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scThumbnailImage");
                     Image defaultImage = e.FindControlAs<Image>("defaultImage");
                     Sitecore.Web.UI.WebControls.Text scNavigationTitle = e.FindControlAs<Sitecore.Web.UI.WebControls.Text>("scNavigationTitle");

                     if (scThumbnailImage != null && content.FeaturedImage.MediaItem != null) {
                         scThumbnailImage.Item = content;
                     }
                     else {
                         defaultImage.Visible = true;
                     }

                     BasePageNEWItem basePageNewItem = new BasePageNEWItem(item);
                     if(basePageNewItem != null && scNavigationTitle != null){
                         scNavigationTitle.Item = basePageNewItem;
                     }
                 }
            }
        }
    }
}