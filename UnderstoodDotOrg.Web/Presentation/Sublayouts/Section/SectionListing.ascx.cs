using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Section {
    public partial class SectionListing : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            SectionLandingPageItem contextItem = Sitecore.Context.Item;
            if (contextItem != null) {
                var topicPages = contextItem.GetTopicLandingPageItem();
                if (topicPages != null && topicPages.Any()) {
                    rptTopicLandingItems.DataSource = topicPages;
                    rptTopicLandingItems.DataBind();
                }
            }
        }

        protected void rptTopicLanding_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                TopicLandingPageItem item = e.Item.DataItem as TopicLandingPageItem;
                if (item != null) {
                    HyperLink hlTopicLink = e.FindControlAs<HyperLink>("hlTopicLink");
                    Repeater rptTopicListItems = e.FindControlAs<Repeater>("rptTopicListItems");

                    Sitecore.Web.UI.WebControls.Image scThumbnailImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scThumbnailImage");
                    Image defaultImage = e.FindControlAs<Image>("defaultImage");

                    if (hlTopicLink != null) {
                        hlTopicLink.Text = item.Name;
                        hlTopicLink.NavigateUrl = item.InnerItem.GetUrl();
                    }


                   // ContentPageItem contentPageItem = new ContentPageItem(item.InnerItem);

                    //if (scThumbnailImage != null) {
                    //    if (defaultImage != null && contentPageItem.ThumbnailImage.MediaUrl.IsNullOrEmpty()) {
                    //        defaultImage.Visible = true;
                    //    }
                    //    else {
                    //        scThumbnailImage.Item = contentPageItem;
                    //    }
                    //}
                    defaultImage.Visible = true;
                    if (item.CuratedFeaturedcontent != null) {
                        var resultFeaturedContent = item.CuratedFeaturedcontent.ListItems;
                        if (resultFeaturedContent.Any()) {
                            if (scThumbnailImage != null) {
                                Item firstFeaturedItem = resultFeaturedContent.FirstOrDefault();
                                ContentPageItem contentPageItem = new ContentPageItem(firstFeaturedItem);
                                //MediaItem thumbnailImage = MediaManager.GetMediaUrl(mediaItem, mediaOptions);
                                if (contentPageItem != null) {
                                    if (contentPageItem.ThumbnailImage.MediaUrl.IsNullOrEmpty()) {
                                        defaultImage.Visible = true;
                                    }
                                    if (scThumbnailImage != null) {
                                        scThumbnailImage.Item = contentPageItem;
                                        defaultImage.Visible = false;
                                    }
                                }
                            }

                            rptTopicListItems.DataSource = resultFeaturedContent.Take(3);
                            rptTopicListItems.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptTopicListItems_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item item = e.Item.DataItem as Item;
                if (item != null) {
                    HyperLink hlTopicTitle = e.FindControlAs<HyperLink>("hlTopicTitle");
                    if (hlTopicTitle != null) {
                        hlTopicTitle.NavigateUrl = LinkManager.GetItemUrl(item);
                        hlTopicTitle.Text = item.Fields["Page Title"].Value;
                    }
                }
            }
        }

    }
}