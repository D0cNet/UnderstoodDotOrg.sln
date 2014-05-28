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
        public string GetExpertThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = null;
            ExpertDetailPageItem expert = Expert.Item;

            if (expert != null && expert.ExpertImage.MediaItem != null)
            {
                item = expert.ExpertImage.MediaItem;
            }

            return item.GetMediaUrlWithFallback(maxWidth, maxHeight);
        }

        public string GetFormattedEventDate()
        {
            DateTime eventDate = EventDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                TimeZoneItem timezone = Timezone.Item;
                string timeZoneText = (timezone != null) ? timezone.Timezone.Rendered : string.Empty;

                return String.Format("{0:ddd MMM dd} at {0:hh:mm tt} {1}", eventDate, timeZoneText);
            }

            return String.Empty;
        }
    }
}