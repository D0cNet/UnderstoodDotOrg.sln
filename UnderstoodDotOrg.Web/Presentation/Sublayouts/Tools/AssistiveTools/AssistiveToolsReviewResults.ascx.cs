﻿using System;
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
                var gradeLevel = Request.QueryString[Constants.QueryStrings.LearningTool.GradeId];
                var typeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId];

                if (!string.IsNullOrEmpty(issueId) && !string.IsNullOrEmpty(gradeLevel) && !string.IsNullOrEmpty(typeId))
                {
                    //TODO: perform browse search
                }
                else
                {
                    rptrSearchResultsSections.Visible = false;
                    return;
                }
            }

            //TEMPORARY PRE-SEARCH DEVELOPMENT ONLY
            searchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty, 1);

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