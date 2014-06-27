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
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TyceOverview : BaseSublayout<TyceOverviewPageItem>
    {
        private string HomepageUrl { get; set; }

        protected TyceOverviewPageItem PageItem { get; set; }
        protected TyceQuestionsPageItem QuestionsPageItem { get; set; }
        protected TycePlayerPageItem PlayerPageItem { get; set; }

        protected List<ChildLearningIssueItem> TyceIssues { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HomepageUrl = MainsectionItem.GetHomePageItem().GetUrl();

            QuestionsPageItem = Model.TyceBasePage.GetQuestionsPage();
            PlayerPageItem = Model.TyceBasePage.GetPlayerPage();
            
            //TODO: change the below to a CIG logical method after more appropriate folder templates are created
            var tyceIssuesFolder = Sitecore.Context.Database.GetItem("{FFC2C76F-4E6C-458F-9E70-4273F562D243}");
            TyceIssues = tyceIssuesFolder.Children
                .Where(i => i.IsOfType(ChildLearningIssueItem.TemplateId))
                .Select(i => (ChildLearningIssueItem)i).ToList();

            rptrSimulations.DataSource = TyceIssues;
            rptrSimulations.DataBind();

            //TODO: Update logic for getting Navigate URL
            //TODO: Add children's stories section
            //TODO: Add logic for populating children in modal

            var tyceGradeGroupsFolder = Sitecore.Context.Database.GetItem("{2D928CD4-E518-4BF3-A3D6-49FEDB1D89F6}");
            var tyceGradeGroups = tyceGradeGroupsFolder.Children
                .Where(i => i.IsOfType(TYCEGradeGroupItem.TemplateId))
                .Select(i => (TYCEGradeGroupItem)i).ToList();

            rptrChildStoryTabs.DataSource = tyceGradeGroups;
            rptrChildStoryTabs.DataBind();

            rptrChildStories.DataSource = tyceGradeGroups;
            rptrChildStories.ItemDataBound += rptrChildStories_ItemDataBound;
            rptrChildStories.DataBind();
        }

        void rptrChildStories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var gradeGroup = e.Item.DataItem as TYCEGradeGroupItem;
                var grades = gradeGroup.Grades.ListItems;
                if (!grades.Any()) {
                    Response.Redirect(HomepageUrl);
                }

                var inRangeGradeId = grades.First().ID.Guid;
                var issues = TyceIssues
                    .Select(ti => new
                    {
                        Issue = ti,
                        InRangeGradeId = inRangeGradeId
                    });

                var rptrIssues = e.FindControlAs<Repeater>("rptrIssues");
                rptrIssues.DataSource = issues;
                rptrIssues.DataBind();
            }
        }
    }
}