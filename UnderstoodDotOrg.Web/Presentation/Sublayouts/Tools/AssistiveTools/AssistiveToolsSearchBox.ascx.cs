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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsSearchBox : BaseSublayout<AssistiveToolsBasePageItem>
    {
        private static string AssistiveToolsGlobalsFolderId = "{493EB983-FDE9-46E4-85C8-EE45EABFE91B}";
        private Item AssistiveToolsGlobalsFolder { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

                    if (!string.IsNullOrEmpty(issueId) && !string.IsNullOrEmpty(gradeId) && !string.IsNullOrEmpty(typeId))
                    {
                        ListItem temp;
                        if ((temp = ddlIssues.Items.FindByValue(issueId)) != null)
                        {
                            temp.Selected = true;
                        }
                        if ((temp = ddlGrades.Items.FindByValue(gradeId)) != null)
                        {
                            temp.Selected = true;
                        }
                        if ((temp = ddlTechTypes.Items.FindByValue(typeId)) != null)
                        {
                            temp.Selected = true;
                        }
                    }
                }
            }
        }

        protected void btnFindSubmit_Click(object sender, EventArgs e)
        {
            var btnSender = sender as HtmlInputButton;
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
                    .Select(grade => new
                    {
                        Text = grade.Metadata.ContentTitle.Rendered,
                        Value = grade.ID.ToString()
                    });
                ddlPlatforms.DataSource = platforms;
                ddlPlatforms.DataTextField = "Text";
                ddlPlatforms.DataValueField = "Value";
                ddlPlatforms.DataBind();
                ddlPlatforms.Items.Insert(0, new ListItem("Select Platform", string.Empty));
            }
        }
    }
}