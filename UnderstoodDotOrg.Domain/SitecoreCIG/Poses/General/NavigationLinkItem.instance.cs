using System;
using Sitecore.Data.Items;
using System.Linq;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class NavigationLinkItem
    {
        public IEnumerable<NavigationLinkItem> GetNavigationLinkItems()
        {
            return InnerItem.Children.FilterByContextLanguageVersion()
                .Where(i => i.IsOfType(NavigationLinkItem.TemplateId))
                .Select(i => (NavigationLinkItem)i);
        }
    }
}