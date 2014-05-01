using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
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
                if (objContextItem.SliderCuratedFeaturedcontent != null) {
                    List<Item> articles = objContextItem.SliderCuratedFeaturedcontent.ListItems;
                    if (articles.Any()) {
                        rptArticleListing.DataSource = articles.Skip(clickCount * resultsPeClick).Take(resultsPeClick).ToList();
                        rptArticleListing.DataBind();

                        int itemCount = ((clickCount * resultsPeClick) + resultsPeClick);
                        if (articles.Count() <= itemCount) {
                            lblmoreArticle.Text = "false";
                        }
                    }
                }
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