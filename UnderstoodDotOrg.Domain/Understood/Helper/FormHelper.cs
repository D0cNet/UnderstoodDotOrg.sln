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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;

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

        public static List<ListItem> GetParentInterests(string initialChoiceLabel)
        {
            var interests = SearchHelper.GetParentInterests()
                                .Where(i => i.GetItem() != null)
                                .Select(i => new ParentInterestItem(i.GetItem()))
                                .Select(i => new ListItem
                                {
                                    Text = HttpUtility.HtmlDecode(i.InterestName.Raw),
                                    Value = i.ID.ToString()
                                });

            return PopulateList(initialChoiceLabel, interests);
        }

        public static List<ListItem> GetIssues(string initialChoiceLabel)
        {
            var container = Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString());
            var issues = container.Children.FilterByContextLanguageVersion()
                            .Select(i => new ChildIssueItem(i))
                            .Where(i => !i.ExcludeFromWebsiteDisplay.Checked)
                            .Select(i => new ListItem
                            {
                                Text = i.IssueName.Raw,
                                Value = i.ID.ToString()
                            });

            return PopulateList(initialChoiceLabel, issues);
        }

        /// <summary>
        /// Returns a list of child grades defined in child taxonomy
        /// </summary>
        /// <returns>Collection of child grades where value is the respective Sitecore Guid</returns>
        public static List<ListItem> GetGrades(string initialChoiceLabel)
        {
            var container = Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString());
            var grades = container.Children.FilterByContextLanguageVersion()
                            .Select(i => new GradeLevelItem(i))
                            .Where(g => !g.ExcludeFromWebsiteDisplay.Checked)
                            .Select(g => new ListItem
                            {
                                Text = g.Name,
                                Value = g.ID.ToString()
                            });

            return PopulateList(initialChoiceLabel, grades);
        }

        /// <summary>
        /// Returns a list of child challenges
        /// </summary>
        /// <returns>Collection of child challenges where value is the respective Sitecore Guid</returns>
        public static List<ListItem> GetChallenges(string initialChoiceLabel)
        {
            var container = Sitecore.Context.Database.GetItem(Constants.ChallengesContainer.ToString());
            var challenges = container.Children.FilterByContextLanguageVersion()
                                 .Select(i => new ChildChallengeItem(i))
                                 .Select(c => new ListItem
                                 {
                                     Value = c.ID.ToString(),
                                     Text = c.ChallengeName
                                 });

            return PopulateList(initialChoiceLabel, challenges);
        }
        #endregion

        public static List<ListItem> GetSearchArticleTypes()
        {
            var container = Sitecore.Context.Database.GetItem(Constants.SearchFilterTypesContainer.ToString());
            var types = container.Children.FilterByContextLanguageVersion()
                            .Select(i => new SearchFilterTypeItem(i))
                            .Select(f => new ListItem
                            {
                                Value = f.ID.ToString(),
                                Text = f.FilterLabel.Raw
                            });

            return PopulateList(DictionaryConstants.FilterByLabel, types);
        }

        #region URL Helpers

        public static string GetBehaviorResultsUrl(string challengeGuid, string gradeGuid)
        {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.BehaviorToolsResults);
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

        public static string GetSearchResultsUrl(string term, string type)
        {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.SearchResults.ToString());
            if (item != null)
            {
                Dictionary<string, string> queryParams = new Dictionary<string, string>()
                {
                    { Constants.SEARCH_TERM_QUERY_STRING, term },
                    { Constants.SEARCH_TYPE_FILTER_QUERY_STRING, type }
                };
                return AssembleUrl(item.GetUrl(), queryParams);
            }
            return String.Empty;
        }

        public static string GetRecommendationUrl() {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.Recommendation.ToString());
            if (item != null) {
                return item.GetUrl();
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
                         select String.Format("{0}={1}", qp.Key, System.Net.WebUtility.UrlEncode(qp.Value))).ToArray();

            string queryString = (pairs.Any()) ?
                String.Concat("?", String.Join("&", pairs)) :
                String.Empty;

            return String.Concat(baseUrl, queryString); 
        }

        #endregion
    }
}
