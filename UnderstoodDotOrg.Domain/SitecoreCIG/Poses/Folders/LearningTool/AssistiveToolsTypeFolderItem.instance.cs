using System;
using Sitecore.Data.Items;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool
{
    public partial class AssistiveToolsTypeFolderItem
    {
        public IEnumerable<AssistiveToolsTypeItem> GetTechTypes()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(AssistiveToolsTypeItem.TemplateId))
                .Select(i => (AssistiveToolsTypeItem)i);
        }
    }
}