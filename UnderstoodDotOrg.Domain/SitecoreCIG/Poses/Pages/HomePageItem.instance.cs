using System.Collections.Generic;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages {
    public partial class HomePageItem {

        /// <summary>
        /// Get Page Resource Folder Item.
        /// </summary>
        /// <returns></returns>
        public PageResourceFolderItem GetPageResourceFolderItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(PageResourceFolderItem.TemplateId)).Select(i => (PageResourceFolderItem)i).FirstOrDefault();
        }

        public MyAccountFolderItem GetMyAccountFolder()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(MyAccountFolderItem.TemplateId));
        }

        public AboutUnderstoodItem GetAboutPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AboutUnderstoodItem.TemplateId));
        }
    }
}