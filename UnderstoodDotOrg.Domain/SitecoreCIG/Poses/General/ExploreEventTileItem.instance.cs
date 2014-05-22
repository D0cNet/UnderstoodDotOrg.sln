using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class ExploreEventTileItem
    {
        public BaseEventDetailPageItem GetEvent()
        {
            var eventItem = OverrideEvent.Item;

            if (eventItem != null && eventItem.InheritsFromType(BaseEventDetailPageItem.TemplateId))
            {
                return (BaseEventDetailPageItem)eventItem;
            }
            else
            {
                return SearchHelper.GetUpcomingEvent();
            }
        }

        public string GetSubhead(BaseEventDetailPageItem eventItem)
        {
            string subhead = eventItem.SubHeading.Rendered;

            var date = eventItem.EventDate.DateTime;
            string month = date.ToString("MMM");
            string day = date.ToString("%d");
            string hour = date.ToString("h:m");
            string period = date.ToString("tt").ToLower();

            int rawDay;

            if (int.TryParse(day, out rawDay))
            {
                day = DataFormatHelper.AddOrdinal(rawDay);
            }

            string result = string.Format("{0} {1} {2} at {3}{4}", subhead, month, day, hour, period);

            return result;
        }
    }
}