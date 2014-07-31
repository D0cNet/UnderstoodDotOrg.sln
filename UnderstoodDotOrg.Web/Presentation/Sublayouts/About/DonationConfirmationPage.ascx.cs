using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class DonationConfirmationPage : BaseSublayout<DonationConfirmationPageItem>
    {
        public List<DefaultArticlePageItem> TempList = new List<DefaultArticlePageItem>();
        public int ListTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            imgBanner.ImageUrl = this.Model.BannerImage.MediaItem != null ? this.Model.BannerImage.MediaUrl : "";

            List<DefaultArticlePageItem> recommendedArticles;

            if (IsUserLoggedIn)
            {
                recommendedArticles = SearchHelper.GetRecommendedContent(CurrentMember, DefaultArticlePageItem.TemplateId)
                                    .Where(a => a.GetItem() != null)
                                    .Select(a => new DefaultArticlePageItem(a.GetItem()))
                                    .ToList();

                if (recommendedArticles.Count > 0)
                {
                    rptFeaturedArticles.DataSource = recommendedArticles.Take(4);
                    rptFeaturedArticles.DataBind();
                }
            }
        }

        protected void rptFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem dataItem = (DefaultArticlePageItem)e.Item.DataItem;
                Repeater rptRow = e.FindControlAs<Repeater>("rptRow");

                if (TempList.Count < 2)
                {
                    TempList.Add(dataItem);
                    if (TempList.Count == 2)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                        TempList.Clear();
                    }
                    else if (e.Item.ItemIndex + 1 == ListTotal)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                    }
                }
            }
        }

        protected void rptRow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem dataItem = (DefaultArticlePageItem)e.Item.DataItem;

                if (dataItem.InnerItem.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                {
                    DefaultArticlePageItem article = (DefaultArticlePageItem)dataItem;

                    System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");
                    HyperLink hypArticleLink = e.FindControlAs<HyperLink>("hypArticleLink");
                    HyperLink hypThumbnail = e.FindControlAs<HyperLink>("hypThumbnail");
                    ArticleRecommendationIcons articleRecommendationIcons = e.FindControlAs<ArticleRecommendationIcons>("articleRecommendationIcons");

                    if (imgThumbnail != null)
                        imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(230, 129);

                    if (hypArticleLink != null)
                    {
                        hypArticleLink.NavigateUrl = hypThumbnail.NavigateUrl = article.GetUrl();
                        hypArticleLink.Text = article.ContentPage.PageTitle;
                    }

                    if (IsUserLoggedIn)
                    {
                        articleRecommendationIcons.HasMatchingParentInterest = article.HasMatchingParentInterest(CurrentMember);
                        articleRecommendationIcons.MatchingChildrenIds = article.GetMatchingChildrenIds(CurrentMember);
                    }
                }
            }
        }
    }
}