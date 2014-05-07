using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for SearchResults
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    
    [System.Web.Script.Services.ScriptService]
    public class SearchResults : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public List<SearchArticle> ShowMoreResults(string terms, string type, int page)
        {
            int results = 0;
            List<Article> articles = SearchHelper.GetSearchResultArticles(terms, type, page, out results);
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

            return query.ToList();
        }
    }
}
