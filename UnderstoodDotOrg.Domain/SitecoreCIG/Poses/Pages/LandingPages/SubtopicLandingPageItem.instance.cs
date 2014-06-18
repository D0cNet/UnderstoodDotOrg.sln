using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class SubtopicLandingPageItem 
    {
        public IEnumerable<DefaultArticlePageItem> GetArticles(int page, out bool hasMoreResults)
        {
            var all = InnerItem.GetChildren()
                        .FilterByContextLanguageVersion()
                        .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            int pageSize = Constants.SUBTOPIC_LISTING_ARTICLES_PER_PAGE;
            int total = all.Count();
            int offset = (page - 1) * pageSize;
            
            var results = all.Skip(offset)
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
    }
}