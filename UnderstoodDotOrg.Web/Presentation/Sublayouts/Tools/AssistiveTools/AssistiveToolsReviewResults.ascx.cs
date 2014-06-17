using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Common.Comparers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsReviewResults : BaseSublayout<AssistiveToolsSearchResultsPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<AssistiveToolsReviewPageItem> searchResults;

            var keyword = Request.QueryString[Constants.QueryStrings.LearningTool.Keyword];
            if (!string.IsNullOrEmpty(keyword))
            {
                searchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(searchTerm: keyword);
            }
            else
            {
                var issueId = Request.QueryString[Constants.QueryStrings.LearningTool.IssueId].AsNGuid();
                var gradeId = Request.QueryString[Constants.QueryStrings.LearningTool.GradeId].AsNGuid();
                var typeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId].AsNGuid();
                var platformId = Request.QueryString[Constants.QueryStrings.LearningTool.PlatformId].AsNGuid();

                if (issueId.HasValue || gradeId.HasValue || typeId.HasValue || platformId.HasValue)
                {
                    //TODO: Uncomment after completion of GetSearchResults() implementation
                    //searchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(issueId, gradeId, typeId, platformId);
                    
                    //TEMPORARY PRE-SEARCH DEVELOPMENT ONLY
                    searchResults = Model.InnerItem.Parent.Children
                        .Where(i => i.IsOfType(AssistiveToolsReviewPageItem.TemplateId))
                        .Select(i => (AssistiveToolsReviewPageItem)i);
                }
                else
                {
                    rptrSearchResultsSections.Visible = false;
                    return;
                }
            }            

            var categoryResults = searchResults
                .Where(i => i.Category.Item != null && i.Category.Item.IsOfType(AssistiveToolsCategoryItem.TemplateId))
                .GroupBy(i => (AssistiveToolsCategoryItem)i.Category.Item, new CustomItemComparer<AssistiveToolsCategoryItem>())
                .Select(categoryGroup => {
                    var helpModalContent = categoryGroup.Key.HelpModalContent.Rendered;
                    var results = categoryGroup.AsEnumerable();
                    var resultTotalCount = results.Count();
                    var resultDisplayCount = Math.Min(Constants.ASSISTIVE_TECH_ENTRIES_PER_PAGE, resultTotalCount);

                    return new 
                    {
                        CategoryId = categoryGroup.Key.ID.Guid,
                        CategoryTitle = categoryGroup.Key.Metadata.ContentTitle.Rendered,
                        HelpModalContent = helpModalContent,
                        ShowHelpModal = helpModalContent != string.Empty,
                        CategoryResultTotalCount = resultTotalCount,
                        CategoryResultDisplayCount = resultDisplayCount,
                        SearchResults = results.Take(resultDisplayCount),
                        HasMoreResults = resultDisplayCount < resultTotalCount
                    };
                })
                .OrderBy(cr => cr.CategoryTitle);

            rptrSearchResultsSections.DataSource = categoryResults;
            rptrSearchResultsSections.ItemDataBound += rptrSearchResultsSections_ItemDataBound;
            rptrSearchResultsSections.DataBind();
        }

        protected void rptrSearchResultsSections_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var results = DataBinder.Eval(e.Item.DataItem, "SearchResults") as IEnumerable<AssistiveToolsReviewPageItem>;
                var rptrResults = e.FindControlAs<Repeater>("rptrResults");
                rptrResults.DataSource = results;
                rptrResults.DataBind();
            }
        }
    }
}