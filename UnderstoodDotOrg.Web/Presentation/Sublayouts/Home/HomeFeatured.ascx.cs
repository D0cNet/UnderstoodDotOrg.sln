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
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Personalization;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home
{
    public partial class HomeFeatured : BaseSublayout<HomePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            List<DefaultArticlePageItem> articles = new List<DefaultArticlePageItem>();
            string moduleTitle;

            if (IsUserLoggedIn && CurrentMember.Children.Any())
            {
                moduleTitle = DictionaryConstants.RecommendedForYouLabel;
                articles = PersonalizationHelper.GetChildPersonalizedContents(CurrentMember.Children.First());
            }
            else
            {
                moduleTitle = DictionaryConstants.Featured;
                articles = Model.FeaturedArticles.ListItems
                                .FilterByContextLanguageVersion()
                                .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                                .Select(i => new DefaultArticlePageItem(i))
                                .ToList();
            }

            bool hasArticles = articles.Any();
            this.Visible = hasArticles;

            if (hasArticles)
            {
                litModuleTitle.Text = moduleTitle;
                rptFeaturedArticles.DataSource = articles.Take(Constants.HOMEPAGE_FEATURED_ARTICLES);
                rptFeaturedArticles.DataBind();
            }
        }

        protected void rptFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem article = e.Item.DataItem as DefaultArticlePageItem;

                HyperLink hypArticleLink = e.FindControlAs<HyperLink>("hypArticleLink");
                Literal ltArticleText = e.FindControlAs<Literal>("ltArticleText");
                System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");

                hypArticleLink.NavigateUrl = article.GetUrl();
                // TODO: verify this truncation is allowed
                ltArticleText.Text = article.ContentPage.BasePageNEW.NavigationTitle.Raw.Truncate(50, true, true);
                imgThumbnail.ImageUrl = article.GetArticleFeaturedThumbnailUrl(230, 129);
            }
        }
    }
}