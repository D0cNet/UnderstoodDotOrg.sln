using System;
using Sitecore.Data.Items;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
    public partial class AssistiveToolsSearchResultsPageItem
    {
        public static IEnumerable<AssistiveToolsReviewPageItem> GetSearchResults(Guid? issue, Guid? grade, Guid? technology, string searchTerm, int page)
        {
            // TODO: Implement mapping of dropdown values to data template fields used for tagging in Sitecore

            return SearchHelper.GetAssitiveToolsReviewPages(issue, grade, technology, searchTerm, page);
        }
    }
}