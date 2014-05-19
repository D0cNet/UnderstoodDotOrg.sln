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

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages {
    public partial class TopicLandingPageItem {

        /// <summary>
        /// Get sub topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubtopicLandingPageItem> GetSubTopicLandingPageItem() {
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

            var curated = CuratedFeaturedcontent.ListItems;
            if (curated.Any())
            {
                totalResults = curated.Count;
                results = curated
                            .Skip(page - 1)
                            .Take(Constants.TOPIC_LISTING_ARTICLES_PER_PAGE)
                            .Select(i => new DefaultArticlePageItem(i));
            }
            else
            {
                // TODO: refactor so all results are Article type to avoid null check
                List<Article> articles = SearchHelper.GetMostRecentArticlesWithin(InnerItem.ID, page, Constants.TOPIC_LISTING_ARTICLES_PER_PAGE, out totalResults);
                results = from a in articles
                          let i = a.GetItem()
                          where i != null
                          select new DefaultArticlePageItem(i);
            }

            hasMoreResults = ((page - 1) * Constants.TOPIC_LISTING_ARTICLES_PER_PAGE) + results.Count() < totalResults;

            return results;
        }
    }
}