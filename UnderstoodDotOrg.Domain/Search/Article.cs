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
    public class Article : SearchResultItem
    {
        [IndexField("child_grades")]
        public IEnumerable<ID> ChildGrades { get; set; }

        [IndexField("child_issues")]
        public IEnumerable<ID> ChildIssues { get; set; }

        [IndexField("child_diagnoses")]
        public IEnumerable<ID> ChildDiagnoses { get; set; }

        [IndexField("override_type")]
        public IEnumerable<ID> OverrideTypes { get; set; }

        [IndexField("date_start")]
        public DateTime TimelyStart { get; set; }

        [IndexField("date_end")]
        public DateTime TimelyEnd { get; set; }

        [IndexField("applicable_interests")]
        public IEnumerable<ID> ParentInterests { get; set; }

        [IndexField("alltemplates")]
        public IEnumerable<ID> Templates { get; set; }

        [IndexField("importance_level")]
        public IEnumerable<ID> ImportanceLevels { get; set; }

        [IndexField("other_applicable_evaluations")]
        public IEnumerable<ID> ApplicableEvaluations { get; set; }

        [IndexField("diagnosed_condition")]
        public IEnumerable<ID> DiagnosedConditions { get; set; }
    }
}
