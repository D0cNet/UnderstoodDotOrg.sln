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
    public class AssistiveToolReview : SearchResultItem
    {
        [IndexField("platforms")]
        public IEnumerable<ID> Platforms { get; set; }

        [IndexField("type")]
        public IEnumerable<ID> Technology { get; set; }

        [IndexField("issues")]
        public IEnumerable<ID> Issues { get; set; }
    }
}
