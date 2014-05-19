using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home {
    public partial class HomeFeatured : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            HomePageItem current = Sitecore.Context.Item;
            if (current != null) {
                var articles = current.FeaturedArticles.ListItems;
                if (articles.Any()) {
                    rptFeaturedArticles.Visible = true;
                    rptFeaturedArticles.DataSource = articles;
                    rptFeaturedArticles.DataBind();
                }
                else {
                    this.Visible = false;
                }
            }
        }

        protected void rptFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item article = e.Item.DataItem as Item;
                if (article != null) {
                    HyperLink hypArticleLink = e.FindControlAs<HyperLink>("hypArticleLink");
                    Literal ltArticleText = e.FindControlAs<Literal>("ltArticleText");
                    Sitecore.Web.UI.WebControls.Image frArticleImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("frArticleImage");

                    if (hypArticleLink != null) {
                        hypArticleLink.NavigateUrl = article.GetUrl();
                    }
                    if (ltArticleText != null && article.IsOfType(BasicArticlePageItem.TemplateId)) {
                        BasicArticlePageItem articleItem = article;
                        ltArticleText.Text = articleItem.DefaultArticlePage.ContentPage.BasePageNEW.NavigationTitle.Raw.Truncate(50, true, true);
                    }
                    if (frArticleImage != null) {
                        frArticleImage.Item = article;
                    }
                }
            }
        }
    }
}