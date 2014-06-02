using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search
{
    public class Expert : SearchResultItem
    {
        [IndexField("event_participation")]
        public IEnumerable<ID> EventParticipation { get; set; }
    }
}
