using CustomItemGenerator.Fields.ListTypes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.Search.Fields
{
    public class ArticleMappingField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var indexItem = indexable as SitecoreIndexableItem;
            if (indexItem == null)
            {
                return null;
            }
            var item = (Sitecore.Data.Items.Item)indexItem.Item;
            if (item == null)
            {
                return null;
            }

            // Skip non-articles
            if (!item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                return null;
            }

            var article = new DefaultArticlePageItem(item);
            bool fieldMatch = true;
            CustomTreeListField target = null;

            // Only index the following fields
            switch (FieldName)
            {
                case UnderstoodDotOrg.Common.Constants.SolrFields.ChildDiagnoses:
                    target = article.ChildDiagnoses;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ChildGrades:
                    target = article.ChildGrades;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ChildIssues:
                    target = article.ChildIssues;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ApplicableEvaluations:
                    target = article.OtherApplicableEvaluations;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.DiagnosedConditions:
                    target = article.DiagnosedCondition;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ImportanceLevels:
                    target = article.ImportanceLevel;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.OverrideTypes:
                    target = article.OverrideType;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ParentInterests:
                    target = article.ApplicableInterests;
                    break;
                default:
                    fieldMatch = false;
                    break;
            }

            return fieldMatch ? GetSelectedItems(target) : null;
        }

        public List<string> GetSelectedItems(CustomTreeListField field)
        {
            // Return a list with an empty guid so we can search via Solr for unmapped fields
            if (!field.ListItems.Any())
            {
                return new List<string>() { 
                    IdHelper.NormalizeGuid(ID.Parse(Guid.Empty)) 
                };
            }

            var query = from i in field.ListItems
                         select IdHelper.NormalizeGuid(i.ID);

            return query.ToList();
        }

    }
}
