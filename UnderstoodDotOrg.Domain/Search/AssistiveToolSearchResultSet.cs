using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;

namespace UnderstoodDotOrg.Domain.Search
{
    public class AssistiveToolSearchResultSet
    {
        public Guid CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string HelpModalContent { get; set; }
        public bool ShowHelpModal { get; set; }
        public int TotalCount { get; set; }
        public int DisplayCount { get; set; }
        public IEnumerable<AssistiveToolsReviewPageItem> SearchResults { get; set; }
        public bool HasMoreResults { get; set; }
    }
}
