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
public partial class HomeSliderFolderItem 
{
    /// <summary>
    /// Get home slider items.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<HomeSliderItem> GetHomeSliderItems() {
        return InnerItem.GetChildren().Where(i => i.IsOfType(HomeSliderItem.TemplateId)).Select(i => (HomeSliderItem)i);
    }
}
}