using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search.Fields
{
    public class AllTemplatesField : IComputedIndexField
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
            var templates = new List<string>();
            this.GetAllTemplates(item.Template, templates);
            return templates;
        }

        public void GetAllTemplates(TemplateItem baseTemplate, List<string> list)
        {
            if (baseTemplate.ID != Sitecore.TemplateIDs.StandardTemplate)
            {
                string str = IdHelper.NormalizeGuid(baseTemplate.ID);
                list.Add(str);
                foreach (TemplateItem item in baseTemplate.BaseTemplates)
                {
                    this.GetAllTemplates(item, list);
                }
            }
        }

    }
}
