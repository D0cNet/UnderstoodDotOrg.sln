using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search.JSON
{
    public class BehaviorResultSet
    {
        public List<SearchBehaviorArticle> Matches { get; set; }
        public bool HasMoreResults { get; set; }
        public int TotalMatches { get; set; }
    }
}
