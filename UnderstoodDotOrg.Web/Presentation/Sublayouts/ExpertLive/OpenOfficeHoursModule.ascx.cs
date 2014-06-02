using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class OpenOfficeHoursModule : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        private void BindEvents()
        {
            rptExperts.ItemDataBound += rptExperts_ItemDataBound;
        }

        private void BindContent()
        {
            ExpertLivePageItem item = Sitecore.Context.Database.GetItem(Constants.Pages.ExpertLive);

            frLiveChatHeading.Item = frLiveChatSubHeading.Item = item;

            var experts = SearchHelper.GetRandomizedExpertsWithOpenOfficeHours();
            if (experts.Any())
            {
                rptExperts.DataSource = experts;
                rptExperts.DataBind();
            }
        }

        void rptExperts_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ExpertDetailPageItem expert = (ExpertDetailPageItem)e.Item.DataItem;

                HyperLink hlExpertDetail = e.FindControlAs<HyperLink>("hlExpertDetail");
                HyperLink hlExpertDetailCta = e.FindControlAs<HyperLink>("hlExpertDetailCta");
                HyperLink hlOfficeHours = e.FindControlAs<HyperLink>("hlOfficeHours");
                HyperLink hlExpertDetailCtaMobile = e.FindControlAs<HyperLink>("hlExpertDetailCtaMobile");
                HyperLink hlOfficeHoursMobile = e.FindControlAs<HyperLink>("hlOfficeHoursMobile");

                hlExpertDetail.NavigateUrl = hlExpertDetailCta.NavigateUrl = hlExpertDetailCtaMobile.NavigateUrl
                    = expert.GetUrl();

                System.Web.UI.WebControls.Image imgExpert = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpert");
                imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);

                Literal litExpertType = e.FindControlAs<Literal>("litExpertType");
                litExpertType.Text = expert.GetExpertType();

                FieldRenderer frExpertName = e.FindControlAs<FieldRenderer>("frExpertName");
                FieldRenderer frExpertSubheading = e.FindControlAs<FieldRenderer>("frExpertSubheading");

                frExpertName.Item = frExpertSubheading.Item = expert;
            }
        }
    }
}