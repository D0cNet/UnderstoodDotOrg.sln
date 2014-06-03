using System;
using System.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class ExpertLandingPageItem 
    {
        public static IEnumerable<ExpertDetailPageItem> GetExperts(int page, out bool hasMoreResults)
        {
            IEnumerable<ExpertDetailPageItem> results = Enumerable.Empty<ExpertDetailPageItem>();
            int pageSize = Constants.EXPERT_LISTING_ENTRIES_PER_PAGE;

            hasMoreResults = false;

            Item container = Sitecore.Context.Database.GetItem(Constants.Pages.ExpertLanding);
            if (container != null)
            {
                int offset = (page - 1) * pageSize;

                var all = container.Children.FilterByContextLanguageVersion()
                                .Where(i => i.IsOfType(ExpertDetailPageItem.TemplateId))
                                .Select(i => new ExpertDetailPageItem(i));

                results = all.Skip(offset).Take(pageSize);

                int total = all.Count();
                hasMoreResults = (offset) + results.Count() < total;
            }

            return results;
        }
    }
}