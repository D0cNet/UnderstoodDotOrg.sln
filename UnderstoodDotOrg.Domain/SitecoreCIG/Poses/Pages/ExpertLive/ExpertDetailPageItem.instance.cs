using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive
{
    public partial class ExpertDetailPageItem 
    {
        public string GetExpertType()
        {
            return IsGuest.Checked 
                        ? DictionaryConstants.GuestExpertLabel : DictionaryConstants.ExpertLabel;
        }
    }
}