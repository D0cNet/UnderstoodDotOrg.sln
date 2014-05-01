using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages {
    public partial class TopicLandingPageItem {

        /// <summary>
        /// Get sub topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubtopicLandingPageItem> GetSubTopicLandingPageItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(SubtopicLandingPageItem.TemplateId)).Select(i => (SubtopicLandingPageItem)i);
        }
    }
}