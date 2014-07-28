using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class EventsCalendarView : System.Web.UI.UserControl
    {

        protected List<EventsLiveCalendarDay> EventsLiveCalendarDays { get; private set; }
        private DateTime SelectedMonthYear { get; set; }

        private void Page_Load(object sender, EventArgs e)
        {
            ParseRequestedCalendarMonth();
            SetCalendarLiterals();
            BuildCalendarData();
            listViewEventsLiveCalendar.DataSource = EventsLiveCalendarDays;
            listViewEventsLiveCalendar.DataBind();
        }

        private void ParseRequestedCalendarMonth()
        {
            string queryMonth = HttpHelper.GetQueryString("month", DateTime.Now.Month.ToString()).Trim();
            string queryYear = HttpHelper.GetQueryString("year", DateTime.Now.Year.ToString()).Trim();
            DateTime queryDate = DateTime.Now;

            try
            {
                queryDate = new DateTime(int.Parse(queryYear), int.Parse(queryMonth), 1);
            }
            catch (Exception)
            {
                // any kind of exception, just go back to current date
                queryDate = DateTime.Now;
            }

            SelectedMonthYear = queryDate;
        }

        private void SetCalendarLiterals()
        {
            hlPreviousMonth.Text = SelectedMonthYear.AddMonths(-1).ToString("MMMM yyyy");
            hlPreviousMonth.ToolTip = hlPreviousMonth.Text;
            currentMonth.Text = SelectedMonthYear.ToString("MMMM yyyy");
            hlNextMonth.Text = SelectedMonthYear.AddMonths(1).ToString("MMMM yyyy");
            hlNextMonth.ToolTip = hlNextMonth.Text;
        }

        private void BuildCalendarData()
        {
            DateTime thisMonthFirstDay = new DateTime(SelectedMonthYear.Year, SelectedMonthYear.Month, 1);
            DateTime thisMonthLastDay = thisMonthFirstDay.AddMonths(1).AddDays(-1);
            List<object> exactMonth = new List<object>(thisMonthLastDay.Day);
            int numberPreviousDays = (DayOfWeek.Sunday - thisMonthFirstDay.DayOfWeek);

            var eventResultsCurrentMonth = SearchHelper.GetEventsByMonthAndYear(SelectedMonthYear.Month, SelectedMonthYear.Year);
            var eventsByDay = GetFilledDictionaryFromEvents(eventResultsCurrentMonth);

            EventsLiveCalendarDays = new List<EventsLiveCalendarDay>();
            DateTime currentDate = thisMonthFirstDay.AddDays(numberPreviousDays);
            DateTime endDate = thisMonthFirstDay.AddMonths(1);
            while (currentDate < endDate)
            {
                var keyCurrentDate = currentDate.Date;
                var listOfEvents = (eventsByDay.ContainsKey(keyCurrentDate)) ? eventsByDay[keyCurrentDate] : new List<BaseEventDetailPageItem>();

                if (currentDate < thisMonthFirstDay)
                {
                    EventsLiveCalendarDays.Add(new EventsLiveCalendarDay(currentDate));
                }
                else
                {
                    EventsLiveCalendarDays.Add(new EventsLiveCalendarDay(currentDate, listOfEvents));
                }

                currentDate = currentDate.AddDays(1);
            }
        }

        private Dictionary<DateTime, List<BaseEventDetailPageItem>> GetFilledDictionaryFromEvents(IEnumerable<BaseEventDetailPageItem> eventsCurrentMonth)
        {
            Dictionary<DateTime, List<BaseEventDetailPageItem>> myEvents = new Dictionary<DateTime, List<BaseEventDetailPageItem>>();

            foreach (BaseEventDetailPageItem item in eventsCurrentMonth)
            {
                DateTime keyCurrentItemDate = item.EventStartDate.DateTime.Date;
                if (myEvents.ContainsKey(keyCurrentItemDate))
                {
                    var thisList = myEvents[keyCurrentItemDate] ?? new List<BaseEventDetailPageItem>();
                    thisList.Add(item);
                    //cast expert as an expertdetailitem?
                    //look at controls on landing/details page
                    //item.Expert.Item.
                    myEvents[keyCurrentItemDate] = thisList;
                }
                else
                {
                    var newList = new List<BaseEventDetailPageItem>();
                    newList.Add(item);
                    myEvents.Add(keyCurrentItemDate, newList);
                }
            }

            return myEvents;
        }

    }
}