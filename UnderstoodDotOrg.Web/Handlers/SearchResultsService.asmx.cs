using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Domain.Search.JSON;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for SearchResultsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    
    [System.Web.Script.Services.ScriptService]
    public class SearchResultsService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public ResultSet SearchAllArticles(string terms, string type, int page, string lang)
        {
            ResultSet results = new ResultSet();

            SetContextLanguage(lang);

            int blurbLimit = 150;
            SearchResultsItem item = Sitecore.Context.Database.GetItem(Constants.Pages.SearchResults);
            if (item != null && !string.IsNullOrEmpty(item.SearchResultSummaryCharacterLimit.Raw))
            {
                blurbLimit = item.SearchResultSummaryCharacterLimit.Integer;
            }

            int totalResults = 0;
            List<Article> articles = SearchHelper.PerformArticleSearch(terms, type, page, out totalResults);
            var query = from a in articles
                        let i = new DefaultArticlePageItem(a.GetItem())
                        select new SearchArticle
                        {
                            Title = Common.Helpers.TextHelper.HighlightSearchTitle(terms, i.ContentPage.PageTitle.Rendered),
                            Url = i.GetUrl(),
                            Thumbnail = i.GetArticleThumbnailUrl(230, 129),
                            Blurb = Common.Helpers.TextHelper.TruncateText(
                                Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(i.ContentPage.BodyContent.Rendered)), blurbLimit),
                            Type = i.GetArticleType()
                        };

            results.Articles = query.ToList();
            results.TotalMatches = totalResults;

            results.HasMoreResults = HasMoreResults(page, Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE, results.Articles.Count(), totalResults);

            return results;
        }

        [WebMethod(EnableSession=true)]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public BehaviorResultSet SearchBehaviorArticles(string challenge, string grade, int page, string lang)
        {
            BehaviorResultSet results = new BehaviorResultSet();
            List<BehaviorAdvice> articles;

            SetContextLanguage(lang);

            int totalResults = 0;
            SessionSearchResult srs = new SessionSearchResult
            {
                Challenge = challenge,
                Grade = grade
            };

            // Look up challenge

            // Populate all results into session for article pages
            if ((Session != null && Session[Constants.SessionBehaviorSearchKey] != null) || page == 1)
            {
                articles = SearchHelper.GetAllBehaviorArticles(challenge, grade);
                srs.Results = articles;
                Session[Constants.SessionBehaviorSearchKey] = srs;
            }
            else
            {
                articles = ((SessionSearchResult)Session[Constants.SessionBehaviorSearchKey]).Results;
            }

            totalResults = srs.Results.Count();

            var pagedArticles = articles.Skip(page - 1).Take(Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE);

            var query = from a in pagedArticles
                        let i = new BehaviorAdvicePageItem(a.GetItem())
                        select new SearchBehaviorArticle
                        {
                            Title = i.TipTitle,
                            Url = i.GetUrl(),
                            CommentCount = CommunityHelper.GetTotalComments(i.BlogId, i.BlogPostId),
                            HelpfulCount = CommunityHelper.GetTotalLikes(i.ContentId)
                        };

            results.Matches = query.ToList();
            results.TotalMatches = totalResults;

            results.HasMoreResults = HasMoreResults(page, Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE, results.Matches.Count(), totalResults);

            return results;
        }

        private bool HasMoreResults(int currentPage, int entriesPerPage, int currentEntriesTotal, int totalResults)
        {
            int currentResultTotal = ((currentPage - 1) * entriesPerPage) + currentEntriesTotal;
            return currentResultTotal < totalResults;
        }

        private void SetContextLanguage(string lang)
        {
            Sitecore.Globalization.Language language;

            if (Sitecore.Globalization.Language.TryParse(lang, out language))
            {
                Sitecore.Context.SetLanguage(language, false);
            }
        }
    }
}
