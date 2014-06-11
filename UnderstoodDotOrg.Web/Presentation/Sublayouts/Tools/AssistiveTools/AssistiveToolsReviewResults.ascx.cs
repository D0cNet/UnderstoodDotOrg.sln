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
                //TODO: perform keyword search
            }
            else
            {
                var issueId = Request.QueryString[Constants.QueryStrings.LearningTool.IssueId];
                var gradeLevel = Request.QueryString[Constants.QueryStrings.LearningTool.GradeLevel];
                var typeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId];

                if (!string.IsNullOrEmpty(issueId) && !string.IsNullOrEmpty(gradeLevel) && !string.IsNullOrEmpty(typeId))
                {
                    //TODO: perform browse search
                }
                else
                {
                    //TODO: Hide results sections, then return
                }
            }

            //TEMPORARY PRE-SEARCH DEVELOPMENT ONLY
            searchResults = Model.InnerItem.Parent.Children
                .Where(i => i.IsOfType(AssistiveToolsReviewPageItem.TemplateId))
                .Select(i => (AssistiveToolsReviewPageItem)i);

            var categoryResults = searchResults
                .Where(i => i.Category.Item != null && i.Category.Item.IsOfType(AssistiveToolsCategoryItem.TemplateId))
                .GroupBy(i => (AssistiveToolsCategoryItem)i.Category.Item, new CustomItemComparer<AssistiveToolsCategoryItem>())
                .Select(categoryGroup => {
                    var helpModalContent = categoryGroup.Key.HelpModalContent.Rendered;
                    var results = categoryGroup.AsEnumerable();
                    var categoryResultCount = results.Count();

                    return new 
                    {
                        CategoryTitle = categoryGroup.Key.Metadata.ContentTitle.Rendered,
                        HelpModalContent = helpModalContent,
                        ShowHelpModal = helpModalContent != string.Empty,
                        CategoryResultTotalCount = categoryResultCount,
                        CategoryResultDisplayCount = Math.Min(3, categoryResultCount),
                        SearchResults = results
                    };
                });

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