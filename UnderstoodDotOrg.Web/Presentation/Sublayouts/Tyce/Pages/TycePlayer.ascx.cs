using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.JS;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.CSS;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TycePlayer : BaseSublayout
    {
        protected string Resources { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var homepageUrl = MainsectionItem.GetHomePageItem().GetUrl();
            var simq = Request.QueryString["simq"];
            if (!string.IsNullOrEmpty(simq))
            {
                var issueId = simq.Split(',').First();
                ChildLearningIssueItem issueItem = Sitecore.Context.Database.GetItem(issueId);
                if (issueItem == null)
                {
                    Resources = string.Empty;
                    issueItem.SimulationJS.ListItems
                        .Where(i => i != null)
                        .Select(i => (JSItem)i).ToList()
                        .ForEach(jsItem => 
                            Resources += "<script type='text/javascript' src='" + jsItem.JSFilename + jsItem.JSFilepath + "'></script>");
                    
                    issueItem.SimulationCSS.ListItems
                        .Where(i => i != null)
                        .Select(i => (CSSItem)i).ToList()
                        .ForEach(cssItem =>
                            Resources += "<link rel='stylesheet' href='" + cssItem.CSSFilename + cssItem.CSSFilepath + "' />");
                }
                else
                {
                    Response.Redirect(homepageUrl);
                }
            }
            else
            {
                Response.Redirect(homepageUrl);
            }
        }
    }
}