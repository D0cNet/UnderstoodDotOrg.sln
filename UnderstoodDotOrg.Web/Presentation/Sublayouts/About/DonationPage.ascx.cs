using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class DonationPage : BaseSublayout<DonatePageItem>
    {
        protected string ThankYouPageUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");

            ThankYouPageUrl = Model.GetConfirmationPage().GetUrl();

            var donationAmounts = Model.DonationAmounts.ListItems
                .Where(i => i != null)
                .Select(i => (DonationAmountItem)i);
            rptrDonationAmounts.DataSource = donationAmounts;
            rptrDonationAmounts.DataBind();
        }
    }
}