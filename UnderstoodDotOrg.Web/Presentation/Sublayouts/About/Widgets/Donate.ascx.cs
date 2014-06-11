using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Widgets
{
    public partial class DonateWidget : BaseSublayout
    {
        protected DonateWidgetItem Model = new DonateWidgetItem(MainsectionItem.GetGlobals().GetMetaDataFolder().GetWidgetFolder().GetDonateWidgetItem().InnerItem);
        protected void Page_Load(object sender, EventArgs e)
        {
            var donatePage = MainsectionItem.GetHomePageItem().GetAboutPage().GetDonatePage();
            hypDonate25.NavigateUrl = string.Format(donatePage.GetUrl() + "?{0}={1}", Constants.DONATION_AMOUNT, "25");
            hypDonate50.NavigateUrl = string.Format(donatePage.GetUrl() + "?{0}={1}", Constants.DONATION_AMOUNT, "50");
            hypDonate100.NavigateUrl = string.Format(donatePage.GetUrl() + "?{0}={1}", Constants.DONATION_AMOUNT, "100");
            hypDonateOther.NavigateUrl = string.Format(donatePage.GetUrl() + "?{0}={1}", Constants.DONATION_AMOUNT, "other");
        }
    }
}