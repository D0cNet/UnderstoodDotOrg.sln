using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;

namespace UnderstoodDotOrg.Domain.Search.Fields
{
    public class GradeLevelField : IComputedIndexField
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

            if (!item.InheritsTemplate(AssistiveToolsReviewPageItem.TemplateId))
            {
                return null;
            }

            AssistiveToolsReviewPageItem toolPage = item;

            double offGrade = GetGradeValue(toolPage.OffGrade);
            double targetGrade = GetGradeValue(toolPage.TargetGrade);
            double onGrade = GetGradeValue(toolPage.OnGrade);

            double offGradeMultiplier = GetMultiplierConfigValue(Constants.Settings.GradeLevelOffMultiplier);
            double targetGradeMultipler = GetMultiplierConfigValue(Constants.Settings.GradeLevelTargetMultiplier);
            double onGradeMultiplier = GetMultiplierConfigValue(Constants.Settings.GradeLevelOnMultiplier);

            return (offGrade * offGradeMultiplier) + (targetGrade * targetGradeMultipler) + (onGrade * onGradeMultiplier);
        }

        private double GetGradeValue(CustomIntegerField field)
        {
            return (!string.IsNullOrEmpty(field.Raw)) ? field.Integer : 0;
        }

        private double GetMultiplierConfigValue(string key)
        {
            double multiplier;

            // Fallback
            if (!Double.TryParse(Sitecore.Configuration.Settings.GetSetting(key), out multiplier))
            {
                multiplier = 1;
            }

            return multiplier;
        }
    }
}
