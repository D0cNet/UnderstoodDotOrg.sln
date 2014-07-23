using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages
{
    public partial class BehaviorToolsLandingPageItem
    {
        public List<ListItem> GetGradeChoices()
        {
            var choices = new List<ListItem>();
            choices.Add(new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            var grades = GradeDropdownChoices.ListItems
                            .Select(x => new GradeLevelItem(x))
                            .Select(x => new ListItem
                            {
                                Text = x.Name.Raw,
                                Value = x.ID.ToString()
                            });

            if (grades.Any())
            {
                choices.AddRange(grades);
            }

            return choices;
        }
    }
}