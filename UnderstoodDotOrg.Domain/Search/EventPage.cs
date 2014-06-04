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
        [IndexField("expert")]
        public ID Expert { get; set; }

        [IndexField("event_start_date")]
        public DateTime EventStartDate { get; set; }
        
        [IndexField("event_end_date")]
        public DateTime EventEndDate { get; set; }

        [IndexField(Constants.SolrFields.EventEndDateUtc)]
        public DateTime EventEndDateUtc { get; set; }

        [IndexField(Constants.SolrFields.EventStartDateUtc)]
        public DateTime EventStartDateUtc { get; set; }

        [IndexField(Constants.SolrFields.EventIssues)]
        public IEnumerable<ID> Issues { get; set; }

        [IndexField(Constants.SolrFields.EventGrades)]
        public IEnumerable<ID> Grades { get; set; }

        [IndexField(Constants.SolrFields.EventTopics)]
        public IEnumerable<ID> Topics { get; set; }
    }
}
