using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Extensions;
using CustomItemGenerator.Fields.ListTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;

namespace UnderstoodDotOrg.Domain.Search.Fields
{
    public class EventDetailField : IComputedIndexField
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

            // Skip non-events
            if (!item.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                return null;
            }

            var eventPage = new BaseEventDetailPageItem(item);
            bool fieldMatch = true;
            CustomTreeListField target = null;

            // Only index the following fields
            switch (FieldName)
            {
                case UnderstoodDotOrg.Common.Constants.SolrFields.EventGrades:
                    target = eventPage.Grade;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.EventIssues:
                    target = eventPage.ChildIssue;
                    break;
                case UnderstoodDotOrg.Common.Constants.SolrFields.EventTopics:
                    target = eventPage.ParentInterest;
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
