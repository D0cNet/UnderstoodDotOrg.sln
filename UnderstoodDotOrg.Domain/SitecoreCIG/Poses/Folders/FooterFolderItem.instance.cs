using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class FooterFolderItem
    {
        /// <summary>
        /// Get main navigation folder
        /// </summary>
        /// <returns></returns>
        public MainNavigationFolderItem GetMainNavigationFolder() {
            return (MainNavigationFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(MainNavigationFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get utility navigation folder
        /// </summary>
        /// <returns></returns>
        public UtilityNavigationFolderItem GetUtilityNavigationFolder() {
            return (UtilityNavigationFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(UtilityNavigationFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get social media folder
        /// </summary>
        /// <returns></returns>
        public SocialMediaFolderItem GetSocialMediaFolder() {
            return (SocialMediaFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(SocialMediaFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get partner folder
        /// </summary>
        /// <returns></returns>
        public PartnerFolderItem GetPartnerFolder() {
            return (PartnerFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(PartnerFolderItem.TemplateId)).FirstOrDefault();
        }
    }
}
