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
        private static Expression<Func<Article, bool>> GetBasePredicate(Member member = null)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // TODO: retrieve member language
            pred = pred.And(a => a.Language == "en");

            // Exclude templates
            pred = pred.And(a => !a.Fullpath.Contains("/sitecore/templates/"));

            // Include only articles
            pred = pred.And(GetInheritsArticlePredicate());

            // Exclude articles marked for exclusion
            pred = pred.And(a => !a.OverrideTypes.Contains(ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization)));

            // TODO: Exclude items interacted by member - MemberActivity table
            if (member != null)
            {

            }

            return pred;                               
        }

        private static Expression<Func<Article, bool>> GetInheritsArticlePredicate()
        {
            return (a => a.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId)));
        }

        private static Expression<Func<Article, bool>> GetTimelyPredicate(DateTime date)
        {
            // NOTE: Search object must be on left side of comparison ie: 
            // DateTime.MinValue <= a.TimelyEnd will not be evaluated properly by Sitecore LINQ
            
            // No time specified in Sitecore so make comparison to date
            DateTime comparisonDate = date.Date;

            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            // Require true statement for sequence of and - Sitecore bug

            // Start date only
            pred = pred
                .Or(a => a.TimelyStart != DateTime.MinValue && a.TimelyEnd == DateTime.MinValue
                && a.TimelyStart <= comparisonDate);

            // End date only
            pred = pred
                .Or(a => a.TimelyStart == DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
                && a.TimelyEnd >= comparisonDate);

            // Start and end dates
            // Sitecore bug requires true statement first if you have a sequence of AND negation checks
            pred = pred
                .Or(a => a.Paths.Contains(Sitecore.ItemIDs.RootID) && 
                    a.TimelyStart != DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
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

            // Workaround Sitecore bug - require a single true condition
            pred = pred.And(GetAlwaysTruePredicate());
            
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

            innerPred = innerPred.And(GetAlwaysTruePredicate());

            if (child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPInProgress)
                || child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPYes))
            {
                innerPred = innerPred.And(a => a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.EvaluatedIEP)));
            }
            else if (child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPNo))
            {
                innerPred = innerPred.And(a => !a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.EvaluatedIEP)));
            }

            // 504 status
            if (child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504InProgress)
                || child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504Yes)) 
            {
                innerPred = innerPred.And(a => a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.Evaluated504)));
            }
            else if (child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504No)) 
            {
                innerPred = innerPred.And(a => !a.ApplicableEvaluations.Contains(ID.Parse(Constants.ArticleTags.Evaluated504)));
            }

            return pred.Or(innerPred);
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

        private static Expression<Func<Article, bool>> GetCombinedChildPredicate(Child child)
        {
            return PredicateBuilder.True<Article>()
                .And(GetChildGradesPredicate(child))
                .And(GetChildIssuesPredicate(child))
                .And(GetChildDiagnosisPredicate(child))
                .And(GetChildIEP504Predicate(child))
                .And(GetChildEvaluationPredicate(child));
        }

        #endregion

        private static Expression<Func<Article, bool>> GetMustReadPredicate()
        {
            return (a => a.ImportanceLevels.Contains(ID.Parse(Constants.ArticleTags.MustRead)));
        }

        private static Expression<Func<Article, bool>> GetAlwaysTruePredicate()
        {
            return (a => a.Paths.Contains(Sitecore.ItemIDs.RootID));
        }

        private static Expression<Func<Article, bool>> GetExcludeArticlesPredicate(List<Article> articles)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // Workaround Sitecore bug - require a single true condition
            pred = pred.And(GetAlwaysTruePredicate());
            
            foreach (Article article in articles)
            {
                var i = article;
                pred = pred.And(a => a.ItemId != i.ItemId);
            }

            return pred;
        }

        private static List<int> GetRandomKeys(IQueryable<Article> query, int totalKeys)
        {
            List<int> keys = new List<int>();
            int totalMatches = query.Take(1).GetResults().TotalSearchResults;
            int limit = Math.Min(totalMatches, totalKeys);
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

        private static List<Article> GetRandomBucketArticles(IQueryable<Article> query, int totalEntries)
        {
            List<Article> articles = new List<Article>();

            foreach (int i in GetRandomKeys(query, totalEntries))
            {
                Article random = (i == 0) ? query.Take(1).First() : query.Skip(i).Take(1).First();

                articles.Add(random);
            }

            return articles;
        }

        private static void AddFromBucket(IQueryable<Article> query, ref List<Article> result)
        {
            int currentEntries = result.Count();
            if (currentEntries < Constants.PERSONALIZATION_ARTICLES_PER_USER)
            {
                // Calculate remaining spots
                int spotsToFill = Math.Min(Constants.PERSONALIZATION_ARTICLES_PER_USER - currentEntries, Constants.PERSONALIZATION_ARTICLES_PER_BUCKET);
                result.AddRange(GetRandomBucketArticles(query, spotsToFill));
            }
        }

        public static List<Article> GetRandomMustReadArticles(int numberOfArticles)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex(Constants.ARTICLE_SEARCH_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                 var allArticlesQuery = ctx.GetQueryable<Article>()
                                    .Filter(GetBasePredicate())
                                    .Where(GetMustReadPredicate());

                 results = GetRandomBucketArticles(allArticlesQuery, numberOfArticles);
            }

            return results;
        }

        public static List<Article> GetArticles(Member member, Child child, DateTime date)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex(Constants.ARTICLE_SEARCH_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                // Pre-process
                // Filter performs no relevancy scoring
                var allArticlesQuery = ctx.GetQueryable<Article>()
                                    .Filter(GetBasePredicate(member));

                // Inclusion/Exclusion processing based on member and child
                var matchingArticlesQuery = allArticlesQuery
                                    .Where(GetMemberInterestsPredicate(member))
                                    .Where(GetCombinedChildPredicate(child));

                int totalMatches = matchingArticlesQuery.Take(1).GetResults().TotalSearchResults;

                List<Article> toProcess = new List<Article>();
                
                // 0 - Grab timely articles
                var timelyQuery = matchingArticlesQuery
                                    .Where(GetTimelyPredicate(date));
                int timelyMatches = timelyQuery.Take(1).GetResults().TotalSearchResults;
                List<Article> timelyArticles = new List<Article>();

                if (timelyMatches > 0)
                {
                    int resultsToTake = Math.Min(timelyMatches, Constants.PERSONALIZATION_ARTICLES_PER_USER);
                    timelyArticles = timelyQuery.Take(resultsToTake).ToList();
                    toProcess.AddRange(timelyArticles);
                }

                // The buckets diagrammed by Digital Pulp all contain inclusive search terms
                // Additional filtering is broken out to match diagram, but effectively does no
                // extra filtering save for timely, must read, and backfill

                // 1 - Child Grade
                var firstQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess));

                AddFromBucket(firstQuery, ref toProcess);

                // 2 - Child Issues / Diagnosis
                var secondQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess));

                AddFromBucket(secondQuery, ref toProcess);

                // 3 - Parent interest
                var thirdQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess));

                AddFromBucket(thirdQuery, ref toProcess);

                // 4 - Must read
                var fourthQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess))
                                    .Where(GetMustReadPredicate());

                AddFromBucket(fourthQuery, ref toProcess);

                // 5 - IEP/504
                var fifthQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess));

                AddFromBucket(fifthQuery, ref toProcess);

                // Backfill
                int spotsToFill = Constants.PERSONALIZATION_ARTICLES_PER_USER - toProcess.Count();
                if (spotsToFill > 0)
                {
                    var backfillQuery = allArticlesQuery
                                            .Filter(GetExcludeArticlesPredicate(toProcess))
                                            .Where(GetMemberBackfillInterestsPredicate(member))
                                            .Where(GetCombinedChildPredicate(child));

                    toProcess.AddRange(GetRandomBucketArticles(backfillQuery, spotsToFill));
                }

                // Post Process
                List<Article> finalList = new List<Article>();

                // Place timely at top
                if (timelyArticles.Any())
                {
                    finalList.AddRange(timelyArticles);
                    toProcess = toProcess.Except(timelyArticles).ToList();
                }
                
                // Shift must read next
                List<Article> mustRead = toProcess.AsQueryable().Where(GetMustReadPredicate()).ToList();
                if (mustRead.Any())
                {
                    finalList.AddRange(mustRead);
                    toProcess = toProcess.Except(mustRead).ToList();
                }

                finalList.AddRange(toProcess);

                results = finalList;

                var resp = System.Web.HttpContext.Current.Response;
                resp.Write(String.Format("Member: {0} {1} | Child: {2}<br>", member.FirstName, member.LastName, child.Nickname));
                resp.Write(String.Format("Total articles to search: {0}<br>", allArticlesQuery.Take(1).GetResults().TotalSearchResults));
                resp.Write(String.Format("Matches: {0}<br><br>", totalMatches));
                //resp.Write(String.Format("Timely: {0}<br>", timelyArticles.Count()));
                //resp.Write(String.Format("Must: {0}<br><br>", mustReadArticles.Count()));

                foreach (Article a in finalList)
                {
                    resp.Write(String.Format("{0} - {1} ({2})<br>", a.ItemId.ToString(), a.Name, a.Language));
                }

                resp.Write("<br><br>");
            }  

            return results;
        }
    }
}
