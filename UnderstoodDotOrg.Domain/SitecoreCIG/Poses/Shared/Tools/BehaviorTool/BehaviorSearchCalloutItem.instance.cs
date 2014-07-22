using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Tools.BehaviorTool
{
    public partial class BehaviorSearchCalloutItem 
    {
        public List<ListItem> GetGradeChoices()
        {
            var choices = new List<ListItem>();
            choices.Add(new ListItem(DictionaryConstants.SelectChallengeLabel, string.Empty));

            var grades = CalloutGradeChoices.ListItems.FilterByContextLanguageVersion()
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