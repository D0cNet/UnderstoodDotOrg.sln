﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            var simq = Request.QueryString["simq"];
            PresetIssues = string.IsNullOrEmpty(simq) ?
                new List<Guid>() :
                simq.Split(',')
                    .Select(s => s.AsNGuid())
                    .Where(ng => ng.HasValue)
                    .Select(ng => ng.Value).ToList();

            //TODO: change the below to a CIG logical method after more appropriate folder templates are created
            var tyceGradesFolder = Sitecore.Context.Database.GetItem("{17BF4487-9EC2-4434-A86E-B27D41CC3BC7}");
            var tyceGrades = tyceGradesFolder.Children
                .Where(i => i != null && i.IsOfType(ChildGradeItem.TemplateId))
                .Select(i => (ChildGradeItem)i).ToList();

            rptrGradeOptions.DataSource = tyceGrades;
            rptrGradeOptions.DataBind();

            rptrGradeButtons.DataSource = tyceGrades;
            rptrGradeButtons.DataBind();
            
            //TODO: change the below to a CIG logical method after more appropriate folder templates are created
            var tyceIssuesFolder = Sitecore.Context.Database.GetItem("{FFC2C76F-4E6C-458F-9E70-4273F562D243}");
            var tyceIssues = tyceIssuesFolder.Children
                .Where(i => i != null && i.IsOfType(ChildLearningIssueItem.TemplateId))
                .Select(i => (ChildLearningIssueItem)i)
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