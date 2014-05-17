using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages
{
    public partial class DecisionToolLandingPageItem
    {
        public IEnumerable<DecisionQuestionCategoryFolderItem> GetDecisionQuestionCategories()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(DecisionQuestionCategoryFolderItem.TemplateId))
                .Select(i => (DecisionQuestionCategoryFolderItem)i);
        }

        public DecisionToolResultsPageItem GetDecisionToolResultsPage()
        {
            return InnerItem.Children
                .FirstOrDefault(i => i.IsOfType(DecisionToolResultsPageItem.TemplateId));
        }
    }
}