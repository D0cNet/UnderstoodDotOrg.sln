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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePlayerResources : BaseSublayout<TycePlayerPageItem>
    {
        protected string JSResources { get; set; }
        protected ChildLearningIssueItem IssueItem { get; set; }
        protected string NextPagePath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var homepageUrl = MainsectionItem.GetHomePageItem().GetUrl();
            var simq = Request.QueryString["simq"];
            if (!string.IsNullOrEmpty(simq))
            {
                var simIds = simq.Split(',');
                if (!simIds.Any())
                {
                    return;
                }

                var issueId = simIds.First();

                if (simIds.Count() > 1)
                {
                    NextPagePath = Request.Url.GetLeftPart(UriPartial.Path) + "?";
                    var nextSimIds = simIds.Skip(1);

                    NextPagePath += string.Join("&", nextSimIds.Select(sid => "simq=" + sid));
                }
                else
                {
                    var nextStepsPage = Model.InnerItem.Parent.Children
                        .FirstOrDefault(i => i.IsOfType(TyceNextStepsPageItem.TemplateId));
                    if (nextStepsPage != null)
                    {
                        NextPagePath = nextStepsPage.GetUrl() + "?";
                    }
                    else
                    {
                        Response.Redirect(homepageUrl);
                    }
                }

                var simHist = Request.QueryString["simhist"];
                if (!string.IsNullOrEmpty(simHist))
                {
                    var histIds = simHist.Split(',');
                    NextPagePath += "&" + string.Join("&", histIds.Select(hid => "simhist=" + hid));
                }

                NextPagePath += "&simhist=" + issueId;
                
                IssueItem = Sitecore.Context.Database.GetItem(issueId);
                if (IssueItem != null)
                {
                    JSResources = string.Empty;
                    IssueItem.SimulationJS.ListItems
                        .Where(i => i != null)
                        .Select(i => (JSItem)i).ToList()
                        .ForEach(jsItem => 
                            JSResources += "<script type='text/javascript' src='" + jsItem.JSFilepath + jsItem.JSFilename + "'></script>");

                    IssueItem.SimulationCSS.ListItems
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