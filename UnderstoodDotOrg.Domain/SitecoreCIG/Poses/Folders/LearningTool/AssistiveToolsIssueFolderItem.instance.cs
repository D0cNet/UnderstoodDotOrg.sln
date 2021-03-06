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
    public partial class AssistiveToolsIssueFolderItem
    {
        public IEnumerable<AssistiveToolsIssueItem> GetIssues()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(AssistiveToolsIssueItem.TemplateId))
                .Select(i => (AssistiveToolsIssueItem)i);
        }
    }
}