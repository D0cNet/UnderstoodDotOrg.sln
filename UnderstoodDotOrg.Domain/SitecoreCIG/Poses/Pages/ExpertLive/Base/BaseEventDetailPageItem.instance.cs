using System;
using Sitecore.Data.Items;
using System.Linq;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base
{
    public partial class BaseEventDetailPageItem 
    {
        public string GetEventType()
        {
            // Webinar/chat
            if (InnerItem.IsOfType(ChatEventPageItem.TemplateId))
            {
                return DictionaryConstants.ChatLabel;
            }
            else if (InnerItem.IsOfType(WebinarEventPageItem.TemplateId))
            {
                return DictionaryConstants.WebinarLabel;
            }

            return String.Empty;
        }

        /// <summary>
        /// Returns event start date in format Mon Aug 13 at 7:00pm EST
        /// </summary>
        /// <returns></returns>
        public string GetFormattedEventStartDate()
        {
            DateTime eventDate = EventStartDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                return String.Format("{0:ddd MMM dd} at {1}", eventDate, GetFormattedEventStartTime());
            }

            return String.Empty;
        }

        /// <summary>
        /// Returns event start time in format 7:00pm EST
        /// </summary>
        /// <returns></returns>
        public string GetFormattedEventStartTime()
        {
            DateTime eventDate = EventStartDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                TimeZoneItem timezone = EventTimezone.Item;
                string zoneLabel = (timezone != null) ? timezone.Abbreviation.Rendered : string.Empty;

                string meridian = eventDate.ToString("tt").ToLower();

                return String.Format("{0:h:mm}{1} {2}", eventDate, meridian, zoneLabel);
            }

            return String.Empty;
        }

        /// <summary>
        /// Returns the start date with the format supplied
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetFormattedEventStartDate(string format)
        {
            DateTime eventDate = EventStartDate.DateTime;
            if (eventDate != DateTime.MinValue)
            {
                return eventDate.ToString(format);
            }

            return String.Empty;
        }

        public string GetFormattedArchiveEventDate()
        {
            DateTime? eventDate = GetEventStartDateUtc();
            if (eventDate.HasValue && eventDate.Value != DateTime.MinValue)
            {
                int daysElapsed = (DateTime.UtcNow - eventDate.Value).Days;
                if (daysElapsed > 0 && daysElapsed <= 30)
                {
                    return String.Format("{0} {1}", daysElapsed, DictionaryConstants.DaysAgoLabel);
                }
                else
                {
                    return eventDate.Value.ToString("MMM dd yyyy");
                }
            }

            return String.Empty;
        }

        public bool IsUpcoming()
        {
            DateTime? utc = GetEventEndDateUtc() ?? GetEventStartDateUtc();
            if (utc.HasValue)
            {
                return utc.Value > DateTime.UtcNow;
            }

            return false;
        }

        public DateTime? GetEventStartDateUtc()
        {
            return GetUtcDate(EventStartDate);
        }

        public DateTime? GetEventEndDateUtc()
        {
            return GetUtcDate(EventEndDate);
        }

        private DateTime? GetUtcDate(CustomDateField dateField)
        {
            DateTime? result = null;

            TimeZoneItem tz = EventTimezone.Item;
            DateTime eventDate = dateField.DateTime;

            if (tz != null && eventDate != DateTime.MinValue)
            {
                // Ensure timezone is unspecified before converting to UTC
                eventDate = DateTime.SpecifyKind(eventDate, DateTimeKind.Unspecified);

                try
                {
                    TimeZoneInfo eventTimezone = TimeZoneInfo.FindSystemTimeZoneById(tz.Timezone.Raw);

                    DateTime eventUtcDate = TimeZoneInfo.ConvertTimeToUtc(eventDate, eventTimezone);

                    result = eventUtcDate;
                }
                catch { }
            }

            return result;
        }

        public List<Guid> GetMatchingChildrenIds(Domain.Membership.Member member)
        {
            var matches = new List<Guid>();

            // Require parent interests and child
            if (member != null && member.Children.Count > 0)
            {
                foreach (var child in member.Children)
                {
                    // Child must have grade
                    if (child.Grades.Count == 0)
                    {
                        continue;
                    }

                    bool gradeMatch = false;
                    bool issueMatch = false;

                    var childGrade = child.Grades.FirstOrDefault();
                    var articleGrades = this.Grade.ListItems.Select(i => i.ID.Guid).ToList();

                    // Unmapped or All grades is considered a match in addition to child's grade
                    if (!articleGrades.Any()
                        || articleGrades.Contains(childGrade.Key))
                    {
                        gradeMatch = true;
                    }

                    if (child.Issues.Count == 0)
                    {
                        issueMatch = true;
                    }
                    else
                    {
                        var childIssues = child.Issues.Select(i => i.Key).ToList();
                        var articleIssues = this.ChildIssue.ListItems.Select(i => i.ID.Guid).ToList();


                        issueMatch = childIssues.Intersect(articleIssues).ToList().Count() > 0;

                    }

                    if (gradeMatch || issueMatch)
                    {
                        matches.Add(child.ChildId);
                    }
                }
            }

            return matches;
        }
    }
}