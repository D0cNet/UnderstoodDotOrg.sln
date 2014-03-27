using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders {
    public partial class SocialMediaFolderItem {
        /// <summary>
        /// Get navigation link item
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SocialMediaItem> GetSocialMediaItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(SocialMediaItem.TemplateId)).Select(i => (SocialMediaItem)i);
        }
    }
}
