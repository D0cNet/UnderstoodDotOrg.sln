using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search {
    public class EventArchiveSearch : SearchResultItem {
        /// <summary>
        /// EffectiveFrom field
        /// </summary>
        [TypeConverter(typeof(IndexFieldDateTimeValueConverter))]
        [IndexField("Event Date")]
        public DateTime EventDate { get; set; }

        [IndexField("Heading")]
        public string Heading { get; set; }

        [IndexField("SubHeading")]
        public string SubHeading { get; set; }

        [IndexField("Section Title")]
        public string SectionTitle { get; set; }

        [IndexField("Page Title")]
        public string PageTitle { get; set; }

        [IndexField("Page Summary")]
        public string PageSummary { get; set; }

        [IndexField("Body Content")]
        public string BodyContent { get; set; }

        [IndexField("_template")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID TemplateId { get; set; }

        [IndexField("ChildIssue")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID ChildIssueID { get; set; }

        [IndexField("Grade")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID GradeID { get; set; }

        [IndexField("Topic")]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public ID TopicID { get; set; }

        List<ID> FeaturedID { get; set; }
    }
}
