using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TycePlayer : BaseSublayout<TycePlayerPageItem>
    {
        protected ChildLearningIssueItem IssueItem { get; set; }
        protected bool IsPersonalized { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var standalone = Request.QueryString["standalone"];
            IsPersonalized = string.IsNullOrEmpty(standalone) || standalone.ToLower() != bool.TrueString.ToLower();

            var simq = Request.QueryString["simq"];
            if (!string.IsNullOrEmpty(simq))
            {
                var simIds = simq.Split(',');
                if (!simIds.Any())
                {
                    return;
                }

                var issueId = simIds.First();
                IssueItem = Sitecore.Context.Database.GetItem(issueId);
            }

            if (IssueItem == null)
            {
                Response.Redirect(MainsectionItem.GetHomePageItem().GetUrl());
            }
        }
    }
}