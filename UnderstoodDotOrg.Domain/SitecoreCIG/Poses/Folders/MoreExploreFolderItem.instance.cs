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
public partial class MoreExploreFolderItem 
{
    /// <summary>
    /// Get all language link item for Header
    /// </summary>
    /// <returns></returns>
    public IEnumerable<MoreExploreItem> GetMoreExploreItems() {
        return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(MoreExploreItem.TemplateId)).Select(i => (MoreExploreItem)i);
    }
}
}