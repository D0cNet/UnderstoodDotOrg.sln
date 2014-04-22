using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Common;
using Sitecore.Data.Fields;
using System.Web;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.Understood.Helper
{
    public class FormHelper
    {
        /// <summary>
        /// Get grades from taxonomy values
        /// </summary>
        /// <returns>List<ListItem></returns>
        public static List<ListItem> GetGrades()
        {
            List<ListItem> choices = new List<ListItem>();
            choices.Add(new ListItem() { Text = DictionaryConstants.Grades.SelectGrade, Value = String.Empty });

            var container = Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString());
            var grades = (from c in container.Children
                         let exclude = new CheckboxField(c.Fields["Exclude from website display"])
                         where !exclude.Checked
                         select new ListItem
                         {
                             Value = c.ID.ToString(),
                             Text = c.Fields["Name"].Value
                         });

            choices.AddRange(grades);

            return choices;
        }

        /// <summary>
        /// Get child challenges
        /// </summary>
        /// <returns>List<ListItem></returns>
        public static List<ListItem> GetChallenges()
        {
            List<ListItem> choices = new List<ListItem>();
            choices.Add(new ListItem() { Text = DictionaryConstants.SelectChallenge, Value = String.Empty });

            var container = Sitecore.Context.Database.GetItem(Constants.ChallengesContainer.ToString());
            var grades = (from c in container.Children
                          select new ListItem
                          {
                              Value = c.ID.ToString(),
                              Text = c.Fields["Challenge Name"].Value
                          });

            choices.AddRange(grades);

            return choices;
        }
    }
}
