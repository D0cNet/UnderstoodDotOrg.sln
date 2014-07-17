using System;
using Sitecore.Data.Items;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
    public partial class AssistiveToolsSearchResultsPageItem
    {
        public static IEnumerable<AssistiveToolsReviewPageItem> GetSearchResults(Guid? issueId = null, Guid? gradeRangeId = null, Guid? technologyId = null, 
            Guid? platformId = null, string searchTerm = null, int page = 1, SearchHelper.SortOptions.AssistiveToolsSortOptions sortOption = 0)
        {
            int? minGrade = null;
            int? maxGrade = null;

            // Lookup grade range in Sitecore
            if (gradeRangeId.HasValue)
            {
                AssistiveToolsGradeRangeItem rangeItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(gradeRangeId));

                if (rangeItem != null)
                {
                    minGrade = rangeItem.GradeLowerBound.Integer;
                    maxGrade = rangeItem.GradeUpperBound.Integer;
                }
            }

            return SearchHelper.GetAssitiveToolsReviewPages(issueId, minGrade, maxGrade, technologyId, platformId, searchTerm, page, sortOption);
        }
    }
}