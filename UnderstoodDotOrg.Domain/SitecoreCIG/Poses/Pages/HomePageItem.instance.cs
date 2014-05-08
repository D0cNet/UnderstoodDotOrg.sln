using System.Collections.Generic;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages {
    public partial class HomePageItem {

        /// <summary>
        /// Get Page Resource Folder Item.
        /// </summary>
        /// <returns></returns>
        public PageResourceFolderItem GetPageResourceFolderItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(PageResourceFolderItem.TemplateId)).Select(i => (PageResourceFolderItem)i).FirstOrDefault();
        }



    }
}