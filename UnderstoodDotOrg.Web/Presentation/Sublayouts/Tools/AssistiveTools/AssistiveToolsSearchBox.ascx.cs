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
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsSearchBox : BaseSublayout<AssistiveToolsBasePageItem>
    {
        private Item AssistiveToolsGlobalsFolder
        {
            get;
            set;
        }
        protected string PlatformId
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Language.Name == "es-MX")
            {
                frNoSpanishWarning.Item = MainsectionItem.GetHomePageItem().GetToolsPage().GetAssistiveToolsLandingPage().GetSearchPage();
                pnlNotInSpansih.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                lblBrowseBy.Text = DictionaryConstants.BrowseByLabel;
                lblSearchBy.Text = DictionaryConstants.SearchByLabel;

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
                if (typeId != string.Empty && typeId != "All")
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
            AssistiveToolsGlobalsFolder = Sitecore.Context.Database.GetItem(Constants.AssistiveToolsGlobalContainer);

            var issuesFolder = (AssistiveToolsIssueFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsIssueFolderItem.TemplateId));

            var issues = issuesFolder.GetIssues()
                .Select(issue => new
                {
                    Text = issue.Metadata.ContentTitle.Raw,
                    Value = issue.ID.ToString()
                });
            ddlIssues.DataSource = issues;
            ddlIssues.DataTextField = "Text";
            ddlIssues.DataValueField = "Value";
            ddlIssues.DataBind();
            ddlIssues.Items.Insert(0, new ListItem(DictionaryConstants.SelectBehaviorLabel, string.Empty));

            var gradesFolder = (AssistiveToolsGradesFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsGradesFolderItem.TemplateId));
            var grades = gradesFolder.GetGradeRanges()
                .Select(grade => new
                {
                    Text = grade.Metadata.ContentTitle.Raw,
                    Value = grade.ID.ToString()
                });
            ddlGrades.DataSource = grades;
            ddlGrades.DataTextField = "Text";
            ddlGrades.DataValueField = "Value";
            ddlGrades.DataBind();
            ddlGrades.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            var typesFolder = (AssistiveToolsTypeFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsTypeFolderItem.TemplateId));
            var techTypeItems = typesFolder.GetTechTypes();

            var techTypes = techTypeItems
                .Select(techType => new
                {
                    Text = techType.Metadata.ContentTitle.Raw,
                    Value = techType.ID.ToString()
                });
            ddlTechTypes.DataSource = techTypes;
            ddlTechTypes.DataTextField = "Text";
            ddlTechTypes.DataValueField = "Value";
            ddlTechTypes.DataBind();
            ddlTechTypes.Items.Insert(0, new ListItem(DictionaryConstants.AllTechnologyLabel, "All"));
            ddlTechTypes.Items.Insert(0, new ListItem(DictionaryConstants.SelectTechnologyLabel, string.Empty));

            var platformsFolder = (AssistiveToolsPlatformFolderItem)AssistiveToolsGlobalsFolder.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsPlatformFolderItem.TemplateId));
            var platformItems = platformsFolder.GetPlatforms();

            var platforms = techTypeItems
                .Select(techType => new
                {
                    TypeId = techType.ID.ToString(),
                    Platforms = platformItems
                        .Where(platform => platform.CorrespondingTypes.ListItems.Contains(techType.InnerItem, new BaseItemComparer()))
                });

            rptrDynPlatformDropdowns.DataSource = platforms;
            rptrDynPlatformDropdowns.ItemDataBound += rptrDynPlatformDropdowns_ItemDataBound;
            rptrDynPlatformDropdowns.DataBind();
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