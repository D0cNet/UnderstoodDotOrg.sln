using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Generic.Common;
using UnderstoodDotOrg.Common;

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

            List<StateItem> states = MainsectionItem.GetGlobals().GetStatesFolder().InnerItem.Children.Select(i => (StateItem)i).ToList();
            List<ListItem> statesDDlItems = states.Select(i => new ListItem(i.DisplayName, i.StateCode, true)).ToList();

            ddlStates.DataSource = statesDDlItems;
            ddlStates.DataBind();
            ddlStates.Items.Insert(0, new ListItem(DictionaryConstants.SelectLabel, string.Empty));
        }
    }
}