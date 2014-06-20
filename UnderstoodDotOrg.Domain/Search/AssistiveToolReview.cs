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
    public class AssistiveToolReview : SearchResultItem
    {
        [IndexField("platforms")]
        public IEnumerable<ID> Platforms { get; set; }

        [IndexField("type")]
        public IEnumerable<ID> Technology { get; set; }

        [IndexField("issues")]
        public IEnumerable<ID> Issues { get; set; }

        [IndexField("quality")]
        public int QualityRating { get; set; }

        [IndexField("learning")]
        public int LearningRating { get; set; }

        [IndexField(Constants.SolrFields.GradeRating)]
        public int GradeRating { get; set; }

        [IndexField("publish_date")]
        public DateTime PublishDate { get; set; }
    }
}
