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

            int blurbLimit = 150; // TODO: move to constant
            SearchResultsItem item = Sitecore.Context.Database.GetItem(Constants.Pages.SearchResults);
            if (item != null && !string.IsNullOrEmpty(item.SearchResultSummaryCharacterLimit.Raw))
            {
                blurbLimit = item.SearchResultSummaryCharacterLimit.Integer;
            }

            int totalResults = 0;
            List<Article> articles = SearchHelper.PerformArticleSearch(terms, type, page, out totalResults);
            List<SearchArticle> searchArticles = new List<SearchArticle>();
            foreach (Article article in articles)
            {
                DefaultArticlePageItem articleItem = article.GetItem();
                if (articleItem == null)
                {
                    continue;
                }

                // Handle cases such as invalid link format exception
                try
                {
                    var sa = new SearchArticle
                    {
                        Title = Common.Helpers.TextHelper.HighlightSearchTitle(terms, HttpUtility.HtmlDecode(articleItem.ContentPage.PageTitle.Rendered)),
                        Url = articleItem.GetUrl(),
                        Thumbnail = articleItem.GetArticleThumbnailUrl(230, 129),
                        Blurb = Common.Helpers.TextHelper.TruncateText(
                            Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(articleItem.ContentPage.BodyContent.Raw)), blurbLimit),
                        Type = articleItem.GetArticleType()
                    };

                    searchArticles.Add(sa);
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Error populating search result", ex, this);
                }
            }

            results.Articles = searchArticles;
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

            int offset = (page - 1) * Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE;

            var pagedArticles = articles.Skip(offset).Take(Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE);

            var query = pagedArticles
                .Select(a => (BehaviorAdvicePageItem)a.GetItem())
                .Where(a => a != null)
                .Select(a => new SearchBehaviorArticle
                {
                    Title = a.TipTitle.Raw,
                    Url = a.GetUrl(),
                    CommentCount = Services.TelligentService.TelligentService.GetTotalComments(a.BlogId, a.BlogPostId),
                    HelpfulCount = Services.TelligentService.TelligentService.GetTotalLikes(a.ContentId)
                });

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
