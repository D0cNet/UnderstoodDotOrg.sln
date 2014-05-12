using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages
{
    public partial class BehaviorToolsResultsPageItem 
    {
        public List<NavigationLinkItem> GetRelatedArticles()
        {
            List<NavigationLinkItem> links = new List<NavigationLinkItem>();
            Item container = Sitecore.Context.Database.GetItem(Constants.BehaviorToolLandingArticlesContainer.ToString());
            if (container != null)
            {
                links = container.GetChildren().FilterByContextLanguageVersion()
                    .Where(i => i.IsOfType(NavigationLinkItem.TemplateId))
                    .Select(i => (NavigationLinkItem)i)
                    .Where(i => !String.IsNullOrEmpty(i.Link.Url))
                    .ToList();
            }

            return links;
        }
    }
}