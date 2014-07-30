using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Comparers;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles
{
    public partial class MiniAssistiveTool : BaseSublayout<ExploreToolTileItem>
    {
        private AssistiveToolWidgetItem _widget;

        protected void Page_Load(object sender, EventArgs e)
        {
            _widget = Model.ToolWidget.Item;
            slHeader.DataSource = Model.ID.ToString();

            // TODO: refactor this mini widget and sidebar widget as code is cut/pasted from assitive tech landing page
            BindContent();
            BindEvents();
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindContent()
        {
            btnSubmit.Text = _widget.ToolWidget.WidgetButtonText.Raw;
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        private void BindControls()
        {
            // TODO: refactor so code can be re-used with landing page and sidebar widget
            var folder = Sitecore.Context.Database.GetItem(Constants.AssistiveToolsGlobalContainer);

            var issuesFolder = (AssistiveToolsIssueFolderItem)folder.Children
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

            var gradesFolder = (AssistiveToolsGradesFolderItem)folder.Children
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

            var typesFolder = (AssistiveToolsTypeFolderItem)folder.Children
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

            var platformsFolder = (AssistiveToolsPlatformFolderItem)folder.Children
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

        void btnSubmit_Click(object sender, EventArgs e)
        {
            var issueId = ddlIssues.SelectedValue;
            var gradeId = ddlGrades.SelectedValue;
            var typeId = ddlTechTypes.SelectedValue;
            var platformId = hfSelectedPlatform.Value;

            var qs = new Dictionary<string, string>();
            if (issueId != string.Empty)
            {
                qs.Add(Constants.QueryStrings.LearningTool.IssueId, issueId);
            }
            if (gradeId != string.Empty)
            {
                qs.Add(Constants.QueryStrings.LearningTool.GradeId, gradeId);
            }
            if (typeId != string.Empty)
            {
                qs.Add(Constants.QueryStrings.LearningTool.TypeId, typeId);
            }
            if (platformId != string.Empty)
            {
                qs.Add(Constants.QueryStrings.LearningTool.PlatformId, platformId);
            }

            // Lookup destination url on linked widget
            string url = _widget.GetSearchResultsUrl();
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(HttpHelper.AssembleUrl(url, qs));
            }
        }
    }
}