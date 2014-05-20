using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
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
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountEvents);
            hypEventsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            //TO-DO Add call to get Favorites and cast them as FavoriteModel objects

            //Stub for one link
            List<EventModel> eventsDataSource = new List<EventModel>();
            EventModel stubEvent = new EventModel();
            stubEvent.Title = "Event 1";
            stubEvent.TitleUrl = "/";
            stubEvent.Type = "EventType 1";
            stubEvent.TitleUrl = "/";
            stubEvent.Date = "Dec 12 2014 ";
            stubEvent.Time = "2:48PM";
            eventsDataSource.Add(stubEvent);

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