using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Resources.Media;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
    public partial class DefaultArticlePageItem 
    {
        /// <summary>
        /// Gets Media URL to use for image thumbnails, falls back to Featured Image if Content Thumbnail is not set
        /// </summary>
        /// <returns></returns>
        public string GetArticleThumbnailField()
        {
            return (!String.IsNullOrEmpty(ContentThumbnail.MediaUrl)) 
                ? "Content Thumbnail" : "Featured Image";
        }

        /// <summary>
        /// Get Content Thumbnail URL, with fallback to Featured Image
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public string GetArticleThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = ContentThumbnail.MediaItem ?? FeaturedImage.MediaItem;

            return GetMediaUrl(item, maxWidth, maxHeight);
        }

        /// <summary>
        /// Get Featured Image URL, with fallback to Content Thumbnail
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public string GetArticleFeaturedThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = FeaturedImage.MediaItem ?? ContentThumbnail.MediaItem;

            return GetMediaUrl(item, maxWidth, maxHeight);
        }

        private string GetMediaUrl(Item item, int maxWidth, int maxHeight)
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

            return String.Empty;
        }
    }
}