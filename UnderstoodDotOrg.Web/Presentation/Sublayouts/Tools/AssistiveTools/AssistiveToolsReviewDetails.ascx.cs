using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsReviewDetails : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected string[] SpelledNumbers = new [] { "zero", "one", "two", "three", "four", "five" };

        protected void Page_Load(object sender, EventArgs e) 
        {
            var screenshots = Model.Screenshots.ListItems
                .Where(i => i != null && i.Paths.IsMediaItem)
                .Select(i => (MediaItem)i);

            rptrScreenshots.DataSource = screenshots
                .Select(mi => new { Alt = mi.Alt, Url = mi.GetImageUrl() }).ToList();
            rptrScreenshots.DataBind();

            var appropriateGrades = Enumerable.Range(1, 12)
                .Select(i => new
                {
                    Grade = i,
                    Color = i <= Model.OffGrade ? "red" : i < Model.OnGrade ? "yellow" : "green"
                });

            rptrAppropriateGrades.DataSource = appropriateGrades;
            rptrAppropriateGrades.DataBind();

            var subjects = Model.Subjects.ListItems
                .Where(i => i != null && i.IsOfType(AssistiveToolsSubjectItem.TemplateId))
                .Select(i => (AssistiveToolsSubjectItem)i).ToList();

            rptrSubjects.DataSource = subjects;
            rptrSubjects.DataBind();
        }
    }
}