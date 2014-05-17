using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool
{
    public partial class DecisionQuestionCategoryFolderItem
    {
        public IEnumerable<DecisionQuestionPageItem> GetDecisionQuestions()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(DecisionQuestionPageItem.TemplateId))
                .Select(i => (DecisionQuestionPageItem)i);
        }
    }
}