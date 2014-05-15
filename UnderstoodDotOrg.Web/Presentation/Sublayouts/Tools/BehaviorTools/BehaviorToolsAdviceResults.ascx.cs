using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Solr;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Web.Handlers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsAdviceResults : System.Web.UI.UserControl
    {
        private ChildChallengeItem _challenge;
        private GradeLevelItem _grade;

        private string SelectedGrade
        {
            get { return Request.QueryString[Constants.GRADE_QUERY_STRING] ?? String.Empty; }
        }

        private string SelectedChallenge
        {
            get { return Request.QueryString[Constants.CHALLENGE_QUERY_STRING] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validate challenge
            if (!String.IsNullOrEmpty(SelectedChallenge)) 
            {
                Item challenge = FindChildById(Constants.ChallengesContainer, SelectedChallenge);
                if (challenge == null)
                {
                    // TODO: display error
                    return;
                }

                _challenge = new ChildChallengeItem(challenge);
            }

            // Validate grade
            if (!String.IsNullOrEmpty(SelectedGrade))
            {
                Item grade = FindChildById(Constants.GradeContainer, SelectedGrade);
                if (grade == null)
                {
                    // TODO: display error
                    return;
                }

                _grade = new GradeLevelItem(grade);
            }

            BindContent();
            BindResults();
        }

        // TODO: create helper function?
        private Item FindChildById(Guid containerGuid, string selectedId)
        {
            Item child = null;

            Item container = Sitecore.Context.Database.GetItem(containerGuid.ToString());
            if (null != container)
            {
                var result = container.GetChildren().FirstOrDefault(x => x.ID.ToString() == selectedId);
                if (result != null)
                {
                    child = result;
                }
            }

            return child;
        }

        private void BindContent()
        {
            BehaviorToolsResultsPageItem resultsPage = new BehaviorToolsResultsPageItem(Sitecore.Context.Item);


        }

        private void BindResults()
        {
            // TODO: Search articles based on grade and challenge
            SearchResultsService srs = new SearchResultsService();
            var result = srs.SearchBehaviorArticles(SelectedChallenge, SelectedGrade, 1);

            if (result.Matches.Any())
            {
                rptResults.DataSource = result.Matches;
                rptResults.DataBind();
            }
        }
    }
}