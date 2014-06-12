using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class ExpertLivePageItem 
    {
        public static ExpertLivePageItem GetLandingPage()
        {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.ExpertLive);
            if (item != null)
            {
                return (ExpertLivePageItem)item;
            }

            return null;
        }
    }
}