using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class UpcomingEvents : BaseSublayout
    {
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
                HyperLink hlExpertPicture = e.FindControlAs<HyperLink>("hlExpertPicture");
                Literal litExpertType = e.FindControlAs<Literal>("litExpertType");
                Literal litEventDate = e.FindControlAs<Literal>("litEventDate");
                Literal litRSVPText = e.FindControlAs<Literal>("litRSVPText");
                Literal litSkipThisText = e.FindControlAs<Literal>("litSkipThisText");

                litRSVPText.Text = DictionaryConstants.Community_RSVPButtonText;
                litSkipThisText.Text = DictionaryConstants.Community_SkipThisButtonText;

                litEventDate.Text = item.GetFormattedEventStartDate();
                hlEventDetail.NavigateUrl = item.GetUrl();
                hlExpertPicture.NavigateUrl = item.GetUrl();
                frExpertName.Item = item;

                // Expert details
                ExpertDetailPageItem expert = item.Expert.Item;

                if (expert != null)
                {
                    imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);
                    //litExpertType.Text = expert.GetExpertType();
                }
            }
        }

        private void BindControls()
        {
            // Upcoming events
            var events = SearchHelper.GetUpcomingEvents(6);
            if (events.Any())
            {
                this.Visible = true;
                rptEvents.DataSource = events;
                rptEvents.DataBind();
            }
            else
                this.Visible = false;
        }
    }
}