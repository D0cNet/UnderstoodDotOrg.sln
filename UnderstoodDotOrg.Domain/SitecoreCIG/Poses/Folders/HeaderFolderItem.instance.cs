using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders {
    public partial class HeaderFolderItem {
        /// <summary>
        /// Get language navigation folder
        /// </summary>
        /// <returns></returns>
        private LanguageNavigationFolderItem GetLanguageNavigationFolder() {
            return (LanguageNavigationFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(LanguageNavigationFolderItem.TemplateId)).FirstOrDefault();
        }

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
        /// Get parent toolkit folder
        /// </summary>
        /// <returns></returns>
        public ParentToolkitFolderItem GetParentToolkitFolder() {
            return (ParentToolkitFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(ParentToolkitFolderItem.TemplateId)).FirstOrDefault();
        }

		private IEnumerable<LanguageLinkItem> _languageLinks;
		public IEnumerable<LanguageLinkItem> GetLanguageLinks()
		{
			if (_languageLinks == null)
			{
				LanguageNavigationFolderItem languageFolder = this.GetLanguageNavigationFolder();

				if (languageFolder != null)
				{
					_languageLinks = languageFolder.GetLanguageLinkItems();
				}
			}

			return _languageLinks;
		}
    }
}
