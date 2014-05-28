using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
    public partial class DefaultArticlePageItem 
    {
        /// <summary>
        /// Get Content Thumbnail URL, with fallback to Featured Image
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public string GetArticleThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = ContentThumbnail.MediaItem ?? FeaturedImage.MediaItem;

            return item.GetMediaUrlWithFallback(maxWidth, maxHeight);
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

            return item.GetMediaUrlWithFallback(maxWidth, maxHeight);
        }
    }
}