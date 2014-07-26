using System;
using UnderstoodDotOrg.Common.Helpers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class EventsCalendarView : System.Web.UI.UserControl
    {

        private DateTime ViewDate { get; set; }

        private void Page_Load(object sender, EventArgs e)
        {
            ParseRequestedCalendarMonth();
            SetCalendarLiterals();
        }

        private void ParseRequestedCalendarMonth()
        {
            string queryMonth = HttpHelper.GetQueryString("month").Trim();
            string queryYear = HttpHelper.GetQueryString("year").Trim();
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

            ViewDate = queryDate;
        }

        private void SetCalendarLiterals()
        {
            previousMonth.Text = ViewDate.AddMonths(-1).ToString("MMMM yyyy");
            linkPreviousMonth.Title = previousMonth.Text;
            currentMonth.Text = ViewDate.ToString("MMMM yyyy");
            nextMonth.Text = ViewDate.AddMonths(1).ToString("MMMM yyyy");
            linkNextMonth.Title = nextMonth.Text;
        }

    }
}