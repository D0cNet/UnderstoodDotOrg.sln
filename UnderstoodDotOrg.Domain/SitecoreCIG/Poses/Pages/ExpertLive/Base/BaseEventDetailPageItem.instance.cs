using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base
{
    public partial class BaseEventDetailPageItem 
    {
        public string GetFormattedEventDate()
        {
            DateTime eventDate = EventDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                TimeZoneItem timezone = Timezone.Item;
                string zoneLabel = (timezone != null) ? timezone.Abbreviation.Rendered : string.Empty;

                string meridian = eventDate.ToString("tt").ToLower();

                return String.Format("{0:ddd MMM dd} at {0:hh:mm}{1} {2}", eventDate, meridian, zoneLabel);
            }

            return String.Empty;
        }

        public bool IsUpcoming()
        {
            DateTime? utc = GetEventDateUtc();
            if (utc.HasValue)
            {
                return utc.Value > DateTime.UtcNow;
            }

            return false;
        }

        public DateTime? GetEventDateUtc()
        {
            DateTime? result = null;

            TimeZoneItem tz = Timezone.Item;
            DateTime eventDate = EventDate.DateTime;

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