using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class AboutUnderstood : BaseSublayout<AboutUnderstoodItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            rptPartnerList.ItemDataBound += rptPartnerList_ItemDataBound;
            rptSectionPages.ItemDataBound += rptSectionPages_ItemDataBound;
        }

        private void rptSectionPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                AboutSectionPageItem page = (AboutSectionPageItem)e.Item.DataItem;
                FieldRenderer frNavigationSectionTitle = e.FindControlAs<FieldRenderer>("frNavigationSectionTitle");
                FieldRenderer frNavigationSectionSummary = e.FindControlAs<FieldRenderer>("frNavigationSectionSummary");
                FieldRenderer frNavigationSectionImage = e.FindControlAs<FieldRenderer>("frNavigationSectionImage");

                frNavigationSectionImage.Item = frNavigationSectionSummary.Item = frNavigationSectionTitle.Item = page;

                HyperLink hlReadMore = e.FindControlAs<HyperLink>("hlReadMore");
                hlReadMore.NavigateUrl = page.GetUrl();
                hlReadMore.Text = UnderstoodDotOrg.Common.DictionaryConstants.ReadMoreLabel;
            }
        }

        private void BindControls()
        {
            // Section Pages
            IEnumerable<AboutSectionPageItem> pages = Model.GetSectionPages();
            if (pages.Any())
            {
                rptSectionPages.DataSource = pages;
                rptSectionPages.DataBind();
            }
            
            // Partners list
            Item partnerPage = Sitecore.Context.Database.GetItem(Constants.Pages.Partners);
            if (partnerPage != null)
            {
                var partners = partnerPage.Children.FilterByContextLanguageVersion()
                                    .Where(i => i.TemplateID.ToString() == PartnerInfoItem.TemplateId);

                if (partners.Any())
                {
                    rptPartnerList.DataSource = partners;
                    rptPartnerList.DataBind();
                }
            }
        }

        protected void rptPartnerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;
                PartnerInfoItem partner = item;

                HyperLink hlPartnerLogo = e.FindControlAs<HyperLink>("hlPartnerLogo");
                hlPartnerLogo.NavigateUrl = item.GetUrl();
                hlPartnerLogo.Visible = partner.Logo.MediaItem != null;

                FieldRenderer frPartnerLogo = e.FindControlAs<FieldRenderer>("frPartnerLogo");
                frPartnerLogo.Item = item;

                
            }
        }
    }
}