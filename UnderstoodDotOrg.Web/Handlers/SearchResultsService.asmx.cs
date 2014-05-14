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
        public ResultSet SearchAllArticles(string terms, string type, int page)
        {
            ResultSet results = new ResultSet();

            int totalResults = 0;
            List<Article> articles = SearchHelper.PerformArticleSearch(terms, type, page, out totalResults);
            var query = from a in articles
                        let i = a.GetItem()
                        select new SearchArticle
                        {
                            Title = i.Name,
                            Url = i.GetUrl(),
                            Thumbnail = ((DefaultArticlePageItem)i).GetArticleThumbnailUrl(230, 129),
                            Blurb = "Lorem ipsum...",
                            Type = ""
                        };

            results.Articles = query.ToList();
            results.TotalMatches = totalResults;

            results.HasMoreResults = HasMoreResults(page, Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE, results.Articles.Count(), totalResults);

            return results;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public BehaviorResultSet SearchBehaviorArticles(string challenge, string grade, int page)
        {
            BehaviorResultSet results = new BehaviorResultSet();

            int totalResults = 0;

            List<BehaviorAdvice> articles = SearchHelper.PerformBehaviorArticleSearch(challenge, grade, page, out totalResults);
            //var query = from a in articles
            //            let i = a.GetItem()
            //            let ba = new BehaviorAdvicePageItem

            return results;
        }

        private bool HasMoreResults(int currentPage, int entriesPerPage, int currentEntriesTotal, int totalResults)
        {
            int currentResultTotal = ((currentPage - 1) * entriesPerPage) + currentEntriesTotal;
            return currentResultTotal < totalResults;
        }
    }
}
