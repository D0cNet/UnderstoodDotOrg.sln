using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;
using Sitecore.Data.Items;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Common.Comparers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsSearchBox : BaseSublayout<AssistiveToolsBasePageItem>
    {
        private static string AssistiveToolsGlobalsFolderId = "{493EB983-FDE9-46E4-85C8-EE45EABFE91B}";
        private Item AssistiveToolsGlobalsFolder { get; set; }
        protected string PlatformId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
				lblBrowseBy.Text = DictionaryConstants.BrowseByLabel;
				lblSearchBy.Text = DictionaryConstants.SearchLabel;

				btnBrowseFind.Text = "";
				btnSearchFind.Text = "";
                // Set selected state of dynamic dropdown
                PlatformId = Request.QueryString[Constants.QueryStrings.LearningTool.PlatformId];

                PopulateDropDowns();

                var keyword = Request.QueryString[Constants.QueryStrings.LearningTool.Keyword];
                if (!string.IsNullOrEmpty(keyword))
                {
                    tbKeywordSearch.Value = keyword;
                }
                else
                {
                    var issueId = Request.QueryString[Constants.QueryStrings.LearningTool.IssueId];
                    var gradeId = Request.QueryString[Constants.QueryStrings.LearningTool.GradeId];
                    var typeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId];
                    
                    ListItem temp;
                    if (!string.IsNullOrEmpty(issueId) && (temp = ddlIssues.Items.FindByValue(issueId)) != null)
                    {
                        temp.Selected = true;
                    }
                    if (!string.IsNullOrEmpty(gradeId) && (temp = ddlGrades.Items.FindByValue(gradeId)) != null)
                    {
                        temp.Selected = true;
                    }
                    if (!string.IsNullOrEmpty(typeId) && (temp = ddlTechTypes.Items.FindByValue(typeId)) != null)
                    {
                        temp.Selected = true;
                    }

                    if (!string.IsNullOrEmpty(PlatformId))
                    {
                        hfSelectedPlatform.Value = PlatformId;
                    }
                }
            }
        }

        protected void btnFindSubmit_Click(object sender, EventArgs e)
        {
            var btnSender = sender as Button;
            var qs = string.Empty;

            if (btnSender.ID == btnSearchFind.ID)
            {
                var keyword = tbKeywordSearch.Value;
                if (!string.IsNullOrEmpty(keyword))
                {
                    qs += Constants.QueryStrings.LearningTool.Keyword + "=" + keyword + "#search-by";
                }
            }
            else
            {
                var issueId = ddlIssues.SelectedValue;
                var gradeId = ddlGrades.SelectedValue;
                var typeId = ddlTechTypes.SelectedValue;
                var platformId = hfSelectedPlatform.Value;

                if (issueId != string.Empty)
                {
                    qs += Constants.QueryStrings.LearningTool.IssueId + "=" + issueId;
                }
                if (gradeId != string.Empty)
                {
                    qs += (qs != string.Empty ? "&" : string.Empty) + Constants.QueryStrings.LearningTool.GradeId + "=" + gradeId;
                }
                if (typeId != string.Empty)
                {
                    qs += (qs != string.Empty ? "&" : string.Empty) + Constants.QueryStrings.LearningTool.TypeId + "=" + typeId;
                }
                if (platformId != string.Empty)
                {
                    qs += (qs != string.Empty ? "&" : string.Empty) + Constants.QueryStrings.LearningTool.PlatformId + "=" + platformId;
                }
            }

            if (qs != string.Empty)
            {
                var resultsPageItem = Model.IsOfType(AssistiveToolsSearchResultsPageItem.TemplateId) ? 
                    Model.InnerItem :
                    Model.InnerItem.Children // if this isn't the results page then it must be the landing page
                        .FirstOrDefault(i => i.IsOfType(AssistiveToolsSearchResultsPageItem.TemplateId));

                if (resultsPageItem != null)
                {
                    Response.Redirect(resultsPageItem.GetUrl() + "?" + qs);
                }
            }
        }

        protected void PopulateDropDowns()
        {
            AssistiveToolsGlobalsFolder = Sitecore.Context.Database.GetItem(AssistiveToolsGlobalsFolderId);

            var issuesFolder = (AssistiveToolsIssueFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsIssueFolderItem.TemplateId));
            if (issuesFolder != null)
            {
                var issues = issuesFolder.GetIssues()
                    .Select(issue => new
                    {
                        Text = issue.Metadata.ContentTitle.Rendered,
                        Value = issue.ID.ToString()
                    });
                ddlIssues.DataSource = issues;
                ddlIssues.DataTextField = "Text";
                ddlIssues.DataValueField = "Value";
                ddlIssues.DataBind();
                ddlIssues.Items.Insert(0, new ListItem(DictionaryConstants.SelectBehaviorLabel, string.Empty));
            }

            var gradesFolder = (AssistiveToolsGradesFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsGradesFolderItem.TemplateId));
            if (gradesFolder != null)
            {
                var grades = gradesFolder.GetGradeRanges()
                    .Select(grade => new
                    {
                        Text = grade.Metadata.ContentTitle.Rendered,
                        Value = grade.ID.ToString()
                    });
                ddlGrades.DataSource = grades;
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();
                ddlGrades.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));
            }

            var typesFolder = (AssistiveToolsTypeFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsTypeFolderItem.TemplateId));
            if (typesFolder != null)
            {
                var techTypes = typesFolder.GetTechTypes()
                    .Select(grade => new
                    {
                        Text = grade.Metadata.ContentTitle.Rendered,
                        Value = grade.ID.ToString()
                    });
                ddlTechTypes.DataSource = techTypes;
                ddlTechTypes.DataTextField = "Text";
                ddlTechTypes.DataValueField = "Value";
                ddlTechTypes.DataBind();
                ddlTechTypes.Items.Insert(0, new ListItem(DictionaryConstants.AllTechnologyLabel, string.Empty));
            }

            var platformsFolder = (AssistiveToolsPlatformFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsPlatformFolderItem.TemplateId));
            if (platformsFolder != null)
            {
                var platforms = platformsFolder.GetPlatforms()
                    .Where(i => i.IsOfType(AssistiveToolsPlatformItem.TemplateId))
                    .Select(i => (AssistiveToolsPlatformItem)i)
                    .Where(platform => platform.CorrespondingType.Item != null)
                    .GroupBy(platform => platform.CorrespondingType.Item, new BaseItemComparer())
                    .Select(group => new
                    {
                        TypeId = group.Key.ID.ToString(),
                        Platforms = group.AsEnumerable()
                    });

                rptrDynPlatformDropdowns.DataSource = platforms;
                rptrDynPlatformDropdowns.ItemDataBound += rptrDynPlatformDropdowns_ItemDataBound;
                rptrDynPlatformDropdowns.DataBind();
            }
        }

        void rptrDynPlatformDropdowns_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var platforms = DataBinder.Eval(e.Item.DataItem, "Platforms") as IEnumerable<AssistiveToolsPlatformItem>;
                var rptrPlatformOptions = e.FindControlAs<Repeater>("rptrPlatformOptions");

                rptrPlatformOptions.DataSource = platforms;
                rptrPlatformOptions.DataBind();
            }
        }
    }
}