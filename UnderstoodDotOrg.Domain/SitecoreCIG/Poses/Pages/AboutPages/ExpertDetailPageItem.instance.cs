using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class ExpertDetailPageItem 
    {
        public string GetExpertType()
        {
            return IsGuest.Checked
                        ? DictionaryConstants.GuestExpertLabel : DictionaryConstants.ExpertLabel;
        }

        public string GetThumbnailUrl(int maxWidth, int maxHeight)
        {
            return ExpertImage.MediaItem.GetMediaUrlWithFallback(maxWidth, maxHeight);
        }

        public List<string> GetTasks()
        {
            List<string> results = new List<string>();

            // Assemble event types into single string
            if (EventParticipation.ListItems.Any())
            {
                var events = EventParticipation.ListItems
                                .Select(i => new EventTypeItem(i))
                                .Select(i => i.EventTypeName.Rendered);

                string combined = String.Join(" &amp; ", events.ToArray());

                if (!string.IsNullOrEmpty(combined))
                {
                    combined = String.Format("{0} {1}", DictionaryConstants.HostsFragment, combined);
                }

                results.Add(combined);
            }

            // TODO: Add logic to detect if they write Blogs

            return results;
        }
    }
}