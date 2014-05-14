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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TyceOverview : BaseSublayout
    {
        protected TyceOverviewPageItem PageItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageItem = (TyceOverviewPageItem)Sitecore.Context.Item;
            
            //TODO: change the below to a CIG logical method after more appropriate folder templates are created
            var tyceIssuesFolder = Sitecore.Context.Database.GetItem("{FFC2C76F-4E6C-458F-9E70-4273F562D243}");
            var tyceIssues = tyceIssuesFolder.Children
                .Where(i => i != null && i.IsOfType(ChildLearningIssueItem.TemplateId))
                .Select(i => (ChildLearningIssueItem)i).ToList();

            //TODO: Add logic for getting Navigate URL
            //TODO: Add children's stories section
            //TODO: Add logic for populating children in modal

            rptrSimulations.DataSource = tyceIssues;
            rptrSimulations.DataBind();

            lbLetsGo.Click += lbLetsGo_Click;
        }

        protected void lbLetsGo_Click(object sender, EventArgs e)
        {
            var questionsPageItem = Sitecore.Context.Item.Children
                .FirstOrDefault(i => i.IsOfType(TyceQuestionsPageItem.TemplateId));

            if (questionsPageItem != null)
            {
                Response.Redirect(questionsPageItem.GetUrl());
                //TODO: Add logic for handling passing selected child to questions page
            }
        }
    }
}