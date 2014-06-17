using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class SectionLandingPageItem
    {

        /// <summary>
        /// Get topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TopicLandingPageItem> GetTopicLandingPageItem()
        {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(TopicLandingPageItem.TemplateId)).Select(i => (TopicLandingPageItem)i);
        }

        public IEnumerable<Item> GetToolWidgets()
        {
            IEnumerable<Item> results = Enumerable.Empty<Item>();

            var items = ToolWidgets.ListItems;
            if (items.Any())
            {
                results = items.Where(i => i.InheritsTemplate(ToolWidgetItem.TemplateId)).Take(3);
            }

            return results;
        }

    }
}