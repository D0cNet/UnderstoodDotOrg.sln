using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets
{
    public partial class UpcomingEvent : BaseSublayout<UpcomingEventWidgetItem>
    {
        protected string EventDate { get; set; }
        protected string EventTime { get; set; }
        protected string Expert { get; set; }
        protected string EventUrl { get; set; }
        protected string EventTitle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            frWidgetTitle.Item = Model;

            var upcoming = SearchHelper.GetNextUpcomingEvent();
            if (upcoming != null)
            {
                EventUrl = upcoming.GetUrl();
                EventTitle = upcoming.ContentPage.PageTitle.Rendered;
                EventDate = upcoming.GetFormattedEventStartDate("MMMM dd, yyyy");
                EventTime = upcoming.GetFormattedEventStartTime();

                ExpertDetailPageItem expert = upcoming.Expert.Item;
                if (expert != null)
                {
                    Expert = expert.ExpertName.Rendered;
                }
            }
            else
            {
                this.Visible = false;
            }
        }
    }
}