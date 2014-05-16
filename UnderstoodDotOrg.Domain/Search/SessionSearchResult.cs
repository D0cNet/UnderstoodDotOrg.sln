using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SessionSearchResult
    {
        public List<BehaviorAdvice> Results { get; set; }
        public string Challenge { get; set; }
        public string Grade { get; set; }
        public string SearchUrlTitle { get; set; }
    }
}
