using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article
{
public partial class AuthorItem
{
    public string GetThumbnailUrl(int maxWidth, int maxHeight)
    {
        return AuthorImage.MediaItem.GetMediaUrlWithFallback(maxWidth, maxHeight);
    }
}
}