using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public class EventsLiveCalendarDay
    {

        public IEnumerable<BaseEventDetailPageItem> CurrentEvents { get; private set; }
        private DateTime CurrentDate { get; set; }

        public string AbbreviatedMonth
        {
            get
            {
                return CurrentDate.ToString("MMM");
            }
        }

        public string Day
        {
            get
            {
                return CurrentDate.Day.ToString();
            }
        }

        public string NamedDayOfWeek
        {
            get
            {
                return CurrentDate.DayOfWeek.ToString();
            }
        }

        public EventsLiveCalendarDay(DateTime inCurrentDate, IList<BaseEventDetailPageItem> inCurrentEvents = null)
        {
            CurrentDate = inCurrentDate;
            CurrentEvents = inCurrentEvents ?? new List<BaseEventDetailPageItem>();
        }

    }
}