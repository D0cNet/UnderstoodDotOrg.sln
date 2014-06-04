using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomItemGenerator.Fields.SimpleTypes;

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

        public static string GetImageUrl(this MediaItem mediaItem, int? width = null, int? height = null, int? maxWidth = null, int? maxHeight = null)
        {
            string imageUrl = string.Empty;
            if (mediaItem != null)
            {
                var options = new MediaUrlOptions();
                if (width.HasValue)
                    options.Width = width.Value;
                if (height.HasValue)
                    options.Height = height.Value;
                if (maxWidth.HasValue)
                    options.MaxWidth = maxWidth.Value;
                if (maxHeight.HasValue)
                    options.MaxHeight = maxHeight.Value;

                imageUrl = Sitecore.StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(mediaItem, options));
            }
            return imageUrl;
        }

        public static string GetImageUrl(this CustomImageField customImageField, int? width = null, int? height = null, int? maxWidth = null, int? maxHeight = null)
        {
            string imageUrl = "";
            Sitecore.Data.Fields.ImageField imageField = customImageField.Field;
            if (imageField != null && imageField.MediaItem != null)
            {
                var image = new MediaItem(imageField.MediaItem);

                var options = new MediaUrlOptions
                {
                    Width = width.HasValue ? width.Value : Int32.Parse(imageField.Width),
                    Height = height.HasValue ? height.Value : Int32.Parse(imageField.Height)
                };

                if (maxWidth.HasValue)
                    options.MaxWidth = maxWidth.Value;
                if (maxHeight.HasValue)
                    options.MaxHeight = maxHeight.Value;

                imageUrl = Sitecore.StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image, options));
            }
            return imageUrl;
        }
    }
}
