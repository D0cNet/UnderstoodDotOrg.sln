using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Web;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Domain.Understood.Helper
{
    public class FormHelper
    {
        #region DropDownList Helpers
        private static List<ListItem> PopulateList(string initialChoiceLabel, IEnumerable<ListItem> choices)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(initialChoiceLabel, String.Empty));
            items.AddRange(choices);
            return items;
        }

        /// <summary>
        /// Returns a list of child grades defined in child taxonomy
        /// </summary>
        /// <returns>Collection of child grades where value is the respective Sitecore Guid</returns>
        public static List<ListItem> GetGrades()
        {
            var container = Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString());
            var grades = from c in container.Children.Select(x => new GradeLevelItem(x))
                         where !c.ExcludeFromWebsiteDisplay.Checked
                         select new ListItem
                         {
                             Text = c.Name,
                             Value = c.ID.ToString()
                         };
                         

            return PopulateList(DictionaryConstants.Grades.SelectGrade, grades);
        }

        /// <summary>
        /// Returns a list of child challenges
        /// </summary>
        /// <returns>Collection of child challenges where value is the respective Sitecore Guid</returns>
        public static List<ListItem> GetChallenges()
        {
            var container = Sitecore.Context.Database.GetItem(Constants.ChallengesContainer.ToString());
            var challenges = from c in container.Children.Select(x => new ChildChallengeItem(x))
                             select new ListItem
                             {
                                 Value = c.ID.ToString(),
                                 Text = c.ChallengeName
                             };

            return PopulateList(DictionaryConstants.SelectChallenge, challenges);
        }
        #endregion

        #region URL Helpers

        public static string GetBehaviorResultsUrl(string challengeGuid, string gradeGuid)
        {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.BehaviorToolsResults.ToString());
            if (item != null)
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>()
                {
                    { Constants.GRADE_QUERY_STRING, gradeGuid },
                    { Constants.CHALLENGE_QUERY_STRING, challengeGuid }
                };
                return AssembleUrl(item.GetUrl(), queryParams);
            }
            return String.Empty;
        }

        /// <summary>
        /// Returns a formatted URL with query string variables appended
        /// </summary>
        /// <param name="baseUrl">Base URL excluding any query string variables</param>
        /// <param name="queryParams">Dictionary with key, value paris where key is the query string variable name</param>
        /// <returns>Formatted URL string</returns>
        private static string AssembleUrl(string baseUrl, Dictionary<string, string> queryParams)
        {
            var pairs = (from qp in queryParams
                         where !String.IsNullOrEmpty(qp.Value) 
                         select String.Format("{0}={1}", qp.Key, qp.Value)).ToArray();

            string queryString = (pairs.Any()) ?
                String.Concat("?", String.Join("&", pairs)) :
                String.Empty;

            return String.Concat(baseUrl, queryString); 
        }

        #endregion
    }
}
