using Sitecore.Data;
using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SearchHelper
    {
        public static List<Article> GetArticles(Member member, Child child, DateTime date)
        {
            // Temporarily use template IDs instead of using inherited value until Solr index is updated

            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex("sitecore_web_index"); // TEMP: Constants.CURRENT_INDEX_NAME
            using (var ctx = index.CreateSearchContext())
            {
                var filtered = ctx.GetQueryable<Article>()
                                    .Where(a => a.TemplateId == ID.Parse(AudioArticlePageItem.TemplateId)
                                        || a.TemplateId == ID.Parse(VideoArticlePageItem.TemplateId)
                                        || a.TemplateId == ID.Parse(BasicArticlePageItem.TemplateId));

                var resp = System.Web.HttpContext.Current.Response;
                resp.Write("Results: <br><br>");
                foreach (var f in filtered)
                {
                    resp.Write(String.Format("{0} - {1}<br>", f.ItemId.ToString(), f.Name));
                }
                resp.Write("<br><br>");
            }  

            return results;
        }
    }
}
