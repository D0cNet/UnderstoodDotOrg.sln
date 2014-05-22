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
    public class BehaviorArticleMappingField : IComputedIndexField
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

            // Skip non-behavior articles
            if (!item.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            {
                return null;
            }

            var article = new BehaviorAdvicePageItem(item);
            bool fieldMatch = true;
            CustomTreeListField target = null;

            // Only index the following fields
            switch (FieldName)
            {
                case UnderstoodDotOrg.Common.Constants.SolrFields.ChildChallenges:
                    target = article.ChildChallenges;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.ChildBehaviorGrades:
                    target = article.ChildGrades;
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
