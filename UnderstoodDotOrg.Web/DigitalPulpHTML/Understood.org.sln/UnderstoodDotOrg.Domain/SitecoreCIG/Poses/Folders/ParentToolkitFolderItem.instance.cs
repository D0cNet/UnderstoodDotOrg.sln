using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class ParentToolkitFolderItem 
{
    /// <summary>
    /// Get navigation link item
    /// </summary>
    /// <returns></returns>
    public IEnumerable<NavigationLinkItem> GetNavigationLinkItems() {
        return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
    }
}
}