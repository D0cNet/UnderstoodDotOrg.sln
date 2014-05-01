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
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Solr;
using Sitecore.ContentSearch.Linq.Utilities;
using System.Linq.Expressions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SearchHelper
    {
        private static Expression<Func<Article, bool>> GetBasePredicate()
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // Include only articles
            pred = pred.And(a => a.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId)));

            // Exclude articles marked for exclusion
            pred = pred.And(a => !a.OverrideTypes.Contains(ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization)));

            return pred;                               
        }

        private static Expression<Func<Article, bool>> GetTimelyPredicate(DateTime date)
        {
            // NOTE: Search object must be on left side of comparison ie: 
            // DateTime.MinValue <= a.TimelyEnd will not be evaluated properly by Sitecore LINQ
            
            // No time specified in Sitecore so make comparison to date
            DateTime comparisonDate = date.Date;

            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();
            
            // No dates specified
            pred = pred
                .Or(a => a.TimelyStart == DateTime.MinValue && a.TimelyEnd == DateTime.MinValue);

            // Start date only
            pred = pred
                .Or(a => a.TimelyStart != DateTime.MinValue && a.TimelyEnd == DateTime.MinValue
                && a.TimelyStart <= comparisonDate);

            // End date only
            pred = pred
                .Or(a => a.TimelyStart == DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
                && a.TimelyEnd >= comparisonDate);

            // Start and end dates
            pred = pred
                .Or(a => a.TimelyStart != DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
                && a.TimelyStart <= comparisonDate && a.TimelyEnd >= comparisonDate);

            return pred;
        }

        private static Expression<Func<Article, bool>> GetMemberPredicate(Member member)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // TODO: Exclude items interacted by member

            // TODO: Include items which have no interests mapped
            

            // Include member interests
            foreach (var interest in member.Interests)
            {
                // prevent outer variable trap
                var i = interest;
                pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildPredicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // TODO: Include items which have no grades

            // TODO: Include items which have no diagnosis

            // TODO: Include items which have no issues

            // TODO: 504 status

            // TODO: IEP status

            // TODO: Evaluation status

            // Include All diagnosis
            pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Constants.ArticleTags.AllChildDiagnosis)));

            // Include child Diagnosis
            foreach (var diagnosis in child.Diagnoses)
            {
                // prevent outer variable trap
                var d = diagnosis;
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(d.Key)));
            }

            // Include All grades
            pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades)));

            // Include child grades
            foreach (var grades in child.Grades)
            {
                // prevent outer variable trap
                var g = grades;
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(g.Key)));
            }

            // Include All issues
            pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Constants.ArticleTags.AllChildIssues)));

            // Include child grades
            foreach (var issues in child.Issues)
            {
                // prevent outer variable trap
                var i = issues;
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        public static List<Article> GetArticles(Member member, Child child, DateTime date)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex("sitecore_web_index"); // TEMP: Constants.CURRENT_INDEX_NAME
            using (var ctx = index.CreateSearchContext())
            {
                var filtered = ctx.GetQueryable<Article>()
                                    .Where(GetBasePredicate())
                                    .Where(GetTimelyPredicate(date))
                                    .Where(GetMemberPredicate(member))
                                    .Where(GetChildPredicate(child));

                var resp = System.Web.HttpContext.Current.Response;
                resp.Write(String.Format("Results ({0}): <br><br>", filtered.GetResults().TotalSearchResults));
                foreach (Article f in filtered.Take(40))
                {
                    resp.Write(String.Format("{0} - {1}<br>", f.ItemId.ToString(), f.Name));
                }
                resp.Write("<br><br>");
            }  

            return results;
        }
    }
}
