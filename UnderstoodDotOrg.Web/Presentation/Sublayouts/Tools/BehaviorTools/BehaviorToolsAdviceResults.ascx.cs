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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsAdviceResults : System.Web.UI.UserControl
    {
        private ChildChallengeItem _challenge;

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
            // Validate challenge and grade
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

            BindContent();
            BindResults();
        }

        // TODO: create helper function?
        private Item FindChildById(Guid containerGuid, string id)
        {
            Item child = null;

            Item container = Sitecore.Context.Database.GetItem(containerGuid.ToString());
            if (null != container)
            {
                var result = container.GetChildren().FirstOrDefault(x => x.ID.ToString() == SelectedChallenge);
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

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                var results = ctx.GetQueryable<BehaviorAdvice>()
                                 .Where(i => i.TemplateId == Sitecore.Data.ID.Parse(BehaviorToolsAdvicePageItem.TemplateId)
                                    || i.TemplateId == Sitecore.Data.ID.Parse(BehaviorToolsAdviceVideoPageItem.TemplateId))
                                 .Where(i => i.ChildChallenges.Contains(Sitecore.Data.ID.Parse(SelectedChallenge)));

                foreach (var r in results)
                {

                }
            }  
        }
    }
}