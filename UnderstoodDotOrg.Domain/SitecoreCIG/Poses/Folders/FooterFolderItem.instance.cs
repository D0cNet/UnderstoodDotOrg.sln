using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class FooterFolderItem
    {
        /// <summary>
        /// Get main navigation folder
        /// </summary>
        /// <returns></returns>
        public MainNavigationFolderItem GetMainNavigationFolder() {
            return (MainNavigationFolderItem)InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(MainNavigationFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get utility navigation folder
        /// </summary>
        /// <returns></returns>
        public UtilityNavigationFolderItem GetUtilityNavigationFolder() {
            return (UtilityNavigationFolderItem)InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(UtilityNavigationFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get social media folder
        /// </summary>
        /// <returns></returns>
        public SocialMediaFolderItem GetSocialMediaFolder() {
            return (SocialMediaFolderItem)InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(SocialMediaFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get partner folder
        /// </summary>
        /// <returns></returns>
        public List<PartnerInfoItem> GetPartnerLinks() {
            List<PartnerInfoItem> results = new List<PartnerInfoItem>();
            Item container = Sitecore.Context.Database.GetItem(Constants.Pages.Partners);
            if (container != null)
            {
                return container.GetChildren().FilterByContextLanguageVersion()
                            .Where(i => i.IsOfType(PartnerInfoItem.TemplateId))
                            .Select(i => new PartnerInfoItem(i))
                            .Where(i => i.PartnerLogo.MediaItem != null)
                            .ToList();
            }
            return results;
        }
    }
}
