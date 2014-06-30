using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages
{
    public partial class HomePageItem
    {
        /// <summary>
        /// Get Page Resource Folder Item.
        /// </summary>
        /// <returns></returns>
        public PageResourceFolderItem GetPageResourceFolderItem()
        {
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

        public ToolsFolderItem GetToolsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(ToolsFolderItem.TemplateId));
        }
    }
}