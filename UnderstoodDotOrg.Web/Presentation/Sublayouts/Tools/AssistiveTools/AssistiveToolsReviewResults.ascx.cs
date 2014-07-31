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
using UnderstoodDotOrg.Domain.Search;
using System.Collections.Specialized;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsReviewResults : BaseSublayout<AssistiveToolsSearchResultsPageItem>
    {
        protected SearchHelper.SortOptions.AssistiveToolsSortOptions SortOption { get; set; }
		private string _assistiveToolsGuid = string.Empty;
        AssistiveToolsSearchResultsPageItem context = (AssistiveToolsSearchResultsPageItem)Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                rptrSearchResultsSections.Visible = false;
                return;
            }

            Session["Search Query"] = Request.RawUrl;

            if(context.RelatedArticles.ListItems.Count() > 0)
            {
                rptRelatedArticles.DataSource = context.RelatedArticles.ListItems.Select(i => (DefaultArticlePageItem)i);
                rptRelatedArticles.DataBind();
            }

            var defaultSortValue = (int)SearchHelper.SortOptions.AssistiveToolsSortOptions.Relevance;
            var rawSortOption = Request.QueryString[Constants.QueryStrings.LearningTool.SortOption];
            SortOption = rawSortOption.AsEnum<SearchHelper.SortOptions.AssistiveToolsSortOptions>(defaultValue: defaultSortValue);

            IEnumerable<AssistiveToolsReviewPageItem> searchResults;

            var keyword = Request.QueryString[Constants.QueryStrings.LearningTool.Keyword];
            if (!string.IsNullOrEmpty(keyword))
            {
                hfAssistiveTechResultsKeyword.Value = keyword;
                searchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(searchTerm: keyword, sortOption: SortOption);
            }
            else
            {
                var rawIssueId = Request.QueryString[Constants.QueryStrings.LearningTool.IssueId];
                var rawGradeId = Request.QueryString[Constants.QueryStrings.LearningTool.GradeId];
                var rawTypeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId];
                var rawPlatformId = Request.QueryString[Constants.QueryStrings.LearningTool.PlatformId];

                var issueId = rawIssueId.AsNGuid();
                var gradeId = rawGradeId.AsNGuid();
                var typeId = rawTypeId.AsNGuid();
                var platformId = rawPlatformId.AsNGuid();

                if (issueId.HasValue || gradeId.HasValue || typeId.HasValue || platformId.HasValue)
                {
                    hfAssistiveTechResultsIssueId.Value = rawIssueId ?? string.Empty;
                    hfAssistiveTechResultsGradeId.Value = rawGradeId ?? string.Empty;
                    hfAssistiveTechResultsTechTypeId.Value = rawTypeId ?? string.Empty;
                    hfAssistiveTechResultsPlatformId.Value = rawPlatformId ?? string.Empty;

                    searchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(issueId, gradeId, typeId, platformId, 
                        sortOption: SortOption);
                }
                else
                {
                    rptrSearchResultsSections.Visible = false;
                    return;
                }
            }

            hfAssistiveTechResultsSortOption.Value = rawSortOption ?? string.Empty;
			
            if (!Page.IsPostBack)
            {
                var categoryResults = searchResults
                    .Where(i => i.Category.Item != null && i.Category.Item.IsOfType(AssistiveToolsCategoryItem.TemplateId))
                    .GroupBy(i => (AssistiveToolsCategoryItem)i.Category.Item, new CustomItemComparer<AssistiveToolsCategoryItem>())
                    .Select(categoryGroup =>
                    {
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

                if (categoryResults.Count() > 0)
                {
                    rptrSearchResultsSections.DataSource = categoryResults;
                    rptrSearchResultsSections.ItemDataBound += rptrSearchResultsSections_ItemDataBound;
                    rptrSearchResultsSections.DataBind();
                }
                else
                {
                    pnlNoResults.Visible = true;
                }
            }
        }

        protected void rptrSearchResultsSections_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var results = DataBinder.Eval(e.Item.DataItem, "SearchResults") as IEnumerable<AssistiveToolsReviewPageItem>;
                var rptrResults = e.FindControlAs<Repeater>("rptrResults");
                rptrResults.DataSource = results;
                rptrResults.DataBind();

                var sortOptions = EnumExtensions.GetAllItems<SearchHelper.SortOptions.AssistiveToolsSortOptions>()
                    .Select(so => new
                    {
                        Text = so.GetDescription(),
                        Value = so.ToString()
                    });
                var ddlSortOptions = e.FindControlAs<DropDownList>("ddlSortOptions");

                ddlSortOptions.DataSource = sortOptions;
                ddlSortOptions.DataTextField = "Text";
                ddlSortOptions.DataValueField = "Value";
                ddlSortOptions.DataBind();
                ddlSortOptions.SelectedValue = SortOption.ToString();
            }
        }

        protected void ddlSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlSender = sender as DropDownList;
            var selectedVal = ddlSender.SelectedValue;

            var qsCollection = new NameValueCollection(Request.QueryString);

            var currentSort = qsCollection[Constants.QueryStrings.LearningTool.SortOption];
            if (currentSort != null)
            {
                qsCollection.Remove(Constants.QueryStrings.LearningTool.SortOption);
            }
            qsCollection.Add(Constants.QueryStrings.LearningTool.SortOption, selectedVal);

            var qs = string.Join("&", qsCollection.AllKeys.Select(k => k + "=" + qsCollection[k]));
            qs = "?" + qs + (qsCollection[Constants.QueryStrings.LearningTool.Keyword] != null ? "#search-by" : string.Empty);

            Response.Redirect(Model.GetUrl() + qs);
        }

        protected void rptRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem article = (DefaultArticlePageItem)e.Item.DataItem;

                if (article != null)
                {
                    HyperLink hypArticle = e.FindControlAs<HyperLink>("hypArticle");
                    hypArticle.NavigateUrl = article.GetUrl();
                    hypArticle.Text = article.DisplayName;
                }
            }
        }
    }
}