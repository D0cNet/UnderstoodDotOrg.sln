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
            
            TyceIssues = ChildLearningIssueItem.GetChildLearningIssues().ToList();

            rptrSimulations.DataSource = TyceIssues;
            rptrSimulations.DataBind();

            var tyceGradeGroups = TYCEGradeGroupItem.GetTyceGradeGroups().ToList();

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