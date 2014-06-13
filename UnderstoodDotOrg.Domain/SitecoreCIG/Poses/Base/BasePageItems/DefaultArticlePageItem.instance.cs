using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

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

        public string GetArticleType()
        {
            var container = Sitecore.Context.Database.GetItem(Constants.ArticleTypesContainer);
            if (container != null)
            {
                var match = container.Children.FilterByContextLanguageVersion()
                            .Select(i => new ArticleTypeItem(i))
                            .Where(i => i.ArticleTypeTemplate.Item != null
                                   && i.ArticleTypeTemplate.Item.ID == InnerItem.TemplateID)
                            .FirstOrDefault();

                if (match != null)
                {
                    return match.ArticleTypeName.Rendered;
                }
            }

            return string.Empty;
        }
    }
}