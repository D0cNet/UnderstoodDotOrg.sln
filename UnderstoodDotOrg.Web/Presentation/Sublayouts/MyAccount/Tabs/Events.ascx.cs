using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Extensions;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Events : System.Web.UI.UserControl
    {
        private class EventModel
        {
            public string Title { get; set; }
            public string TitleUrl { get; set; }
            public string Type { get; set; }
            public string TypeUrl { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Year { get; set; }
            public List<string> ChildIssue { get; set; }
            public List<string> ParentIssue { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var events = SearchHelper.GetUpcomingEvents(2).ToList();
            List<EventModel> eventsDataSource = new List<EventModel>();

            foreach (BaseEventDetailPageItem eventItem in events.OrderByDescending(i => i.EventStartDate.DateTime.Date).ThenBy(i => i.EventStartDate.DateTime.TimeOfDay))
            {
                EventModel stubEvent = new EventModel();
                stubEvent.Title = eventItem.EventHeading.Rendered;
                stubEvent.TitleUrl = eventItem.InnerItem.GetUrl();
                stubEvent.Type = eventItem.GetEventType();
                //stubEvent.TypeUrl = hypEventsTab.NavigateUrl;
                stubEvent.Date = eventItem.EventStartDate.DateTime.ToShortDateString();
                stubEvent.Time = eventItem.EventStartDate.DateTime.ToShortTimeString();
                stubEvent.Year = eventItem.EventStartDate.DateTime.Year.ToString();
                stubEvent.ChildIssue = eventItem.ChildIssue.ListItems.Select(i => i.DisplayName).ToList();
                stubEvent.ParentIssue = eventItem.ParentInterest.ListItems.Select(i => i.DisplayName).ToList();
                eventsDataSource.Add(stubEvent);
            }

            rptUpcomingEvents.DataSource = eventsDataSource;
            rptUpcomingEvents.DataBind();
        }

        protected void rptUpcomingEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            EventModel eventItem = (EventModel)e.Item.DataItem as EventModel;

            HyperLink hypTitleLink = (HyperLink)e.Item.FindControl("hypTitleLink");
            HyperLink hypEventDetails = (HyperLink)e.Item.FindControl("hypEventDetails");
            Literal litDate = (Literal)e.Item.FindControl("litDate");
            Literal litTime = (Literal)e.Item.FindControl("litTime");
            Literal litYear = (Literal)e.Item.FindControl("litYear");
            Literal litType = (Literal)e.Item.FindControl("litType");
            Literal litType2 = (Literal)e.Item.FindControl("litType2");
            Literal litDate2 = (Literal)e.Item.FindControl("litDate2");
            Literal litTime2 = (Literal)e.Item.FindControl("litTime2");
            Literal litYear2 = (Literal)e.Item.FindControl("litYear2");
            Literal litIssuesCovered = (Literal)e.Item.FindControl("litIssuesCovered");
            HtmlGenericControl tomorrowDiv = (HtmlGenericControl)e.Item.FindControl("tomorrowDiv");

            hypTitleLink.NavigateUrl = eventItem.TitleUrl;
            hypTitleLink.Text = eventItem.Title;

            hypEventDetails.NavigateUrl = eventItem.TitleUrl;
            hypEventDetails.Text = "Event Details";

            litDate.Text = litDate2.Text = eventItem.Date;
            litYear.Text = litYear2.Text = eventItem.Year;
            litTime.Text = litTime2.Text = eventItem.Time;
            litType.Text = litType2.Text = eventItem.Type;

            bool first = true;
            foreach(string s in eventItem.ChildIssue)
            {
                if (first)
                {
                    litIssuesCovered.Text = s;
                    first = false;
                }
                else
                    litIssuesCovered.Text += ",  "+s;
            }

            foreach (string s in eventItem.ParentIssue)
            {
                if (first)
                {
                    litIssuesCovered.Text = s;
                    first = false;
                }
                else
                    litIssuesCovered.Text += ",  " + s;
            }

            if (DateTime.Parse(eventItem.Date).Day.Equals(DateTime.Now.AddDays(1)))
                tomorrowDiv.Visible = true;
            else
                tomorrowDiv.Visible = false;
        }
    }
}