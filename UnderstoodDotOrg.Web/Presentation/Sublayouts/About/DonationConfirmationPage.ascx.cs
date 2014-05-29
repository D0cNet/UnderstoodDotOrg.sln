using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class DonationConfirmationPage : BaseSublayout<DonationConfirmationPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgBanner.ImageUrl = this.Model.BannerImage.MediaItem != null ? this.Model.BannerImage.MediaUrl : "";
        }
    }
}