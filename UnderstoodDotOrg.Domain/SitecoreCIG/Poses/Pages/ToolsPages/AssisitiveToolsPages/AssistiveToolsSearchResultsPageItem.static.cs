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
        private static void GetMinMaxGrade(Guid gradeRangeId, out int? minGrade, out int? maxGrade)
        {
            minGrade = null;
            maxGrade = null;

            AssistiveToolsGradeRangeItem rangeItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(gradeRangeId));

            if (rangeItem != null)
            {
                minGrade = rangeItem.GradeLowerBound.Integer;
                maxGrade = rangeItem.GradeUpperBound.Integer;
            }
        }

        public static List<AssistiveToolSearchResultSet> GetGroupedSearchResults(int page, Guid? issueId = null, Guid? gradeRangeId = null, Guid? technologyId = null, 
            Guid? platformId = null, string searchTerm = null, SearchHelper.SortOptions.AssistiveToolsSortOptions sortOption = 0)
        {
            int? minGrade = null;
            int? maxGrade = null;

            if (gradeRangeId.HasValue)
            {
                GetMinMaxGrade(gradeRangeId.Value, out minGrade, out maxGrade);
            }

            return SearchHelper.GetAssitiveToolsReviewPages(page, issueId, minGrade, maxGrade, technologyId, platformId, searchTerm, sortOption);
        }

        public static IEnumerable<AssistiveToolsReviewPageItem> GetSearchResultsByCategory(int page, Guid categoryId, Guid? issueId = null, Guid? gradeRangeId = null, Guid? technologyId = null,
            Guid? platformId = null, string searchTerm = null, SearchHelper.SortOptions.AssistiveToolsSortOptions sortOption = 0)
        {
            int? minGrade = null;
            int? maxGrade = null;

            if (gradeRangeId.HasValue)
            {
                GetMinMaxGrade(gradeRangeId.Value, out minGrade, out maxGrade);
            }

            return SearchHelper.GetAssitiveToolsReviewPagesByCategory(page, categoryId, issueId, minGrade, maxGrade, technologyId, platformId, searchTerm, sortOption);
        }
    }
}