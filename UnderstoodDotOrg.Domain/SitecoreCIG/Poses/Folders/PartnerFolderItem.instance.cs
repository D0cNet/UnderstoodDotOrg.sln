using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders {
    public partial class PartnerFolderItem {
        /// <summary>
        /// Get navigation link item
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NavigationLinkItem> GetNavLinkItems() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
        }
    }
}
