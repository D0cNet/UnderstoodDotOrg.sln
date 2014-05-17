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
    public partial class DecisionAnswersFolderItem
    {
        public IEnumerable<DecisionAnswerItem> GetAnswers()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(DecisionAnswerItem.TemplateId))
                .Select(i => (DecisionAnswerItem)i);
        }
    }
}