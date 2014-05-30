using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base
{
    public partial class BaseEventDetailPageItem 
    {
        public string GetFormattedEventStartDate()
        {
            DateTime eventDate = EventStartDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                TimeZoneItem timezone = EventTimezone.Item;
                string zoneLabel = (timezone != null) ? timezone.Abbreviation.Rendered : string.Empty;

                string meridian = eventDate.ToString("tt").ToLower();

                return String.Format("{0:ddd MMM dd} at {0:hh:mm}{1} {2}", eventDate, meridian, zoneLabel);
            }

            return String.Empty;
        }

        public string GetFormattedArchiveEventDate()
        {
            DateTime? eventDate = GetEventStartDateUtc();
            if (eventDate.HasValue && eventDate.Value != DateTime.MinValue)
            {
                int daysElapsed = (DateTime.UtcNow - eventDate.Value).Days;
                if (daysElapsed > 0 && daysElapsed <= 30)
                {
                    return String.Format("{0} {1}", daysElapsed, DictionaryConstants.DaysAgoLabel);
                }
                else
                {
                    return eventDate.Value.ToString("MMM dd yyyy");
                }
            }

            return String.Empty;
        }

        public bool IsUpcoming()
        {
            DateTime? utc = GetEventEndDateUtc();
            if (utc.HasValue)
            {
                return utc.Value > DateTime.UtcNow;
            }

            return false;
        }

        public DateTime? GetEventStartDateUtc()
        {
            return GetUtcDate(EventStartDate);
        }

        public DateTime? GetEventEndDateUtc()
        {
            return GetUtcDate(EventEndDate);
        }

        private DateTime? GetUtcDate(CustomDateField dateField)
        {
            DateTime? result = null;

            TimeZoneItem tz = EventTimezone.Item;
            DateTime eventDate = dateField.DateTime;

            if (tz != null && eventDate != DateTime.MinValue)
            {
                // Ensure timezone is unspecified before converting to UTC
                eventDate = DateTime.SpecifyKind(eventDate, DateTimeKind.Unspecified);

                try
                {
                    TimeZoneInfo eventTimezone = TimeZoneInfo.FindSystemTimeZoneById(tz.Timezone.Raw);

                    DateTime eventUtcDate = TimeZoneInfo.ConvertTimeToUtc(eventDate, eventTimezone);

                    result = eventUtcDate;
                }
                catch { }
            }

            return result;
        }
    }
}