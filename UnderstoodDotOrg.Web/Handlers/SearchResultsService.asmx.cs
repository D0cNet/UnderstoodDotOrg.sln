using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;

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
                            Thumbnail = "http://placehold.it/230x129&text=230x129",
                            Blurb = "Lorem ipsum...",
                            Type = "TODO"
                        };

            results.Articles = query.ToList();
            results.TotalMatches = totalResults;

            // Determine if there are more results to be paged
            int currentResultTotal = ((page - 1) * Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE) + results.Articles.Count();
            results.HasMoreResults = currentResultTotal < totalResults;

            return results;
        }
    }
}
