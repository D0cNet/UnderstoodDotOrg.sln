using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Extensions
{
    public static class MediaItemExtension
    {
        public static string GetMediaUrlWithFallback(this MediaItem item, int maxWidth, int maxHeight)
        {
            if (item != null)
            {
                return Sitecore.StringUtil.EnsurePrefix('/',
                        Sitecore.Resources.Media.MediaManager.GetMediaUrl(item, new MediaUrlOptions
                        {
                            MaxWidth = maxWidth,
                            MaxHeight = maxHeight
                        }));
            }

            // TODO: temporary
            return String.Format("http://placehold.it/{0}x{1}", maxWidth, maxHeight);
        }
    }
}
