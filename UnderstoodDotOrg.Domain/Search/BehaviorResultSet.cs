using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search
{
    public class BehaviorResultSet
    {
        public List<BehaviorAdvice> Matches { get; set; }
        public bool HasMoreResults { get; set; }
        public int TotalMatches { get; set; }
    }
}
