using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool
{
    public partial class AssistiveToolsGradesFolderItem
    {
        public IEnumerable<AssistiveToolsGradeRangeItem> GetGradeRanges()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(AssistiveToolsGradeRangeItem.TemplateId))
                .Select(i => (AssistiveToolsGradeRangeItem)i);
        }
    }
}