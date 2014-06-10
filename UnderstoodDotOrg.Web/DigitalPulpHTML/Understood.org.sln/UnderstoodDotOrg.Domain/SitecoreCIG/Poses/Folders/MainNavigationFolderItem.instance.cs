using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders {
    public partial class MainNavigationFolderItem {
        /// <summary>
        /// Get navigation link item
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NavigationLinkItem> GetNavigationLinkItems() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
        }

    }
}
