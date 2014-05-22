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
    }
}
