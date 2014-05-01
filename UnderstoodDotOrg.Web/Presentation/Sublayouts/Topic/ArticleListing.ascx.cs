using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic {
    public partial class ArticleListing : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            TopicLandingPageItem topicPage = Sitecore.Context.Item;
            if (topicPage != null && topicPage.SliderCuratedFeaturedcontent != null) {
                List<Item> sliderCuratedFeatured = topicPage.SliderCuratedFeaturedcontent.ListItems;
                if (sliderCuratedFeatured != null && sliderCuratedFeatured.Any()) {

                    // Gets all article under topic page.
                    // List<Item> articles = topicPage.InnerItem.Axes.GetDescendants().FilterByContextLanguageVersion().Where(i => i.InheritsFromType(DefaultArticlePageItem.TemplateId)).ToList();

                    //var excludeCuratedFeaturedArticle = from t1 in articles
                    //                                           where sliderCuratedFeatured.Any(t2 => t2.ID.ToString() != t1.ID.ToString())
                    //                                           select t1;	
                   
                    rptArticleListing.DataSource = sliderCuratedFeatured.Take(6);
                    rptArticleListing.DataBind();
                    if (sliderCuratedFeatured.Count() > 6) {
                        pnlMoreArticle.Visible = true;
                    }
                    hfGUID.Value = Sitecore.Context.Item.ID.ToString();
                    hfResultsPerClick.Value = "6";
                }
                else {
                    this.Visible = false;
                }
            }
            else {
                this.Visible = false;
            }
        }

        protected void rptArticleListing_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item subTopicItem = e.Item.DataItem as Item;
                if (subTopicItem != null) {
                    Literal ltRowListingStart = e.FindControlAs<Literal>("ltRowListingStart");
                    Literal ltRowListingEnd = e.FindControlAs<Literal>("ltRowListingEnd");
                    HyperLink hlNavLink = e.FindControlAs<HyperLink>("hlNavLink");
                    HyperLink hlLinkText = e.FindControlAs<HyperLink>("hlLinkText");
                    System.Web.UI.WebControls.Image defaultImage = e.FindControlAs<System.Web.UI.WebControls.Image>("defaultImage");
                    FieldRenderer scThumbnailImage = e.FindControlAs<FieldRenderer>("scThumbnailImage");
                    if (e.Item.ItemIndex % 2 != 1) {
                        if (ltRowListingStart != null) {
                            ltRowListingStart.Text = "<div class=\"row listing-row\">";
                        }
                    }
                    else {
                        if (ltRowListingEnd != null) {
                            ltRowListingEnd.Text = "</div>";
                        }
                    }

                    ContentPageItem content = new ContentPageItem(subTopicItem);
                    if (hlLinkText != null) {
                        hlLinkText.Text = content.PageTitle.Rendered;
                        hlLinkText.NavigateUrl = subTopicItem.GetUrl();
                    }

                    if (hlNavLink != null) {
                        hlNavLink.NavigateUrl = subTopicItem.GetUrl();
                    }

                    if (subTopicItem.InheritsFromType(DefaultArticlePageItem.TemplateId)) {
                        DefaultArticlePageItem contentPageItem = new DefaultArticlePageItem(subTopicItem);
                        if (scThumbnailImage != null && contentPageItem != null && contentPageItem.ContentThumbnail.MediaItem != null) {
                            scThumbnailImage.Item = contentPageItem;
                            if (defaultImage != null) {
                                defaultImage.Visible = false;
                            }
                        }
                        else {
                            if (defaultImage != null) {
                                defaultImage.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}