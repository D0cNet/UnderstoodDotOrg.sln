using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class TopicLandingPageItem
    {

        /// <summary>
        /// Get sub topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubtopicLandingPageItem> GetSubTopicLandingPages()
        {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(SubtopicLandingPageItem.TemplateId)).Select(i => (SubtopicLandingPageItem)i);
        }

        /// <summary>
        /// Returns featured articles, fallback to most recent articles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DefaultArticlePageItem> GetTopicArticles(int page, out bool hasMoreResults)
        {
            IEnumerable<DefaultArticlePageItem> results = Enumerable.Empty<DefaultArticlePageItem>();
            int totalResults = 0;
            int offset = (page - 1) * Constants.TOPIC_LISTING_ARTICLES_PER_PAGE;

            var curated = TopicFeaturedArticles.ListItems;
            if (curated.Any())
            {
                totalResults = curated.Count;
                results = curated
                            .FilterByContextLanguageVersion()
                            .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                            .Skip(offset)
                            .Take(Constants.TOPIC_LISTING_ARTICLES_PER_PAGE)
                            .Select(i => new DefaultArticlePageItem(i));
            }
            else
            {
                List<Article> articles = SearchHelper.GetMostRecentArticlesWithin(InnerItem.ID, page, Constants.TOPIC_LISTING_ARTICLES_PER_PAGE, out totalResults);
                results = articles.Select(i => new DefaultArticlePageItem(i.GetItem()))
                                .Where(i => i.InnerItem != null);
            }

            hasMoreResults = ((page - 1) * Constants.TOPIC_LISTING_ARTICLES_PER_PAGE) + results.Count() < totalResults;

            return results;
        }

        public IEnumerable<DefaultArticlePageItem> GetGalleryArticles()
        {
            IEnumerable<DefaultArticlePageItem> results = Enumerable.Empty<DefaultArticlePageItem>();

            if (GalleryFeaturedArticles.ListItems.Any())
            {
                results = GalleryFeaturedArticles.ListItems.FilterByContextLanguageVersion()
                            .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                            .Select(i => new DefaultArticlePageItem(i))
                            .Take(Constants.FEATURED_TOPIC_GALLERY_ENTRIES);
            }

            return results;
        }

        public IEnumerable<DefaultArticlePageItem> GetFeaturedSectionArticles()
        {
            IEnumerable<DefaultArticlePageItem> results = Enumerable.Empty<DefaultArticlePageItem>();

            if (SectionFeaturedArticles.ListItems.Any())
            {
                results = SectionFeaturedArticles.ListItems.FilterByContextLanguageVersion()
                            .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                            .Select(i => new DefaultArticlePageItem(i))
                            .Take(Constants.SECTION_LANDING_ARTICLES_PER_ROW);
            }

            return results;
        }
    }
}