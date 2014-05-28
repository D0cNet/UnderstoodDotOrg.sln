using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Search
{
    public class EventPage : SearchResultItem
    {
        [IndexField("event_date")]
        public DateTime EventDate { get; set; }

        [IndexField("_event_date_utc")]
        public DateTime EventDateUtc { get; set; }

        [IndexField(Constants.SolrFields.EventIssues)]
        public IEnumerable<ID> Issues { get; set; }

        [IndexField(Constants.SolrFields.EventGrades)]
        public IEnumerable<ID> Grades { get; set; }

        [IndexField(Constants.SolrFields.EventTopics)]
        public IEnumerable<ID> Topics { get; set; }
    }
}
