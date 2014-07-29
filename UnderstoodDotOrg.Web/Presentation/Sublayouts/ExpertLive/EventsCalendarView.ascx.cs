using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class EventsCalendarView : BaseSublayout
    {
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }
        
        protected List<EventsLiveCalendarDay> EventsLiveCalendarDays { get; private set; }
        private DateTime SelectedMonthYear { get; set; }

        private void Page_Load(object sender, EventArgs e)
        {
            Issue = HttpHelper.GetQueryString(Constants.EVENT_ISSUE_FILTER_QUERY_STRING).Trim();
            Grade = HttpHelper.GetQueryString(Constants.EVENT_GRADE_FILTER_QUERY_STRING).Trim();
            Topic = HttpHelper.GetQueryString(Constants.EVENT_TOPIC_FILTER_QUERY_STRING).Trim();

            ParseRequestedCalendarMonth();
            SetCalendarInfo();
            BuildCalendarData();

            EventsLiveCalendarView.ItemDataBound += EventsLiveCalendarView_ItemDataBound;
            EventsLiveCalendarView.LayoutCreated += EventsLiveCalendarView_LayoutCreated;
            EventsLiveCalendarView.DataSource = EventsLiveCalendarDays;
            EventsLiveCalendarView.DataBind();
        }

        void EventsLiveCalendarView_LayoutCreated(object sender, EventArgs e)
        {
            Literal litSunday = (Literal)EventsLiveCalendarView.FindControl("litSunday");
            Literal litMonday = (Literal)EventsLiveCalendarView.FindControl("litMonday");
            Literal litTuesday = (Literal)EventsLiveCalendarView.FindControl("litTuesday");
            Literal litWednesday = (Literal)EventsLiveCalendarView.FindControl("litWednesday");
            Literal litThursday = (Literal)EventsLiveCalendarView.FindControl("litThursday");
            Literal litFriday = (Literal)EventsLiveCalendarView.FindControl("litFriday");
            Literal litSaturday = (Literal)EventsLiveCalendarView.FindControl("litSaturday");

            DateTimeFormatInfo dtfi = Sitecore.Context.Culture.DateTimeFormat;

            litSunday.Text = dtfi.GetDayName(DayOfWeek.Sunday);
            litMonday.Text = dtfi.GetDayName(DayOfWeek.Monday);
            litTuesday.Text = dtfi.GetDayName(DayOfWeek.Tuesday);
            litWednesday.Text = dtfi.GetDayName(DayOfWeek.Wednesday);
            litThursday.Text = dtfi.GetDayName(DayOfWeek.Thursday);
            litFriday.Text = dtfi.GetDayName(DayOfWeek.Friday);
            litSaturday.Text = dtfi.GetDayName(DayOfWeek.Saturday);
        }

        private void ParseRequestedCalendarMonth()
        {
            string queryMonth = HttpHelper.GetQueryString(Constants.QueryStrings.ExpertsLive.Month, DateTime.Now.Month.ToString()).Trim();
            string queryYear = HttpHelper.GetQueryString(Constants.QueryStrings.ExpertsLive.Year, DateTime.Now.Year.ToString()).Trim();
            DateTime queryDate = DateTime.Now;

            try
            {
                queryDate = new DateTime(int.Parse(queryYear), int.Parse(queryMonth), 1);
            }
            catch (Exception)
            {
                Response.Redirect(Request.Url.AbsolutePath);
            }

            SelectedMonthYear = queryDate;
        }

        private void SetCalendarInfo()
        {
            DateTime previous = SelectedMonthYear.AddMonths(-1);
            DateTime next = SelectedMonthYear.AddMonths(1);
            hlPreviousMonth.Text = previous.ToString("MMMM yyyy");
            hlPreviousMonth.ToolTip = hlPreviousMonth.Text;
            currentMonth.Text = SelectedMonthYear.ToString("MMMM yyyy");
            hlNextMonth.Text = next.ToString("MMMM yyyy");
            hlNextMonth.ToolTip = hlNextMonth.Text;

            hlPreviousMonth.NavigateUrl = GetCalendarLink(previous);
            hlNextMonth.NavigateUrl = GetCalendarLink(next);
        }

        private string GetCalendarLink(DateTime date)
        {
            return String.Format("{0}?{1}={2}&{3}={4}", Sitecore.Context.Item.GetUrl(),
                    Constants.QueryStrings.ExpertsLive.Month, date.Month,
                    Constants.QueryStrings.ExpertsLive.Year, date.Year);
        }

        private void BuildCalendarData()
        {
            DateTime thisMonthFirstDay = new DateTime(SelectedMonthYear.Year, SelectedMonthYear.Month, 1);
            DateTime thisMonthLastDay = thisMonthFirstDay.AddMonths(1).AddDays(-1);
            List<object> exactMonth = new List<object>(thisMonthLastDay.Day);
            int numberPreviousDays = (DayOfWeek.Sunday - thisMonthFirstDay.DayOfWeek);

            var queryableCurrentMonthEvents = SearchHelper.GetEventsByMonthAndYear(SelectedMonthYear.Month, SelectedMonthYear.Year, Grade, Issue, Topic);
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
            else
            {
                liDay.Attributes["class"] += " no-events";
            }

        }

        protected void RepeaterSingleDayEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                BaseEventDetailPageItem eventToBind = (BaseEventDetailPageItem)e.Item.DataItem;
                bool IsChatEvent = eventToBind.InnerItem.TemplateID == Sitecore.Data.ID.Parse(ChatEventPageItem.TemplateId);
                Literal literalEventUTCTime = (Literal)e.Item.FindControl("literalEventUTCTime");
                HyperLink linkEventDetails = (HyperLink)e.Item.FindControl("linkEventDetails");
                HyperLink linkEventDate = (HyperLink)e.Item.FindControl("linkEventDate");
                Sitecore.Web.UI.WebControls.FieldRenderer frRsvpLink = (Sitecore.Web.UI.WebControls.FieldRenderer)e.Item.FindControl("frRsvpLink");
                Sitecore.Web.UI.WebControls.FieldRenderer frAddToCalendar = (Sitecore.Web.UI.WebControls.FieldRenderer)e.Item.FindControl("frAddToCalendar");
                Literal literalExpertName = (Literal)e.Item.FindControl("literalExpertName");
                Literal literalExpertTitles = (Literal)e.Item.FindControl("literalExpertTitles");
                Image imageExpert = (Image)e.Item.FindControl("imageExpert");
                Literal litExpertType = e.FindControlAs<Literal>("litExpertType");
                HyperLink linkExpert = (HyperLink)e.Item.FindControl("linkExpert");
                HtmlGenericControl itemSingleEvent = (HtmlGenericControl)e.Item.FindControl("itemSingleEvent");
                PlaceHolder placeholderLive = (PlaceHolder)e.Item.FindControl("placeholderLive");

                StringBuilder builderForDateHeading = new StringBuilder();
                builderForDateHeading.Append(String.Format("{0} {1} ",eventToBind.ContentPage.PageTitle.Rendered, DictionaryConstants.AtFragment));
                builderForDateHeading.Append(eventToBind.GetFormattedEventStartTime());
                builderForDateHeading.Append(" ");
                builderForDateHeading.Append(eventToBind.EventStartDate.DateTime.ToString("MMM d, yyyy", CultureInfo.InvariantCulture));
                linkEventDate.Text = builderForDateHeading.ToString();

                var dateToCheck = eventToBind.EventStartDate.DateTime;
                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var endDate = startDate.AddDays(1);
                if (dateToCheck >= startDate && dateToCheck < endDate)
                {
                    itemSingleEvent.Attributes["class"] += " live-event";
                    placeholderLive.Visible = true;
                }

                literalEventUTCTime.Text = eventToBind.EventStartDate.DateTime.ToUniversalTime().ToString("htt") + " UTC";
                linkEventDetails.NavigateUrl = linkEventDate.NavigateUrl = eventToBind.GetUrl();
                frRsvpLink.Item = frAddToCalendar.Item = eventToBind;

                ExpertDetailPageItem expertToBind = (ExpertDetailPageItem)eventToBind.Expert.Item;
                if (expertToBind != null)
                {
                    literalExpertName.Text = expertToBind.ExpertName;
                    StringBuilder builderExpertCaption = new StringBuilder();
                    builderExpertCaption.Append(expertToBind.ExpertHeading.Rendered);
                    if (!string.IsNullOrWhiteSpace(expertToBind.ExpertSubheading.Rendered))
                    {
                        builderExpertCaption.AppendLine(",<br />");
                        builderExpertCaption.Append(expertToBind.ExpertSubheading.Rendered);
                    }
                    literalExpertTitles.Text = builderExpertCaption.ToString();

                    imageExpert.ImageUrl = expertToBind.GetThumbnailUrl(150, 150);
                    imageExpert.AlternateText = expertToBind.ExpertName;
                    linkExpert.NavigateUrl = expertToBind.GetUrl();
                    litExpertType.Text = expertToBind.GetExpertType();
                }

                HtmlGenericControl paragraphChatHeading = (HtmlGenericControl)e.Item.FindControl("paragraphChatHeading");
                HyperLink linkEventName = (HyperLink)e.Item.FindControl("linkEventName");
                HyperLink linkEventNameTruncated = (HyperLink)e.Item.FindControl("linkEventNameTruncated");

                paragraphChatHeading.Visible = true;
                paragraphChatHeading.InnerText = eventToBind.EventHeading.Raw;
                linkEventName.Text = eventToBind.ContentPage.PageTitle.Rendered;
                linkEventName.NavigateUrl = linkEventNameTruncated.NavigateUrl = eventToBind.GetUrl();
                linkEventNameTruncated.Text = UnderstoodDotOrg.Common.Helpers.TextHelper.TruncateText(
                    System.Web.HttpUtility.HtmlDecode(eventToBind.ContentPage.PageTitle.Raw), 15);
            }
        }

    }
}