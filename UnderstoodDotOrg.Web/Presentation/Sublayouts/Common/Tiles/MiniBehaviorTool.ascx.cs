using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles
{
    public partial class MiniBehaviorTool : BaseSublayout<ExploreToolTileItem>
    {
        private BehaviorToolWidgetItem _widget;

        protected void Page_Load(object sender, EventArgs e)
        {
            _widget = Model.ToolWidget.Item;
            slHeader.DataSource = Model.ID.ToString();

            // TODO: refactor - code duplicated in sidebar widget and this control
            BindContent();
            BindEvents();
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        private void BindContent()
        {
            btnSubmit.Text = _widget.ToolWidget.WidgetButtonText;
        }

        private void PopulateControls()
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

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            string challengeId = ddlChallenges.SelectedValue;
            string gradeId = ddlGrades.SelectedValue;

            string url = FormHelper.GetBehaviorResultsUrl(challengeId, gradeId);
            string widgetUrl = _widget.ToolWidget.WidgetButtonLink.Url;

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