using System;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using Sitecore.Web.UI.WebControls;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class ExpertsLandingPage : BaseSublayout<ExpertLandingPageItem>
    {
        protected string AjaxEndpoint
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.ExpertListingEndpoint); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            rptEvents.ItemDataBound += rptEvents_ItemDataBound;
        }

        void rptEvents_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)e.Item.DataItem;

                FieldRenderer frExpertName = e.FindControlAs<FieldRenderer>("frExpertName");
                FieldRenderer frExpertSubheading = e.FindControlAs<FieldRenderer>("frExpertSubheading");
                System.Web.UI.WebControls.Image imgExpert = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpert");
                HyperLink hlEventDetail = e.FindControlAs<HyperLink>("hlEventDetail");
                Literal litExpertType = e.FindControlAs<Literal>("litExpertType");
                Literal litEventDate = e.FindControlAs<Literal>("litEventDate");

                litEventDate.Text = item.GetFormattedEventStartDate();
                hlEventDetail.NavigateUrl = item.GetUrl();

                // Expert details
                ExpertDetailPageItem expert = item.Expert.Item;
                
                if (expert != null) 
                {
                    frExpertName.Item = frExpertSubheading.Item = expert;
                    imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);
                    litExpertType.Text = expert.GetExpertType();
                }
            }
        }

        private void BindControls()
        {
            // Experts listing
            bool hasMoreResults;
            expertListing.Experts = ExpertLandingPageItem.GetExperts(1, out hasMoreResults);
            phShowMore.Visible = hasMoreResults;

            // Upcoming events
            var events = SearchHelper.GetUpcomingEvents(6);
            if (events.Any())
            {
                rptEvents.DataSource = events;
                rptEvents.DataBind();
            }
        }
    }
}