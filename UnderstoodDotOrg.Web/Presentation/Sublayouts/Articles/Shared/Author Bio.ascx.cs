using System;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using System.Collections.Generic;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation;
using System.Web;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Author_Bio : BaseSublayout<AuthorItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            IEnumerable<DefaultArticlePageItem> articles = SearchHelper.GetArticlesByAuthor(Sitecore.Context.Item.ID, 2);

            if (articles.Count() > 0)
            {
                rptAuthorArticles.DataSource = articles;
                rptAuthorArticles.DataBind();
            }
            else
                relatedArticlesDiv.Visible = false;

            imgExpert.ImageUrl = Model.GetThumbnailUrl(189, 189);
        }

        protected void rptAuthorArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem article = (DefaultArticlePageItem)e.Item.DataItem;

                if (article != null)
                {
                    HyperLink hypImageLink = e.FindControlAs<HyperLink>("hypImageLink");
                    HyperLink hypAuthor = e.FindControlAs<HyperLink>("hypAuthor");
                    HyperLink hypReadMore = e.FindControlAs<HyperLink>("hypReadMore");
                    Literal litCommentCount = e.FindControlAs<Literal>("litCommentCount");
                    Literal litArticleTitle = e.FindControlAs<Literal>("litArticleTitle");
                    Literal litDatePosted = e.FindControlAs<Literal>("litDatePosted");
                    Literal litAbstract = e.FindControlAs<Literal>("litAbstract");
                    ArticleRecommendationIcons articleRecommendationIcons = e.FindControlAs<ArticleRecommendationIcons>("articleRecommendationIcons");

                    if (article.AuthorName.Item != null)
                    {
                        hypAuthor.Text = article.AuthorName.Item.DisplayName;
                        hypAuthor.NavigateUrl = Sitecore.Context.Item.GetUrl();

                        hypImageLink.NavigateUrl = hypReadMore.NavigateUrl = article.GetUrl();
                        hypImageLink.ImageUrl = article.GetArticleThumbnailUrl(230, 129);

                        litArticleTitle.Text = article.DisplayName;
                        litDatePosted.Text = article.InnerItem.Statistics.Created.ToString("mm dd, yyyy");
                        litAbstract.Text =  UnderstoodDotOrg.Common.Helpers.TextHelper.TruncateText(
                            Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(article.ContentPage.BodyContent.Raw)), 150);

                        bool hasMoreResults;
                        int totalComments;

                        List<Comment> dataSource = TelligentService.ReadComments(
                            article.BlogId.ToString(), article.BlogPostId.ToString(), 1, Constants.ARTICLE_COMMENTS_PER_PAGE, "CreatedUtcDate", true, out totalComments, out hasMoreResults);

                        litCommentCount.Text = totalComments.ToString();

                        if (IsUserLoggedIn)
                        {
                            articleRecommendationIcons.HasMatchingParentInterest = article.HasMatchingParentInterest(CurrentMember);
                            articleRecommendationIcons.MatchingChildrenIds = article.GetMatchingChildrenIds(CurrentMember);
                        }
                    }
                    else
                        e.Item.Visible = false;
                }
            }
        }
    }
}