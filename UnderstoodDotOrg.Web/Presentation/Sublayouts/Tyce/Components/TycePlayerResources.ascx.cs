using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.CSS;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.JS;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePlayerResources : BaseSublayout
    {
        protected string JSResources { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var homepageUrl = MainsectionItem.GetHomePageItem().GetUrl();
            var simq = Request.QueryString["simq"];
            if (!string.IsNullOrEmpty(simq))
            {
                var issueId = simq.Split(',').First();
                ChildLearningIssueItem issueItem = Sitecore.Context.Database.GetItem(issueId);
                if (issueItem != null)
                {
                    JSResources = string.Empty;
                    issueItem.SimulationJS.ListItems
                        .Where(i => i != null)
                        .Select(i => (JSItem)i).ToList()
                        .ForEach(jsItem => 
                            JSResources += "<script type='text/javascript' src='" + jsItem.JSFilepath + jsItem.JSFilename + "'></script>");

                    issueItem.SimulationCSS.ListItems
                        .Where(i => i != null)
                        .Select(i => (CSSItem)i).ToList()
                        .ForEach(cssItem => Page.Header.Controls.Add(
                            new Literal()
                            {
                                Text = "<link rel='stylesheet' href='" + cssItem.CSSFilepath + cssItem.CSSFilename + "' />"
                            }));
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