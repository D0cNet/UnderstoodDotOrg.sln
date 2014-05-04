using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Search
{
    public class BehaviorAdvice : SearchResultItem
    {
        [IndexField(Constants.SolrFields.ChildGrades)]
        public IEnumerable<ID> ChildGrades { get; set; }

        [IndexField("child_challenges")]
        public IEnumerable<ID> ChildChallenges { get; set; }
    }
}
