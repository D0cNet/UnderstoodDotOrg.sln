using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool
{
    public partial class DecisionIndicationQuestionsFolderItem
    {
        public IEnumerable<DecisionIndicationQuestionItem> GetIndicationQuestions()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(DecisionIndicationQuestionItem.TemplateId))
                .Select(i => (DecisionIndicationQuestionItem)i);
        }
    }
}