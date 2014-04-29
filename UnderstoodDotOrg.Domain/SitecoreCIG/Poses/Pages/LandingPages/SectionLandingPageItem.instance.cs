using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
public partial class SectionLandingPageItem 
{
    
        /// <summary>
        /// Get topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TopicLandingPageItem> GetTopicLandingPageItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(TopicLandingPageItem.TemplateId)).Select(i => (TopicLandingPageItem)i);
        }

}
}