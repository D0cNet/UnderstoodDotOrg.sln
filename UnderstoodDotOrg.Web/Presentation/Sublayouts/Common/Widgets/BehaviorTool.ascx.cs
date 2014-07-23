using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets
{
    public partial class BehaviorTool : BaseSublayout<BehaviorToolWidgetItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
            
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        private void BindContent()
        {
            btnSubmit.Text = Model.ToolWidget.WidgetButtonText.Rendered;
            frWidgetCopy.Item = frWidgetTitle.Item = Model;
        }

        private void BindControls()
        {
            BehaviorToolsLandingPageItem landingPage = Sitecore.Context.Database.GetItem(Constants.BehaviorToolLandingArticlesContainer);
            if (landingPage != null)
            {
                ddlGrades.DataSource = landingPage.GetGradeChoices();
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();

                if (IsUserLoggedIn)
                {
                    var youngestGrade = CurrentMember.Children
                        .Select(child => child.Grades.FirstOrDefault())
                        .Where(grade => grade != null)
                        .Select(grade => Sitecore.Context.Database.GetItemAs<GradeLevelItem>(grade.Key))
                        .OrderBy(gradeItem => gradeItem.GradeNumber.Integer)
                        .FirstOrDefault();
                    if (youngestGrade != null)
                    {
                        ddlGrades.SelectedValue = youngestGrade.ID.ToString();
                    }
                }
            }

            var issues = FormHelper.GetChallenges(DictionaryConstants.SelectChallengeLabel);
            if (issues.Any())
            {
                ddlChallenges.DataSource = issues;
                ddlChallenges.DataTextField = "Text";
                ddlChallenges.DataValueField = "Value";
                ddlChallenges.DataBind();
            }
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            string challengeId = ddlChallenges.SelectedValue;
            string gradeId = ddlGrades.SelectedValue;

            string url = FormHelper.GetBehaviorResultsUrl(challengeId, gradeId);
            string widgetUrl = Model.ToolWidget.WidgetButtonLink.Url;

            // TODO: add validation

            if (!string.IsNullOrEmpty(challengeId) && !string.IsNullOrEmpty(gradeId))
            {
                // Override constant based URL
                if (!string.IsNullOrEmpty(widgetUrl))
                {
                    Response.Redirect(FormHelper.GetBehaviorResultsUrl(widgetUrl, challengeId, gradeId));
                }

                Response.Redirect(url);
            }
        }
    }
}