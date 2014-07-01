using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TyceQuestions : BaseSublayout<TyceQuestionsPageItem>
    {
        protected List<Guid> PresetIssues { get; set; }
        protected Guid? PresetGrade { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var simq = Request.QueryString["simq"];
            PresetIssues = string.IsNullOrEmpty(simq) ?
                new List<Guid>() :
                simq.Split(',')
                    .Select(s => s.AsNGuid())
                    .Where(ng => ng.HasValue)
                    .Select(ng => ng.Value).ToList();

            var gradeId = Request.QueryString["gradeId"];
            PresetGrade = gradeId.AsNGuid();

            var tyceGrades = ChildGradeItem.GetChildGrades();

            rptrGradeOptions.DataSource = tyceGrades;
            rptrGradeOptions.DataBind();

            rptrGradeButtons.DataSource = tyceGrades;
            rptrGradeButtons.DataBind();
            
            var tyceIssues = ChildLearningIssueItem.GetChildLearningIssues()
                .Select(issueItem => new
                {
                    Id = issueItem.ID.Guid,
                    Title = issueItem.ChildDemographic.Title.Rendered,
                    Abstract = issueItem.ChildDemographic.Abstract.Rendered,
                    CssClass = issueItem.ChildDemographic.CssClass.Raw
                }).ToList();

            rptrChildIssues.DataSource = tyceIssues;
            rptrChildIssues.DataBind();

            rptrIssueSummaries.DataSource = tyceIssues;
            rptrIssueSummaries.DataBind();
        }

        protected void btnStartSimulation_Click(object sender, EventArgs e)
        {
            var playerItem = Sitecore.Context.Item.Parent.Children
                .First(i => i.IsOfType(TycePlayerPageItem.TemplateId));
            var url = playerItem.GetUrl() + "?simq=" + hfIssueIds.Value + "&gradeId=" + hfGradeId.Value;

            Response.Redirect(url);
        }
    }
}