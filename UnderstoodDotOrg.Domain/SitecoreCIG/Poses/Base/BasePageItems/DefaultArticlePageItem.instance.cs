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

        public string GetArticleThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = ContentThumbnail.MediaItem ?? FeaturedImage.MediaItem;

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