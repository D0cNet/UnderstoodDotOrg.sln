using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Common.Comparers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets
{
    public partial class AssistiveTool : BaseSublayout<AssistiveToolWidgetItem>
    {
        private static string AssistiveToolsGlobalsFolderId = "{493EB983-FDE9-46E4-85C8-EE45EABFE91B}";
        private Item AssistiveToolsGlobalsFolder { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();

            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindContent()
        {
            btnSubmit.Text = Model.ToolWidget.WidgetButtonText.Rendered;

            frWidgetCopy.Item = frWidgetTitle.Item = frWidgetFooterHeading.Item
                = imgFooterLogo.Item = Model;
        }

        private void BindControls()
        {
            // TODO: refactor so code can be re-used with landing page
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
                ddlIssues.Items.Insert(0, new ListItem("Select Issue", string.Empty));
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
                ddlGrades.Items.Insert(0, new ListItem("Select Grade", string.Empty));
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
                ddlTechTypes.Items.Insert(0, new ListItem("Select Technology", string.Empty));
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