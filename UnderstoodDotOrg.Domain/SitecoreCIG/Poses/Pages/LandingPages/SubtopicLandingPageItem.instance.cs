using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common;
using System.Collections.Specialized;
using UnderstoodDotOrg.Domain.Understood.Activity;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class SubtopicLandingPageItem 
    {
        public IEnumerable<DefaultArticlePageItem> GetArticles(int page, Guid? templateId, out bool hasMoreResults)
        {
            var all = InnerItem.GetChildren()
                        .FilterByContextLanguageVersion()
                        .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            if (templateId.HasValue)
            {
                all = all.Where(i => i.TemplateID == Sitecore.Data.ID.Parse(templateId.Value));
            }

            return GetPagedResultQuery(all, page, out hasMoreResults);
        }

        public IEnumerable<DefaultArticlePageItem> GetFeaturedArticles(int page, out bool hasMoreResults)
        {
            var all = FeaturedArticles.ListItems
                        .FilterByContextLanguageVersion()
                        .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            return GetPagedResultQuery(all, page, out hasMoreResults);
        }

        public IEnumerable<DefaultArticlePageItem> GetPopularArticles(int page, out bool hasMoreResults)
        {
            var log = new ActivityLog();
            var articleIds = log.GetMostPopularArticleIdsBySubtopic(InnerItem, page, Constants.SUBTOPIC_LISTING_ARTICLES_PER_PAGE, out hasMoreResults);

            return articleIds.Select(x => (DefaultArticlePageItem)Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(x)))
                            .Where(x => x != null);
        }

        private IEnumerable<DefaultArticlePageItem> GetPagedResultQuery(IEnumerable<Item> query, int page, out bool hasMoreResults)
        {
            int pageSize = Constants.SUBTOPIC_LISTING_ARTICLES_PER_PAGE;
            int total = query.Count();
            int offset = (page - 1) * pageSize;

            var results = query.Skip(offset)
                            .Take(pageSize)
                            .Select(i => new DefaultArticlePageItem(i));

            hasMoreResults = offset + results.Count() < total;

            return results;
        }

        public IEnumerable<Item> GetWidgets()
        {
            IEnumerable<Item> results = Enumerable.Empty<Item>();

            if (Widgets.ListItems.Any())
            {
                results = Widgets.ListItems.FilterByContextLanguageVersion().Take(Constants.SUBTOPIC_WIDGETS_ENTRIES);
            }

            return results;
        }

        public Dictionary<string,string> GetArticleFilters()
        {
            var filters = new Dictionary<string, string>();

            filters.Add(string.Empty, DictionaryConstants.Featured);

            // Popular
            var log = new ActivityLog();
            if (log.HasPopularArticlesBySubtopic(InnerItem))
            {
                filters.Add(Guid.Empty.ToString(), DictionaryConstants.PopularLabel);
            }

            // Article type filter
            var articles = this.InnerItem
                                .Children
                                .FilterByContextLanguageVersion();
            if (articles.Any())
            {
                // Grab unique article template ids for this subtopic
                var templates = articles.Select(x => x.TemplateID)
                                    .Distinct();

                foreach (Sitecore.Data.ID templateId in templates)
                {
                    string label = DefaultArticlePageItem.GetArticleType(templateId);
                    if (!string.IsNullOrEmpty(label))
                    {
                        filters.Add(templateId.ToString(), label);
                    }
                    else
                    {
                        Sitecore.Diagnostics.Log.Info(String.Format("No article type found for template: {0}", templateId), this);
                    }
                }
            }

            return filters;
        }
    }
}