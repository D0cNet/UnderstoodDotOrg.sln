using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData {
    public partial class GetArticles : System.Web.UI.Page {
        public static readonly int DEFAULT_NEW_LIST_COUNT_PER_CLICK = 6;
        Int32 clickCount = 1;
        protected void Page_Load(object sender, EventArgs e) {
            LoadArticles();
        }

        private void LoadArticles() {
            if (Request["count"] != null && Request["count"].Length > 0) {
                clickCount = Int32.Parse(Request["count"]);
            }

            int resultsPeClick = DEFAULT_NEW_LIST_COUNT_PER_CLICK;
            string parentId = string.Empty;
            if (Request.QueryString["rpc"] != null && Request.QueryString["rpc"].Length > 0)
                int.TryParse(Request.QueryString["rpc"], out resultsPeClick);
            if (Request["itemID"] != null) {
                parentId = Request["itemID"].ToString();
                TopicLandingPageItem objContextItem = Sitecore.Context.Database.GetItem(parentId);
                if (objContextItem.SliderCuratedFeaturedcontent != null && objContextItem.SliderCuratedFeaturedcontent.ListItems.Any()) {

                }

                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext()) {

                    List<Item> articles = objContextItem.InnerItem.Axes.GetDescendants().FilterByContextLanguageVersion().Where(i => i.InheritsFromType(DefaultArticlePageItem.TemplateId)).ToList();

                    if (articles != null) {
                        rptArticleListing.DataSource = articles.Skip(clickCount * resultsPeClick).Take(resultsPeClick).ToList();
                        rptArticleListing.DataBind();
                    }
                }
            }
        }

        protected void rptArticleListing_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item subTopicItem = e.Item.DataItem as Item;
                if (subTopicItem != null) {
                    HyperLink hlNavLink = e.FindControlAs<HyperLink>("hlNavLink");
                    HyperLink hlLinkText = e.FindControlAs<HyperLink>("hlLinkText");
                    Image defaultImage = e.FindControlAs<Image>("defaultImage");
                    Sitecore.Web.UI.WebControls.Image scThumbnailImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scThumbnailImage");

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
                            scThumbnailImage.Visible = true;
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