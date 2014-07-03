using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyUpcomingEvents : BaseSublayout
    {
        private class EventModel
        {
            public string Title { get; set; }
            public string TitleUrl { get; set; }
            public string Type { get; set; }
            public string TypeUrl { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountEvents);

            MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;

            hypEventsTab.NavigateUrl = Sitecore.Context.Database.GetItem(Constants.Pages.WhatsHappening).GetUrl();
            hypEventsTab.Text = context.UpcomingEventsLinkText;

            var events = SearchHelper.GetUpcomingEvents(2).ToList();
            List<EventModel> eventsDataSource = new List<EventModel>();
            
            foreach (BaseEventDetailPageItem eventItem in events.OrderByDescending(i => i.EventStartDate.DateTime.Date).ThenBy(i => i.EventStartDate.DateTime.TimeOfDay))
            {
                EventModel stubEvent = new EventModel();
                stubEvent.Title = eventItem.EventHeading.Rendered;
                stubEvent.TitleUrl = eventItem.InnerItem.GetUrl();
                stubEvent.Type = eventItem.GetEventType();
                stubEvent.TypeUrl = hypEventsTab.NavigateUrl;
                stubEvent.Date = eventItem.EventStartDate.DateTime.ToShortDateString();
                stubEvent.Time = eventItem.EventStartDate.DateTime.ToShortTimeString();
                eventsDataSource.Add(stubEvent);
            }

            rptEvents.DataSource = eventsDataSource;
            rptEvents.DataBind();
        }

        protected void rptEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (EventModel)e.Item.DataItem as EventModel;
            
            HyperLink hypEventLink = (HyperLink)e.Item.FindControl("hypEventLink");
            hypEventLink.NavigateUrl = ((EventModel)e.Item.DataItem).TitleUrl;
            hypEventLink.Text = ((EventModel)e.Item.DataItem).Title;

            HyperLink hypEventTypeLink = (HyperLink)e.Item.FindControl("hypEventTypeLink");
            hypEventTypeLink.NavigateUrl = ((EventModel)e.Item.DataItem).TypeUrl;
            hypEventTypeLink.Text = ((EventModel)e.Item.DataItem).Type;

            Literal litDate = (Literal)e.Item.FindControl("litDate");
            litDate.Text = ((EventModel)e.Item.DataItem).Date;

            Literal litTime = (Literal)e.Item.FindControl("litTime");
            litTime.Text = ((EventModel)e.Item.DataItem).Time;
        }
    }
}