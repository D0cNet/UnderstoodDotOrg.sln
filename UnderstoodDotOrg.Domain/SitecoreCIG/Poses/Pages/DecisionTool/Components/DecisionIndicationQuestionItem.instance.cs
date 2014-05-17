using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components
{
    public partial class DecisionIndicationQuestionItem
    {
        public IEnumerable<DecisionIndicationAnswerItem> GetIndicationAnswers()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(DecisionIndicationAnswerItem.TemplateId))
                .Select(i => (DecisionIndicationAnswerItem)i);
        }
    }
}