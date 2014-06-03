using System;
using Sitecore.Data.Items;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
    public partial class AssistiveToolsSearchResultsPageItem
    {
        public IEnumerable<AssistiveToolsReviewPageItem> GetToolDetailPages()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(AssistiveToolsReviewPageItem.TemplateId))
                .Select(i => (AssistiveToolsReviewPageItem)i);
        }
    }
}