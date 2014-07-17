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
    public class Article : SearchResultItem
    {
        [IndexField("author_name")]
        public ID Author { get; set; }

        [IndexField("page_title")]
        public string PageTitle { get; set; }
        
        [IndexField(Constants.SolrFields.ChildGrades)]
        public IEnumerable<ID> ChildGrades { get; set; }

        [IndexField(Constants.SolrFields.ChildIssues)]
        public IEnumerable<ID> ChildIssues { get; set; }

        [IndexField(Constants.SolrFields.ChildDiagnoses)]
        public IEnumerable<ID> ChildDiagnoses { get; set; }

        [IndexField(Constants.SolrFields.OverrideTypes)]
        public IEnumerable<ID> OverrideTypes { get; set; }

        [IndexField(Constants.SolrFields.TimelyStart)]
        public DateTime TimelyStart { get; set; }

        [IndexField(Constants.SolrFields.TimelyEnd)]
        public DateTime TimelyEnd { get; set; }

        [IndexField(Constants.SolrFields.ParentInterests)]
        public IEnumerable<ID> ParentInterests { get; set; }

        [IndexField(Constants.SolrFields.Templates)]
        public IEnumerable<ID> Templates { get; set; }

        [IndexField(Constants.SolrFields.ImportanceLevels)]
        public IEnumerable<ID> ImportanceLevels { get; set; }

        [IndexField(Constants.SolrFields.ApplicableEvaluations)]
        public IEnumerable<ID> ApplicableEvaluations { get; set; }

        [IndexField(Constants.SolrFields.DiagnosedConditions)]
        public IEnumerable<ID> DiagnosedConditions { get; set; }

        [IndexField(Constants.SolrFields.SourceItem)]
        public ID SourceItem { get; set; }
    }
}
