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
                    FieldRenderer frArticleText = e.FindControlAs<FieldRenderer>("frArticleText");
                    Sitecore.Web.UI.WebControls.Image frArticleImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("frArticleImage");

                    if (hypArticleLink != null) {
                        hypArticleLink.NavigateUrl = article.GetUrl();
                    }
                    if (frArticleText != null) {
                        frArticleText.Item = article;
                    }
                    if (frArticleImage != null) {
                        frArticleImage.Item = article;
                    }
                }
            }
        }
    }
}