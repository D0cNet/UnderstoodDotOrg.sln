using System.Collections.Generic;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class PageResourceFolderItem 
{
    /// <summary>
    /// Get Home Slider Folder Item.
    /// </summary>
    /// <returns></returns>
    public HomeSliderFolderItem GetHomeSliderFolderItem() {
        return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(HomeSliderFolderItem.TemplateId)).Select(i => (HomeSliderFolderItem)i).FirstOrDefault();
    }

}
}