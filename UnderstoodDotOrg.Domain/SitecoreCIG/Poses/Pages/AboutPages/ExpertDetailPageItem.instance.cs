using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

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
    }
}