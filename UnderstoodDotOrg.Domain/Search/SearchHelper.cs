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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SearchHelper
    {
        private static Expression<Func<Article, bool>> GetBasePredicate(Member member)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // TODO: retrieve member language
            pred = pred.And(a => a.Language == "en");

            // Include only articles
            pred = pred.And(a => a.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId)));

            // Exclude articles marked for exclusion
            pred = pred.And(a => !a.OverrideTypes.Contains(ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization)));

            // TODO: Exclude items interacted by member

            return pred;                               
        }

        private static Expression<Func<Article, bool>> GetTimelyPredicate(DateTime date)
        {
            // NOTE: Search object must be on left side of comparison ie: 
            // DateTime.MinValue <= a.TimelyEnd will not be evaluated properly by Sitecore LINQ
            
            // No time specified in Sitecore so make comparison to date
            DateTime comparisonDate = date.Date;

            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

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

        private static Expression<Func<Article, bool>> GetMemberInterestsPredicate(Member member)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Include un-mapped interests
            pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(Guid.Empty)));

            // Include member interests
            foreach (var interest in member.Interests)
            {
                // prevent outer variable trap
                var i = interest;
                pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetMemberBackfillInterestsPredicate(Member member)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // Exclude member interests
            foreach (var interest in member.Interests)
            {
                // prevent outer variable trap
                var i = interest;
                pred = pred.And(a => !a.ParentInterests.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        #region Child predicates

        private static Expression<Func<Article, bool>> GetChildIEP504Predicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Unmapped
            pred = pred.Or(a => a.ApplicableEvaluations.Contains(ID.Parse(Guid.Empty)));

            Expression<Func<Article, bool>> innerPred = PredicateBuilder.True<Article>();

            if (child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPInProgress)
                || child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPYes))
            {
                pred = pred.Or(a => a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.EvaluatedIEP)));
            }
            else if (child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPNo))
            {
                pred = pred.Or(a => !a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.EvaluatedIEP)));
            }

            // TODO: 504 status
            if (child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504InProgress)
                || child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504Yes)) 
            {
                pred = pred.Or(a => a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.Evaluated504)));
            }
            else if (child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504No)) 
            {
                pred = pred.Or(a => !a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.Evaluated504)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildEvaluationPredicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Unmapped
            pred = pred.Or(a => a.DiagnosedConditions.Contains(ID.Parse(Guid.Empty)));

            if (child.EvaluationStatus == Guid.Parse(Constants.ChildEvaluation.StatusEvaluationInProgress)
                || child.EvaluationStatus == Guid.Parse(Constants.ChildEvaluation.StatusEvaluationYes))
            {
                pred = pred.Or(a => a.DiagnosedConditions.Contains(ID.Parse(Constants.ArticleTags.ConditionDiagnosed)));
            }
            else if (child.EvaluationStatus == Guid.Parse(Constants.ChildEvaluation.StatusEvaluationNo))
            {
                pred = pred.Or(a => a.DiagnosedConditions.Contains(ID.Parse(Constants.ArticleTags.ConditionUndiagnosed)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildDiagnosisPredicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Include un tagged
            pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Guid.Empty)));

            // Include content tagged with All
            pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Constants.ArticleTags.AllChildDiagnosis)));

            foreach (var diagnosis in child.Diagnoses)
            {
                // prevent outer variable trap
                var d = diagnosis;
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(d.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildGradesPredicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Include un tagged
            pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Guid.Empty)));
            
            // Include content tagged with All
            pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades)));

            foreach (var grades in child.Grades)
            {
                // prevent outer variable trap
                var g = grades;
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(g.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildIssuesPredicate(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Include un tagged
            pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Guid.Empty)));
            
            // Include content tagged with All
            pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Constants.ArticleTags.AllChildIssues)));

            foreach (var issues in child.Issues)
            {
                // prevent outer variable trap
                var i = issues;
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildPredicates(Child child)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>()
                .And(GetChildGradesPredicate(child))
                .And(GetChildIssuesPredicate(child))
                .And(GetChildDiagnosisPredicate(child))
                .And(GetChildIEP504Predicate(child))
                .And(GetChildEvaluationPredicate(child));

            return pred;
        }

        #endregion

        private static Expression<Func<Article, bool>> GetMustReadPredicate()
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            pred = pred.And(a => a.ImportanceLevels.Contains(ID.Parse(Constants.ArticleTags.MustRead)));

            return pred;
        }

        private static Expression<Func<Article, bool>> GetExcludeArticlesPredicate(List<Article> articles)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // TODO: investigate bug where and predicate and ItemId fails

            return pred;
        }

        private static List<int> GetRandomKeys(IQueryable<Article> query)
        {
            List<int> keys = new List<int>();
            int totalMatches = query.GetResults().TotalSearchResults;
            int limit = Math.Min(totalMatches, 8); // TODO: use constant
            Random rand = new Random();
            while (keys.Count != limit)
            {
                int r = rand.Next(totalMatches);
                if (!keys.Contains(r))
                {
                    keys.Add(r);
                }
            }

            return keys;
        }

        private static List<Article> GetRandomBucket(IQueryable<Article> query)
        {
            List<Article> articles = new List<Article>();

            foreach (int i in GetRandomKeys(query))
            {
                Article random = (i == 0) ? query.First() : query.Skip(i).First();

                articles.Add(random);
            }

            return articles;
        }

        public static List<Article> GetArticles(Member member, Child child, DateTime date)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");
            using (var ctx = index.CreateSearchContext())
            {
                // Pre-process
                var allArticlesQuery = ctx.GetQueryable<Article>()
                                    .Where(GetBasePredicate(member));

                // Inclusion/Exclusion processing based on member and child
                var matchingArticlesQuery = allArticlesQuery
                                    .Where(GetMemberInterestsPredicate(member))
                                    .Where(GetChildPredicates(child));

                // 1 - Child Grade
                var firstQuery = matchingArticlesQuery.Where(GetChildGradesPredicate(child));
                List<Article> firstMatches = GetRandomBucket(firstQuery);

                // 2 - Child Issues / Diagnosis
                var secondQuery = matchingArticlesQuery.Where(GetChildDiagnosisPredicate(child))
                                    .Where(GetChildIssuesPredicate(child))
                                    .Where(GetExcludeArticlesPredicate(firstMatches));

                List<Article> secondMatches = GetRandomBucket(secondQuery);

                // 3 - Parent interest
                var thirdQuery = matchingArticlesQuery.Where(GetMemberInterestsPredicate(member))
                                    .Where(GetExcludeArticlesPredicate(firstMatches))
                                    .Where(GetExcludeArticlesPredicate(secondMatches));
                List<Article> thirdMatches = GetRandomBucket(thirdQuery);

                // 4 - Must read
                var fourthQuery = matchingArticlesQuery.Where(GetMustReadPredicate())
                                    .Where(GetExcludeArticlesPredicate(firstMatches))
                                    .Where(GetExcludeArticlesPredicate(secondMatches))
                                    .Where(GetExcludeArticlesPredicate(thirdMatches));
                List<Article> fourthMatches = GetRandomBucket(fourthQuery);

                // 5 - IEP/504
                var fifthQuery = matchingArticlesQuery.Where(GetChildIEP504Predicate(child))
                                    .Where(GetExcludeArticlesPredicate(firstMatches))
                                    .Where(GetExcludeArticlesPredicate(secondMatches))
                                    .Where(GetExcludeArticlesPredicate(thirdMatches))
                                    .Where(GetExcludeArticlesPredicate(fourthMatches));
                List<Article> fifthMatches = GetRandomBucket(fifthQuery);

                List<Article> toProcess = new List<Article>();
                toProcess.AddRange(firstMatches);
                toProcess.AddRange(secondMatches);
                toProcess.AddRange(thirdMatches);
                toProcess.AddRange(fourthMatches);
                toProcess.AddRange(fifthMatches);

                // Timely and Must Read can overlap, so only include unique entries.

                var resp = System.Web.HttpContext.Current.Response;
                resp.Write(String.Format("Total articles to search: {0}<br>", allArticlesQuery.GetResults().TotalSearchResults));
                resp.Write(String.Format("Matches: {0}<br>", matchingArticlesQuery.GetResults().TotalSearchResults));
                //resp.Write(String.Format("Timely: {0}<br>", timelyArticles.Count()));
                //resp.Write(String.Format("Must: {0}<br><br>", mustReadArticles.Count()));

                foreach (Article a in toProcess)
                {
                    resp.Write(String.Format("{0} - {1} ({2})<br>", a.ItemId.ToString(), a.Name, a.Language));
                }

                resp.Write("<br><br>");
            }  

            return results;
        }
    }
}
