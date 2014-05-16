using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TyceNextSteps : BaseSublayout
    {
        protected TyceNextStepsPageItem PageItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageItem = (TyceNextStepsPageItem)Sitecore.Context.Item;

            var simhist = Request.QueryString["simhist"];
            if (!string.IsNullOrEmpty(simhist))
            {
                var issueIds = simhist.Split(',');
                var issues = issueIds
                    .Select(id => Sitecore.Context.Database.GetItem(id))
                    .Where(i => i != null)
                    .Select(i => (ChildLearningIssueItem)i).ToList();

                rptrIssuesSeen.DataSource = issues;
                rptrIssuesSeen.DataBind();
            }

            var schools = PageItem.SchoolContributions.ListItems
                .Where(i => i != null)
                .Select(i => (EducationalInstitutionItem)i).ToList();

            rptrSchools.DataSource = schools;
            rptrSchools.DataBind();
        }
    }
}