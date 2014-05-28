using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Domain.Search.Fields
{
    public class EventDateUtcField : IComputedIndexField
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
            if (item == null || item.Template == null)
            {
                return null;
            }

            if (!item.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                return null;
            }

            BaseEventDetailPageItem eventPage = item;
            
            return eventPage.GetEventDateUtc() ?? DateTime.MinValue;
        }
    }
}
