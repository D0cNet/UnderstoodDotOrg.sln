using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders {
    public partial class LanguageNavigationFolderItem {
        /// <summary>
        /// Get all language link item for Header
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LanguageLinkItem> GetLanguageLinkItems() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(LanguageLinkItem.TemplateId)).Select(i => (LanguageLinkItem)i);
        }
    }
}
