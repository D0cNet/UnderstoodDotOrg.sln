using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages {
    public partial class ExpertLivePageItem {
        /// <summary>
        /// Get archive items.
        /// </summary>
        /// <returns></returns>
        public ArchiveItem GetArchiveItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(ArchiveItem.TemplateId)).Select(i => (ArchiveItem)i).FirstOrDefault();
        }
    }
}