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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class AboutPartners : BaseSublayout<AboutPartnersItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<PartnerInfoItem> partners = Model.GetPartners();
            if (partners.Any())
            {
                rptPartnerInfo.DataSource = partners;
                rptPartnerInfo.DataBind();
            }
        }

        protected void rptPartnerInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                PartnerInfoItem item = (PartnerInfoItem)e.Item.DataItem;

                var itemLink = item.GetUrl();

                FieldRenderer frPartnerName = e.FindControlAs<FieldRenderer>("frPartnerName");

                if (frPartnerName != null)
                {
                    frPartnerName.Item = item;
                    HyperLink hlPartnerNameLink = e.FindControlAs<HyperLink>("hlPartnerNameLink");
                    if (hlPartnerNameLink != null)
                    {
                        hlPartnerNameLink.NavigateUrl = itemLink;
                        hlPartnerNameLink.Visible = true;
                    }
                }

                Sitecore.Web.UI.WebControls.Image imgPartnerLogo = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("imgPartnerLogo");
                if (imgPartnerLogo != null)
                {
                    imgPartnerLogo.Item = item;
                    HyperLink hlPartnerLogo = e.FindControlAs<HyperLink>("hlPartnerLogo");
                    if (hlPartnerLogo != null)
                    {
                        hlPartnerLogo.NavigateUrl = itemLink;
                        hlPartnerLogo.Visible = true;
                    }
                } //imgPartnerLogo


                FieldRenderer frPartnerDescription = e.FindControlAs<FieldRenderer>("frPartnerDescription");
                if (frPartnerDescription != null)
                {
                    frPartnerDescription.Item = item;
                }
                HyperLink hlPartnerSite = e.FindControlAs<HyperLink>("hlPartnerSite");
                if (hlPartnerSite != null)
                {
                    hlPartnerSite.NavigateUrl = itemLink;
                }
            }
        }
    }
}