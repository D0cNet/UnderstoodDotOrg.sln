using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

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
            EventsLiveCalendarView.ItemDataBound += EventsLiveCalendarView_ItemDataBound;
            EventsLiveCalendarView.DataSource = EventsLiveCalendarDays;
            EventsLiveCalendarView.DataBind();
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

            var queryableCurrentMonthEvents = SearchHelper.GetEventsByMonthAndYear(SelectedMonthYear.Month, SelectedMonthYear.Year);
            var listCurrentMonthEvents = new List<BaseEventDetailPageItem>(queryableCurrentMonthEvents);
            var eventsByDay = GetFilledDictionaryFromEvents(listCurrentMonthEvents);

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

        protected void EventsLiveCalendarView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                EventsLiveCalendarDay eventDay = (EventsLiveCalendarDay)e.Item.DataItem;
                HtmlGenericControl liDay = (HtmlGenericControl)e.Item.FindControl("liDay");

                liDay.Style.Add("height", "237px");
                liDay.Attributes["class"] += " " + eventDay.CurrentDate.DayOfWeek.ToString().ToLower();

                if (eventDay.CurrentDate < SelectedMonthYear)
                {
                    BindAdjacentMonthItem(e, liDay);
                }
                else
                {
                    BindCurrentMonthItem(e, liDay);
                }

            }
        }

        private void BindAdjacentMonthItem(ListViewItemEventArgs e, HtmlGenericControl liDay)
        {
            PlaceHolder placeholderEventDayContent = (PlaceHolder)e.Item.FindControl("placeholderEventDayContent");
            placeholderEventDayContent.Visible = false;
            liDay.Attributes["class"] += " adjacent-month";
        }

        private void BindCurrentMonthItem(ListViewItemEventArgs e, HtmlGenericControl liDay)
        {
            EventsLiveCalendarDay eventDay = (EventsLiveCalendarDay)e.Item.DataItem;
            PlaceHolder placeholderEventDayContent = (PlaceHolder)e.Item.FindControl("placeholderEventDayContent");
            Repeater RepeaterSingleDayEvents = (Repeater)e.Item.FindControl("RepeaterSingleDayEvents");

            if (eventDay.CurrentDate < SelectedMonthYear)
            {
                placeholderEventDayContent.Visible = false;
            }
            
            if (eventDay.CurrentEvents != null && eventDay.CurrentEvents.Count > 0)
            {
                if (eventDay.CurrentEvents.Count == 1)
                {
                    liDay.Attributes["class"] += " single";
                }
                else if (eventDay.CurrentEvents.Count > 1)
                {
                    liDay.Attributes["class"] += " multiple-events";
                }

                RepeaterSingleDayEvents.ItemDataBound += RepeaterSingleDayEvents_ItemDataBound;
                RepeaterSingleDayEvents.DataSource = eventDay.CurrentEvents;
                RepeaterSingleDayEvents.DataBind();
            }

        }

        protected void RepeaterSingleDayEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                BaseEventDetailPageItem eventToBind = (BaseEventDetailPageItem)e.Item.DataItem;
                Literal literalEventTimeDate = (Literal)e.Item.FindControl("literalEventTimeDate");
                Literal literalEventUTCTime = (Literal)e.Item.FindControl("literalEventUTCTime");
                HyperLink linkEventDetails = (HyperLink)e.Item.FindControl("linkEventDetails");
                HyperLink linkEventDate = (HyperLink)e.Item.FindControl("linkEventDate");
                HyperLink linkRSVP = (HyperLink)e.Item.FindControl("linkRSVP");
                HyperLink linkAddToCalendar = (HyperLink)e.Item.FindControl("linkAddToCalendar");
                Literal literalExpertName = (Literal)e.Item.FindControl("literalExpertName");
                Literal literalExpertTitles = (Literal)e.Item.FindControl("literalExpertTitles");
                Image imgExpert = (Image)e.Item.FindControl("imgExpert");
                HyperLink linkExpert = (HyperLink)e.Item.FindControl("linkExpert");

                StringBuilder builderTimeDate = new StringBuilder();
                builderTimeDate.AppendLine(eventToBind.GetFormattedEventStartTime());
                builderTimeDate.Append(eventToBind.GetFormattedEventStartDate());
                literalEventTimeDate.Text = builderTimeDate.ToString();

                literalEventUTCTime.Text = eventToBind.EventStartDate.DateTime.ToUniversalTime().ToString("htt") + " UTC";
                linkEventDetails.NavigateUrl = linkEventDate.NavigateUrl = eventToBind.GetUrl();
                linkRSVP.NavigateUrl = eventToBind.RSVPforEventLink.Rendered;
                linkAddToCalendar.NavigateUrl = eventToBind.AddToCalendarLink.Rendered;

                ExpertDetailPageItem expertToBind = (ExpertDetailPageItem)eventToBind.Expert.Item;
                literalExpertName.Text = expertToBind.DisplayName;
                StringBuilder builderExpertCaption = new StringBuilder();
                builderExpertCaption.Append(expertToBind.ExpertHeading.Rendered);
                builderExpertCaption.AppendLine(",<br />");
                builderExpertCaption.Append(expertToBind.ExpertSubheading.Rendered);
                literalExpertTitles.Text = builderExpertCaption.ToString();

                imgExpert.AlternateText = expertToBind.DisplayName;
                imgExpert.ImageUrl = expertToBind.ExpertImage.MediaUrl;
                linkExpert.NavigateUrl = expertToBind.GetUrl();

                if (expertToBind.GetExpertType().ToLower() == "chat")
                {
                    BindItemForChatEvent(e);
                }
                else
                {
                    BindItemForWebinarEvent(e);
                }
            }
        }

        private void BindItemForChatEvent(RepeaterItemEventArgs e)
        {
            BaseEventDetailPageItem eventToBind = (BaseEventDetailPageItem)e.Item.DataItem;
            HtmlGenericControl paragraphChatHeading = (HtmlGenericControl)e.Item.FindControl("paragraphChatHeading");
            HyperLink linkEventName = (HyperLink)e.Item.FindControl("linkEventName");
            ExpertDetailPageItem expertToBind = (ExpertDetailPageItem)eventToBind.Expert.Item;

            paragraphChatHeading.Visible = true;
            paragraphChatHeading.InnerText = eventToBind.EventHeading.Rendered;
            linkEventName.Text = "Live Chat with " + expertToBind.DisplayName;
        }

        private void BindItemForWebinarEvent(RepeaterItemEventArgs e)
        {
            BaseEventDetailPageItem eventToBind = (BaseEventDetailPageItem)e.Item.DataItem;
            HyperLink linkEventName = (HyperLink)e.Item.FindControl("linkEventName");

            linkEventName.Text = eventToBind.EventHeading.Rendered;
        }

    }
}