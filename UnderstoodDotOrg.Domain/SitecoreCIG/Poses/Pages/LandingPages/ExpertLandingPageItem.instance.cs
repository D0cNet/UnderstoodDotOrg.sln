using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class ExpertLandingPageItem
    {
        /// <summary>
        /// Get topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpertDetailPageItem> GetExpertDetailPages(Item item) {
            return item.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(ExpertDetailPageItem.TemplateId)).Select(i => (ExpertDetailPageItem)i);
        }
    }
}