using Microsoft.Practices.ServiceLocation;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Impl.FieldSerializers;
using SolrNet.Impl.QuerySerializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;

namespace UnderstoodDotOrg.Domain.Search
{
    public class SearchHelper
    {
        #region Predicates

        private static Expression<Func<Article, bool>> GetBasePredicate(Member member = null)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.True<Article>();

            // Workaround Sitecore bug - require a single true condition
            pred = pred.And(GetAlwaysTruePredicate());

            // Exclude QA
            pred = pred.And(a => !a.Paths.Contains(ID.Parse(Constants.QATestDataContainer)));
            
            // Exclude articles marked for exclusion
            pred = pred.And(a => !a.OverrideTypes.Contains(ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization)));


            // start at content root
            pred = pred.And(a => a.Path.Contains(Constants.Search.ContentSearchPath));

            // Include only articles
            pred = pred.And(GetInheritsArticlePredicate());

            // Include non cloned items
            pred = pred.And(a => a.SourceItem == ID.Parse(Guid.Empty));

            // TODO: Exclude items interacted by member - MemberActivity table
            if (member != null)
            {

            }

            return pred;                               
        }

        /// <summary>
        /// Filter query results to return only the provided template ID
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        private static Expression<Func<RecommendedResultItem, bool>> GetBasePredicate(string templateId, Member member = null)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.True<RecommendedResultItem>();

            // TODO: retrieve member language
            pred = pred.And(a => a.Language == "en");

            // Exclude templates
            pred = pred.And(a => a.Path.Contains(Constants.Search.ContentSearchPath)
                            && !a.Paths.Contains(ID.Parse(Constants.QATestDataContainer)));

            // Include only content of type templateId
            pred = pred.And(a => a.Templates.Contains(ID.Parse(templateId)));

            // Include non cloned items
            pred = pred.And(a => a.SourceItem == ID.Parse(Guid.Empty));

            return pred;
        }

        private static Expression<Func<Article, bool>> GetInheritsArticlePredicate()
        {
            return (a => a.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId)));
        }

        private static Expression<Func<Article, bool>> GetTimelyPredicate(DateTime date, bool skipPathCheck = false)
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
            if (skipPathCheck)
            {
                // Paths are null after result set is filled
                pred = pred
                    .Or(a => a.TimelyStart != DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
                    && a.TimelyStart <= comparisonDate && a.TimelyEnd >= comparisonDate);
            }
            else
            {
                // Sitecore bug requires true statement first if you have a sequence of AND negation checks
                pred = pred
                    .Or(a => a.Paths.Contains(Sitecore.ItemIDs.RootID) &&
                        a.TimelyStart != DateTime.MinValue && a.TimelyEnd != DateTime.MinValue
                    && a.TimelyStart <= comparisonDate && a.TimelyEnd >= comparisonDate);
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetMemberInterestsPredicate(Member member, bool explicitMatchSearch = false)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            if (!explicitMatchSearch)
            {
                // Include un-mapped interests
                pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(Guid.Empty)));
            }

            // Include member interests
            foreach (var interest in member.Interests)
            {
                // prevent outer variable trap
                var i = interest;
                pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<RecommendedResultItem, bool>> GetMemberInterestsPredicate(Member member, string templateId, bool explicitMatchSearch = false)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.False<RecommendedResultItem>();

            if (!explicitMatchSearch)
            {
                // Include un-mapped interests
                pred = pred.Or(a => a.ParentInterests.Contains(ID.Parse(Guid.Empty)));
            }

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

        private static Expression<Func<RecommendedResultItem, bool>> GetMemberBackfillInterestsPredicate(Member member, string templateId)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.True<RecommendedResultItem>();

            // Workaround Sitecore bug - require a single true condition
            pred = pred.And(GetAlwaysTruePredicate(templateId));

            // Exclude member interests
            foreach (var interest in member.Interests)
            {
                // prevent outer variable trap
                var i = interest;
                pred = pred.And(a => !a.ParentInterests.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildIEP504Predicate(Child child, bool explicitMatchSearch = false)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            if (!explicitMatchSearch)
            {
                // Unmapped
                pred = pred.Or(a => a.ApplicableEvaluations.Contains(ID.Parse(Guid.Empty)));
            }

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

        private static Expression<Func<Article, bool>> GetChildDiagnosisPredicate(Child child, bool explicitMatchSearch = false)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Constants.ArticleTags.AllChildDiagnosis)));
            }

            foreach (var diagnosis in child.Diagnoses)
            {
                // prevent outer variable trap
                var d = diagnosis;
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(d.Key)));
            }

            return pred;
        }

        private static Expression<Func<RecommendedResultItem, bool>> GetChildDiagnosisPredicate(Child child, string templateId, bool explicitMatchSearch = false)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.False<RecommendedResultItem>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(Constants.ArticleTags.AllChildDiagnosis)));
            }

            foreach (var diagnosis in child.Diagnoses)
            {
                // prevent outer variable trap
                var d = diagnosis;
                pred = pred.Or(a => a.ChildDiagnoses.Contains(ID.Parse(d.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildGradesPredicate(Child child, bool explicitMatchSearch = false)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades)));
            }

            foreach (var grades in child.Grades)
            {
                // prevent outer variable trap
                var g = grades;
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(g.Key)));
            }

            return pred;
        }

        private static Expression<Func<RecommendedResultItem, bool>> GetChildGradesPredicate(Child child, string templateId, bool explicitMatchSearch = false)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.False<RecommendedResultItem>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades)));
            }

            foreach (var grades in child.Grades)
            {
                // prevent outer variable trap
                var g = grades;
                pred = pred.Or(a => a.ChildGrades.Contains(ID.Parse(g.Key)));
            }

            return pred;
        }

        private static Expression<Func<Article, bool>> GetChildIssuesPredicate(Child child, bool explicitMatchSearch = false)
        {
            Expression<Func<Article, bool>> pred = PredicateBuilder.False<Article>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Constants.ArticleTags.AllChildIssues)));
            }

            foreach (var issues in child.Issues)
            {
                // prevent outer variable trap
                var i = issues;
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(i.Key)));
            }

            return pred;
        }

        private static Expression<Func<RecommendedResultItem, bool>> GetChildIssuesPredicate(Child child, string templateId, bool explicitMatchSearch = false)
        {
            Expression<Func<RecommendedResultItem, bool>> pred = PredicateBuilder.False<RecommendedResultItem>();

            if (!explicitMatchSearch)
            {
                // Include un tagged
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Guid.Empty)));

                // Include content tagged with All
                pred = pred.Or(a => a.ChildIssues.Contains(ID.Parse(Constants.ArticleTags.AllChildIssues)));
            }

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
            var pred = PredicateBuilder.True<Article>()
                .And(GetChildGradesPredicate(child));

            if (child.Issues.Any())
            {
                pred = pred.And(GetChildIssuesPredicate(child));
            }

            if (child.Diagnoses.Any()) 
            {
                pred = pred.And(GetChildDiagnosisPredicate(child));
            }
            
            return pred.And(GetChildIEP504Predicate(child))
                       .And(GetChildEvaluationPredicate(child));
        }

        private static Expression<Func<Article, bool>> GetMustReadPredicate()
        {
            return (a => a.ImportanceLevels.Contains(ID.Parse(Constants.ArticleTags.MustRead)));
        }

        private static Expression<Func<Article, bool>> GetAlwaysTruePredicate()
        {
            return (a => a.Paths.Contains(Sitecore.ItemIDs.RootID));
        }

        private static Expression<Func<RecommendedResultItem, bool>> GetAlwaysTruePredicate(string templateId)
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

        #endregion

        #region Enums
        public partial class SortOptions
        {
            public enum AssistiveToolsSortOptions
            {
                Relevance,
                [Description("Learning Rating")]
                LearningRating,
                [Description("Quality Rating")]
                QualityRating,
                [Description("Grade Level")]
                GradeLevel,
                [Description("Most Recent")]
                MostRecent
            }
        }
        #endregion Enums

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

        private static List<int> GetRandomRecommendedContentKeys(IQueryable<RecommendedResultItem> query, int totalKeys)
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
                Article random = (i == 0) ? query.Take(1).FirstOrDefault() : query.Skip(i).Take(1).FirstOrDefault();

                if (random != null)
                {
                    articles.Add(random);
                }
            }

            return articles;
        }

        private static List<RecommendedResultItem> GetRandomBucketContent(IQueryable<RecommendedResultItem> query, int totalEntries)
        {
            List<RecommendedResultItem> recommendedResults = new List<RecommendedResultItem>();

            foreach (int i in GetRandomRecommendedContentKeys(query, totalEntries))
            {
                RecommendedResultItem random = (i == 0) ? query.Take(1).FirstOrDefault() : query.Skip(i).Take(1).FirstOrDefault();

                if (random != null)
                {
                    recommendedResults.Add(random);
                }
            }

            return recommendedResults;
        }

        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> source, Random rng)
        {
            if (!source.Any())
            {
                yield break;
            }

            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
                // we don't actually perform the swap, we can forget about the
                // swapped element because we already returned it.
            }

            // there is one item remaining that was not returned - we return it now
            yield return elements[0];
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

        private static void AddFromRecommendedContentBucket(IQueryable<RecommendedResultItem> query, ref List<RecommendedResultItem> result)
        {
            int currentEntries = result.Count();
            if (currentEntries < Constants.PERSONALIZATION_ARTICLES_PER_USER)
            {
                // Calculate remaining spots
                int spotsToFill = Math.Min(Constants.PERSONALIZATION_ARTICLES_PER_USER - currentEntries, Constants.PERSONALIZATION_ARTICLES_PER_BUCKET);
                result.AddRange(GetRandomBucketContent(query, spotsToFill));
            }
        }


        #region Public methods

        /// <summary>
        /// Retrieve articles for more like this
        /// </summary>
        /// <param name="subtopicId"></param>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static List<Article> GetRandomMoreLikeThisArticles(ID subtopicId, ID articleId)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                var articlesQuery = GetCurrentCultureQueryable<Article>(ctx)
                                    .Filter(i => i.Language == Sitecore.Context.Language.Name)
                                    .Filter(i => i.Paths.Contains(subtopicId)
                                            && i.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId))
                                            && i.ItemId != articleId);

                results = GetRandomBucketArticles(articlesQuery, Constants.MORE_LIKE_THIS_ENTRIES);
            }

            return results;
        }

        public static List<Article> GetMostRecentArticlesWithin(ID container, int page, int numEntries, out int totalEntries)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<Article>(ctx)
                                .Filter(i => i.Language == Sitecore.Context.Language.Name)
                                .Filter(i => i.Paths.Contains(container))
                                .Filter(i => i.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId)))
                                .OrderByDescending(i => i.CreatedDate)
                                .AsQueryable();

                totalEntries = query.Take(1).GetResults().TotalSearchResults;

                if (page > 1)
                {
                    query = query.Skip((page - 1) * numEntries);
                }

                results = query.Take(numEntries).ToList();
            }

            return results;
        }

        public static List<Article> GetMostRecentArticlesWithin(ID container, int numEntries)
        {
            int totalEntries;
            return GetMostRecentArticlesWithin(container, 1, numEntries, out totalEntries);
        }

        public static List<Article> GetRandomMustReadArticles(int numberOfArticles)
        {
            List<Article> results = new List<Article>();

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                var allArticlesQuery = GetCurrentCultureQueryable<Article>(ctx)
                                    .Filter(GetBasePredicate())
                                    .Where(GetMustReadPredicate());

                 results = GetRandomBucketArticles(allArticlesQuery, numberOfArticles);
            }

            return results;
        }

        public static List<string> GetSpellCheckSuggestions(string term)
        {
            List<string> suggestions = new List<string>();

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Article>>();
            var schema = solr.GetSchema();

            // TODO: restrict to current language
            var templateId = ID.Parse(DefaultArticlePageItem.TemplateId).ToShortID().ToString().ToLower();
            var q = new SolrQueryByField("_content", term)
                && new SolrQueryByField("alltemplates_sm", templateId) { Quoted = false }
                && new SolrQueryByField("_language", Sitecore.Context.Language.Name) { Quoted = false };
            
            var serializer = new DefaultQuerySerializer(new DefaultFieldSerializer());
            //var t = serializer.Serialize(q);

            var results = solr.Query(q, new QueryOptions
            {
                SpellCheck = new SpellCheckingParameters { Query = term, Collate = true }
            });

            foreach (var sc in results.SpellChecking)
            {
                suggestions.Add(sc.Suggestions.First());
            }

            return suggestions;
        }

        public static List<Article> PerformArticleSearch(string terms, string template, int page, out int totalResults)
        {
            float pageTitleBoost = 3;

            // Sitecore implementation does not handle escaping reserved characters
            terms = NormalizeSearchTerm(terms);

            // Look for quotes to handle phrase search
            bool phraseSearch = terms.Contains("\\\"");

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);

            using (var ctx = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<Article>(ctx)
                                .Filter(i => i.Language == Sitecore.Context.Language.Name)
                                .Filter(a => a.Path.Contains(Constants.Search.ContentSearchPath)
                                    && a.SourceItem == ID.Parse(Guid.Empty)
                                    && !a.Paths.Contains(ID.Parse(Constants.QATestDataContainer)));

                bool hasTemplateMappings = false;

                // Filter types
                if (!String.IsNullOrEmpty(template))
                {
                    Item container = Sitecore.Context.Database.GetItem(Constants.SearchFilterTypesContainer);
                    var child = from c in container.Children
                                where c.ID.ToString() == template
                                select new SearchFilterTypeItem(c);

                    SearchFilterTypeItem typeItem = child.FirstOrDefault();
                    if (typeItem != null)
                    {
                        hasTemplateMappings = typeItem.TemplateTypes.ListItems.Count() > 0;

                        // Restrict articles types to dropdown choice
                        if (hasTemplateMappings)
                        {
                            var pred = PredicateBuilder.False<Article>();

                            foreach (var item in typeItem.TemplateTypes.ListItems)
                            {
                                var i = item;
                                pred = pred.Or(a => a.TemplateId == i.ID);
                            }

                            query = query.Filter(pred);
                        }
                    }
                }
                
                // Fallback to all articles and tools
                if (!hasTemplateMappings) 
                {
                    query = query.Filter(a => a.Templates.Contains(ID.Parse(DefaultArticlePageItem.TemplateId))
                                         || a.TemplateId == ID.Parse(BehaviorToolsLandingPageItem.TemplateId)
                                         || a.TemplateId == ID.Parse(AssistiveToolsLandingPageItem.TemplateId)
                                         || a.TemplateId == ID.Parse(DecisionToolLandingPageItem.TemplateId)
                                         || a.TemplateId == ID.Parse(TyceOverviewPageItem.TemplateId));
                }

                // Search for terms
                if (!phraseSearch)
                {
                    query = query.Where(a => a.PageTitle.Contains(terms).Boost(pageTitleBoost)
                                        || a.Content.Contains(terms));
                }
                else
                {
                    // Strip all quotes and wrap terms for phrase search
                    terms = String.Format("\"{0}\"", terms.Replace("\\\"", ""));

                    query = query.Where(a => a.PageTitle.Equals(terms).Boost(pageTitleBoost)
                                        || a.Content.Equals(terms));
                }


                totalResults = query.Take(1).GetResults().TotalSearchResults;

                int offset = (page - 1) * Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE;

                return query.Skip(offset).Take(Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE).ToList();
            }
        }

        private static IQueryable<BehaviorAdvice> GetBehaviorSearchQuery(IProviderSearchContext context, string challenge, string grade)
        {
            return GetCurrentCultureQueryable<BehaviorAdvice>(context)
                        .Filter(i => i.Language == Sitecore.Context.Language.Name)
                        .Filter(i => i.Path.Contains(Constants.Search.ContentSearchPath)
                            && !i.Paths.Contains(ID.Parse(Constants.QATestDataContainer)))
                        .Filter(i => i.TemplateId == ID.Parse(BehaviorToolsAdvicePageItem.TemplateId)
                                || i.TemplateId == ID.Parse(BehaviorToolsAdviceVideoPageItem.TemplateId))
                        .Where(i => i.ChildChallenges.Contains(ID.Parse(Guid.Empty))
                                || i.ChildChallenges.Contains(ID.Parse(challenge)))
                        .Where(i => i.ChildGrades.Contains(ID.Parse(Guid.Empty))
                                || i.ChildGrades.Contains(ID.Parse(grade))
                                || i.ChildGrades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades)));
        }

        /// <summary>
        /// Used to store search results in session
        /// </summary>
        /// <param name="challenge"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static List<BehaviorAdvice> GetAllBehaviorArticles(string challenge, string grade)
        {
            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);

            using (var ctx = index.CreateSearchContext())
            {
                var query = GetBehaviorSearchQuery(ctx, challenge, grade);

                int totalResults = query.Take(1).GetResults().TotalSearchResults;

                return query.Take(totalResults).ToList();
            }
        }

        public static List<BehaviorAdvice> PerformBehaviorArticleSearch(string challenge, string grade, int page, out int totalResults)
        {
            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);

            using (var ctx = index.CreateSearchContext())
            {
                var query = GetBehaviorSearchQuery(ctx, challenge, grade);

                totalResults = query.Take(1).GetResults().TotalSearchResults;

                int offset = (page - 1) * Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE;

                return query.Skip(offset).Take(Constants.BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE).ToList();
            }   
        }

        public static Article GetArticle(ID itemId)
        {
            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);
            using (var ctx = index.CreateSearchContext())
            {
                return GetCurrentCultureQueryable<Article>(ctx)
                                .Where(a => a.ItemId == ID.Parse(itemId)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Retrieves articles based on personalization flow
        /// </summary>
        /// <param name="member"></param>
        /// <param name="child"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Article> GetArticles(Member member, Child child, DateTime date)
        {
            List<Article> results = new List<Article>();

            // NOTE: this may run without Sitecore context, so we must specify web index
            var index = ContentSearchManager.GetIndex(Constants.Search.ArticleSearchIndex);

            using (var ctx = index.CreateSearchContext())
            {
                // Pre-process
                // Filter performs no relevancy scoring
                var allArticlesQuery = GetCurrentCultureQueryable<Article>(ctx)
                                    .Filter(GetBasePredicate(member));

                // Start Inclusion/Exclusion processing based on member and child
                var matchingArticlesQuery = allArticlesQuery;

                // Check if child has positive diagnosis for either IEP/504
                bool childHasPositiveEvaluation = child.IEPStatus == Guid.Parse(Constants.ChildEvaluation.StatusIEPYes)
                            || child.Section504Status == Guid.Parse(Constants.ChildEvaluation.Status504Yes);

                // PFF-1710: Skip parental interests if child is IEP/504 evaluated
                if (!childHasPositiveEvaluation)
                {
                    // Parental interests match
                    if (member.Interests.Any())
                    {
                        matchingArticlesQuery = matchingArticlesQuery.Filter(GetMemberInterestsPredicate(member));
                    }
                }

                matchingArticlesQuery = matchingArticlesQuery.Filter(GetCombinedChildPredicate(child));

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

                // Initial query contains all/none mapping, 
                // buckets should exclude the all/none mappings

                // 1 - Child Grade
                if (child.Grades.Any())
                {
                    var firstQuery = matchingArticlesQuery
                                        .Filter(GetChildGradesPredicate(child, true))
                                        .Filter(GetExcludeArticlesPredicate(toProcess));
                    AddFromBucket(firstQuery, ref toProcess);
                }

                // 2 - Child Issues / Diagnosis
                bool hasIssues = child.Issues.Any();
                bool hasDiagnoses = child.Diagnoses.Any();

                if (hasIssues || hasDiagnoses)
                {
                    var secondQuery = matchingArticlesQuery.Filter(GetExcludeArticlesPredicate(toProcess));
                    if (hasIssues) 
                    {
                        secondQuery = secondQuery.Filter(GetChildIssuesPredicate(child, true));
                    }
                    if (hasDiagnoses)
                    {
                        secondQuery = secondQuery.Filter(GetChildDiagnosisPredicate(child, true));
                    }

                    AddFromBucket(secondQuery, ref toProcess);
                }

                // 3 - Parent interest
                if (member.Interests.Any())
                {
                    var thirdQuery = matchingArticlesQuery
                                        .Filter(GetMemberInterestsPredicate(member, true))
                                        .Filter(GetExcludeArticlesPredicate(toProcess));

                    AddFromBucket(thirdQuery, ref toProcess);
                }

                // 4 - Must read
                var fourthQuery = matchingArticlesQuery
                                    .Filter(GetExcludeArticlesPredicate(toProcess))
                                    .Filter(GetMustReadPredicate());

                AddFromBucket(fourthQuery, ref toProcess);

                // 5 - IEP/504
                var fifthQuery = matchingArticlesQuery
                                    .Filter(GetChildIEP504Predicate(child, true))
                                    .Filter(GetExcludeArticlesPredicate(toProcess));

                AddFromBucket(fifthQuery, ref toProcess);

                // Backfill
                int spotsToFill = Constants.PERSONALIZATION_ARTICLES_PER_USER - toProcess.Count();
                if (spotsToFill > 0)
                {
                    var backfillQuery = allArticlesQuery
                                            .Filter(GetExcludeArticlesPredicate(toProcess))
                                            .Filter(GetMemberBackfillInterestsPredicate(member))
                                            .Filter(GetCombinedChildPredicate(child));

                    toProcess.AddRange(GetRandomBucketArticles(backfillQuery, spotsToFill));
                    Sitecore.Diagnostics.Log.Info("Personalized backfill for non matching parent interests", backfillQuery);
                }

                // Post Process
                List<Article> finalList = new List<Article>();

                // Place timely at top
                if (timelyArticles.Any())
                {
                    finalList.AddRange(timelyArticles);
                    toProcess = toProcess.Except(timelyArticles).ToList();
                }

                // Shift other articles that may have timely content during bucket filling
                List<Article> otherTimely = toProcess.AsQueryable().Where(GetTimelyPredicate(date, true)).ToList();
                if (otherTimely.Any())
                {
                    finalList.AddRange(otherTimely);
                    toProcess = toProcess.Except(otherTimely).ToList();
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

                //var resp = System.Web.HttpContext.Current.Response;
                //resp.Write(String.Format("Member: {0} {1} | Child: {2}<br>", member.FirstName, member.LastName, child.Nickname));
                //resp.Write(String.Format("Total articles to search: {0}<br>", allArticlesQuery.Take(1).GetResults().TotalSearchResults));
                //resp.Write(String.Format("Matches: {0}<br><br>", totalMatches));
                ////resp.Write(String.Format("Timely: {0}<br>", timelyArticles.Count()));
                ////resp.Write(String.Format("Must: {0}<br><br>", mustReadArticles.Count()));

                //resp.Write(String.Format("Grade: {0}<br><br>", child.Grades.FirstOrDefault().Value));

                //foreach (Article a in finalList)
                //{
                //    resp.Write(String.Format("{0} - {1} ({2})<br>", a.ItemId.ToString(), a.Name, a.Language));

                //    if (a.ChildGrades != null)
                //    {
                //        resp.Write("Indexed grades: ");
                //        resp.Write(string.Join(" ", a.ChildGrades.Select(i => Sitecore.Context.Database.GetItem(i))
                //                                        .Where(i => i != null)
                //                                        .Select(i => ((GradeLevelItem)i).Name.Raw)
                //                                        .ToArray()));
                //    }

                //    DefaultArticlePageItem article = a.GetItem();
                //    if (article != null)
                //    {
                //        resp.Write("<br>Article grades: ");
                //        resp.Write(string.Join(" ", article.ChildGrades.ListItems.Select(i => new GradeLevelItem(i))
                //                        .Select(i => i.Name.Raw).ToList()
                //                                        .ToArray()));     
                //    }

                //    resp.Write("<br><br>");
                //}

                //resp.Write("<br><br>");
            }  

            return results;
        }


        /// <summary>
        /// Retrieves recommended content based on personalization flow - child grade and issues for each child of member, then parent interests
        /// </summary>
        /// <param name="member"></param>
        /// <param name="child"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<RecommendedResultItem> GetRecommendedContent(Member member, string templateId)
        {
            List<RecommendedResultItem> results = new List<RecommendedResultItem>();

            var index = ContentSearchManager.GetIndex(Constants.CURRENT_INDEX_NAME);

            using (var ctx = index.CreateSearchContext())
            {
                // Pre-process
                // Filter performs no relevancy scoring
                var allContentQuery = GetCurrentCultureQueryable<RecommendedResultItem>(ctx)
                                    .Filter(GetBasePredicate(templateId, member));

                // Start Inclusion/Exclusion processing based on member and child(ren)
                var matchingContentQuery = allContentQuery;

                int totalMatches = matchingContentQuery.Take(1).GetResults().TotalSearchResults;

                List<RecommendedResultItem> toProcess = new List<RecommendedResultItem>();

                //get results for all children of member
                if (member.Children != null)
                {
                    foreach (Child child in member.Children)
                    {
                        // Initial query contains all/none mapping, 
                        // buckets should exclude the all/none mappings

                        // 1 - Child Grade
                        if (child.Grades.Any())
                        {
                            var firstQuery = matchingContentQuery
                                                .Filter(GetChildGradesPredicate(child, templateId, true));
                            AddFromRecommendedContentBucket(firstQuery, ref toProcess);
                        }

                        // 2 - Child Issues / Diagnosis
                        bool hasIssues = child.Issues.Any();
                        bool hasDiagnoses = child.Diagnoses.Any();

                        if (hasIssues || hasDiagnoses)
                        {
                            var secondQuery = matchingContentQuery;
                            if (hasIssues)
                            {
                                secondQuery = secondQuery.Filter(GetChildIssuesPredicate(child, templateId, true));
                            }
                            if (hasDiagnoses)
                            {
                                secondQuery = secondQuery.Filter(GetChildDiagnosisPredicate(child, templateId, true));
                            }

                            AddFromRecommendedContentBucket(secondQuery, ref toProcess);
                        }
                    }
                }
                

                // 3 - Parent interest
                if (member.Interests.Any())
                {
                    var thirdQuery = matchingContentQuery
                                        .Filter(GetMemberInterestsPredicate(member, templateId, true));

                    AddFromRecommendedContentBucket(thirdQuery, ref toProcess);
                }

                
                // Backfill
                int spotsToFill = Constants.PERSONALIZATION_ARTICLES_PER_USER - toProcess.Count();
                if (spotsToFill > 0)
                {
                    var backfillQuery = allContentQuery.Filter(GetMemberBackfillInterestsPredicate(member, templateId));

                    toProcess.AddRange(GetRandomBucketContent(backfillQuery, spotsToFill));
                    Sitecore.Diagnostics.Log.Info("Personalized backfill for non matching parent interests", backfillQuery);
                }

                // Post Process
                List<RecommendedResultItem> finalList = new List<RecommendedResultItem>();

                finalList.AddRange(toProcess);

                results = finalList;
            }

            return results;
        }

        public static List<DefaultArticlePageItem> GetLastSlide(ID dataSourceId, Item subtopic = null, Item topic = null, string theTemplateID = "", int maxItemsToGet = 2)
        {
            var finalResults = new List<SearchResultItem>();
            var result = Enumerable.Empty<SearchResultItem>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            using (var context = index.CreateSearchContext())
            {
                var baseQuery = GetCurrentCultureQueryable<SearchResultItem>(context)
                                   .Where(i => i.Language == Sitecore.Context.Language.Name)
                                   .Where(i => i.TemplateId == ID.Parse(theTemplateID)) // get only Text Only Tips Article Pages
                                   .Where(i => i.ItemId != dataSourceId); // don't get the context item

                int counter = 0;

                // subtopic filter
                if (subtopic != null)
                {
                    var subTopicQuery = baseQuery.Where(i => i.Paths.Contains(subtopic.ID));
                    int totalResults = subTopicQuery.Take(1).GetResults().TotalSearchResults;
                    var res = subTopicQuery.Take(totalResults).ToList();
                    finalResults.AddRange(res);
                    counter += res.Count;
                }

                // topic filter
                if (maxItemsToGet > counter && topic != null)
                {
                    var foundIds = finalResults.Select(r => r.ItemId);
                    var topicQuery = baseQuery.Where(i => i.Paths.Contains(topic.ID));
                    
                    int totalResults = topicQuery.Take(1).GetResults().TotalSearchResults;
                    var res = topicQuery.Take(totalResults).ToList();
                    int take = maxItemsToGet - counter;
                    res = res.Where(r => !foundIds.Contains(r.ItemId)).Take(take).ToList();
                    finalResults.AddRange(res);
                    counter += res.Count;
                }

                // global site filter
                if (maxItemsToGet > counter)
                {
                    Expression<Func<SearchResultItem, bool>> notMatchingIdPredicate = PredicateBuilder.True<SearchResultItem>();

                    // Workaround Sitecore bug - require a single true condition
                    notMatchingIdPredicate = notMatchingIdPredicate.And((a => a.Paths.Contains(Sitecore.ItemIDs.RootID)));

                    var foundIds = finalResults.Select(r => r.ItemId);

                    foreach (var id in foundIds)
                    {
                        notMatchingIdPredicate = notMatchingIdPredicate.And(r => id != r.ItemId);
                    }
                    
                    int totalResults = baseQuery.Take(1).GetResults().TotalSearchResults;
                    int randomSeed = new Random().Next(totalResults);
                    int take = maxItemsToGet - counter;
                    var res = baseQuery.Where(notMatchingIdPredicate).Skip(randomSeed).Take(take);
                    finalResults.AddRange(res);
                }

                return finalResults.Select(r => r.GetItem()).Select(i => (DefaultArticlePageItem)i).ToList();
            }

        }

        private static IEnumerable<BaseEventDetailPageItem> GetEventsByMonthAndYear(int month, int year, Expression<Func<EventPage, bool>> optionalPredicate = null)
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1);

            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<EventPage>(context)
                                    .Filter(GetBaseEventPredicate())
                                    .Filter(i => (i.TemplateId == ID.Parse(ChatEventPageItem.TemplateId)
                                                  || i.TemplateId == ID.Parse(WebinarEventPageItem.TemplateId))
                                            && i.EventStartDate >= startDate
                                            && i.EventStartDate < endDate);

                if (optionalPredicate != null)
                {
                    query = query.Filter(optionalPredicate);
                }

                query = query.OrderBy(i => i.EventStartDate);

                int totalResults = query.Take(1).GetResults().TotalSearchResults;

                // Exclude out of synch indexed items
                return query.Take(totalResults).ToList()
                            .Select(i => (BaseEventDetailPageItem)i.GetItem())
                            .Where(i => i != null);
            }
        }

        public static IEnumerable<BaseEventDetailPageItem> GetUpcomingEvents(int totalResults)
        {
            // TODO: refactor to use GetUpcomingEvents
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            using (var context = index.CreateSearchContext())
            {
                var events = GetCurrentCultureQueryable<EventPage>(context)
                                    .Filter(GetBaseEventPredicate())
                                    .Filter(GetUpcomingEventPredicate())
                                    .OrderBy(i => i.EventStartDate)
                                    .Take(totalResults)
                                    .ToList();

                // Handle out of synch indexed items
                return events.Where(i => i.GetItem() != null)
                                    .Select(i => new BaseEventDetailPageItem(i.GetItem()));
            }
        }

        public static IEnumerable<BaseEventDetailPageItem> GetExpertsUpcomingEvents(ID expertId, int totalResults)
        {
            // TODO: refactor to use GetUpcomingEvents
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            using (var context = index.CreateSearchContext())
            {
                var events = GetCurrentCultureQueryable<EventPage>(context)
                                    .Filter(GetBaseEventPredicate())
                                    .Filter(GetUpcomingEventPredicate())
                                    .Filter(i => i.Expert == expertId)
                                    .OrderBy(i => i.EventStartDate)
                                    .Take(totalResults)
                                    .ToList();

                // Handle out of synch indexed items
                return events.Where(i => i.GetItem() != null)
                                    .Select(i => new BaseEventDetailPageItem(i.GetItem()));
            }
        }

        public static List<BaseEventDetailPageItem> GetExpertsArchivedEvents(ID expertId, int numEntries)
        {
            var pred = PredicateBuilder.True<EventPage>();
            pred = pred.And(i => i.Expert == expertId);

            int totalResults;
            return GetArchivedEvents(1, numEntries, out totalResults, pred);
        }


        /// <summary>
        /// Get the most upcoming event on the entire site
        /// </summary>
        /// <returns></returns>
        public static BaseEventDetailPageItem GetNextUpcomingEvent()
        {
            return GetUpcomingEvents(1).FirstOrDefault();
        }

        public static List<SearchResultItem> GetParentInterests()
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            ID container = ID.Parse(Constants.ParentInterestsContainer);

            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<SearchResultItem>(context)
                                .Filter(i => i.Language == Sitecore.Context.Language.Name)
                                .Filter(i => i.Paths.Contains(container)
                                    && i.ItemId != container
                                    && i.TemplateId == ID.Parse(ParentInterestItem.TemplateId));

                int total = query.Take(1).GetResults().TotalSearchResults;

                return query.Take(total).ToList();
            }
        }

        public static IEnumerable<BaseEventDetailPageItem> GetEventsByMonthAndYear(int month, int year, string grade, string issue, string topic)
        {
            return GetEventsByMonthAndYear(month, year, GetEventFilterPredicate(grade, issue, topic));
        }
        
        public static List<BaseEventDetailPageItem> GetUpcomingWebinars(string grade, string issue, string topic)
        {
            return GetUpcomingEvents(WebinarEventPageItem.TemplateId, GetEventFilterPredicate(grade, issue, topic));
        }

        public static List<BaseEventDetailPageItem> GetUpcomingChats(string grade, string issue, string topic)
        {
            return GetUpcomingEvents(ChatEventPageItem.TemplateId, GetEventFilterPredicate(grade, issue, topic));
        }

        public static BaseEventDetailPageItem GetNextUpcomingWebinar()
        {
            return GetUpcomingEvents(WebinarEventPageItem.TemplateId).FirstOrDefault();
        }

        public static BaseEventDetailPageItem GetNextUpcomingChat()
        {
            return GetUpcomingEvents(ChatEventPageItem.TemplateId).FirstOrDefault();
        }

        public static List<BaseEventDetailPageItem> GetArchivedEvents(int page, int pageSize, out int totalResults, string grade, string issue, string topic)
        {
            return GetArchivedEvents(page, pageSize, out totalResults, GetEventFilterPredicate(grade, issue, topic));
        }

        public static List<BaseEventDetailPageItem> GetArchivedEvents(int page, int pageSize, out int totalResults, Expression<Func<EventPage, bool>> optionalPredicate = null)
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<EventPage>(context)
                                .Filter(GetBaseEventPredicate())
                                .Filter(i => i.TemplateId == ID.Parse(ChatEventPageItem.TemplateId) 
                                        || i.TemplateId == ID.Parse(WebinarEventPageItem.TemplateId))
                                .Filter(i => i.EventEndDateUtc < DateTime.UtcNow
                                        && i.EventEndDateUtc != DateTime.MinValue)
                                .OrderByDescending(i => i.EventStartDate)
                                .AsQueryable();

                if (optionalPredicate != null)
                {
                    query = query.Filter(optionalPredicate);
                }

                totalResults = query.Take(1).GetResults().TotalSearchResults;

                if (page > 1)
                {
                    query = query.Skip((page - 1) * pageSize);
                }

                var results = query.Take(pageSize).ToList();

                return results.Where(i => i.GetItem() != null)
                              .Select(i => new BaseEventDetailPageItem(i.GetItem()))
                              .ToList();
            }
        }

        public static IEnumerable<ExpertDetailPageItem> GetRandomizedExpertsWithOpenOfficeHours()
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);

            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<Expert>(context)
                                .Filter(i => i.Language == Sitecore.Context.Language.Name
                                        && i.Path.Contains(Constants.Search.ContentSearchPath))
                                .Filter(i => i.TemplateId == ID.Parse(ExpertDetailPageItem.TemplateId)
                                        && i.EventParticipation.Contains(ID.Parse(Constants.Events.OpenOfficeHourChat)));

                var total = query.Take(1).GetResults().TotalSearchResults;

                var results = query.Take(total).ToList();

                Random r = new Random();

                return Shuffle(results.AsEnumerable(), r)
                            .Where(i => i.GetItem() != null)
                            .Select(i => new ExpertDetailPageItem(i.GetItem()));
            }
        }

        public static IEnumerable<AssistiveToolsReviewPageItem> GetAssitiveToolsReviewPages(Guid? issueId, int? minGrade, int? maxGrade, Guid? technologyId, 
            Guid? platformId, string searchTerm, SortOptions.AssistiveToolsSortOptions sortOption)
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            searchTerm = NormalizeSearchTerm(searchTerm);

            bool hasGradeRange = minGrade.HasValue && maxGrade.HasValue;

            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<AssistiveToolReview>(context)
                                .Filter(i => i.Language == Sitecore.Context.Language.Name
                                        && i.Path.Contains(Constants.Search.ContentSearchPath))
                                .Filter(i => i.TemplateId == ID.Parse(AssistiveToolsReviewPageItem.TemplateId));

                if (issueId.HasValue)
                {
                    query = query.Where(i => i.Issues.Contains(ID.Parse(issueId.Value)));
                }
                if (hasGradeRange)
                {
                    query = query.Where(i => i.TargetGrade >= minGrade && i.TargetGrade <= maxGrade);
                }
                if (technologyId.HasValue)
                {
                    query = query.Where(i => i.Technology.Contains(ID.Parse(technologyId.Value)));
                }
                if (platformId.HasValue)
                {
                    query = query.Where(i => i.Platforms.Contains(ID.Parse(platformId)));
                }

                if (issueId.HasValue || hasGradeRange || technologyId.HasValue || platformId.HasValue)
                {
                    searchTerm = null;
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // TODO: search against specific fields of content
                    query = query
                        .Where(i => i.Content.Contains(searchTerm));
                }

                // Sort
                switch (sortOption)
                {
                    case SortOptions.AssistiveToolsSortOptions.GradeLevel:
                        query = query.OrderByDescending(i => i.GradeRating);
                        break;
                    case SortOptions.AssistiveToolsSortOptions.LearningRating:
                        query = query.OrderByDescending(i => i.LearningRating);
                        break;
                    case SortOptions.AssistiveToolsSortOptions.QualityRating:
                        query = query.OrderByDescending(i => i.QualityRating);
                        break;
                    case SortOptions.AssistiveToolsSortOptions.MostRecent:
                        query = query.OrderByDescending(i => i.PublishDate);
                        break;
                }

                var total = query.Take(1).GetResults().TotalSearchResults;

                // Execute solr query
                var results = query.Take(total).ToList();

                return results
                    .Select(res => res.GetItem())
                    .Where(i => i != null)
                    .Select(i => new AssistiveToolsReviewPageItem(i));
            }
        }

        public static IEnumerable<DefaultArticlePageItem> GetArticlesByAuthor(ID authorId, int numArticles)
        {
            IEnumerable<DefaultArticlePageItem> articles = Enumerable.Empty<DefaultArticlePageItem>();

            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            
            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<Article>(context)
                                .Filter(GetInheritsArticlePredicate())
                                .Filter(a => a.Language == Sitecore.Context.Language.Name
                                        && a.Path.Contains(Constants.Search.ContentSearchPath)
                                        && a.Author == authorId)
                                .OrderByDescending(a => a.CreatedDate);

                var results = query.Take(numArticles).ToList();

                articles = results.ToList()
                            .Select(i => (DefaultArticlePageItem)i.GetItem())
                            .Where(i => i != null);
            }

            return articles;
        }

        #endregion
        private static Expression<Func<EventPage, bool>> GetUpcomingEventPredicate()
        {
            return (i => (i.TemplateId == ID.Parse(ChatEventPageItem.TemplateId) 
                            || i.TemplateId == ID.Parse(WebinarEventPageItem.TemplateId))
                    && i.EventStartDateUtc >= DateTime.UtcNow);
        }

        private static Expression<Func<EventPage, bool>> GetEventFilterPredicate(string grade, string issue, string topic)
        {
            Expression<Func<EventPage, bool>> pred = PredicateBuilder.True<EventPage>();
            pred = pred.And(e => e.Paths.Contains(Sitecore.ItemIDs.RootID));

            if (!String.IsNullOrEmpty(grade))
            {
                pred = pred.And(e => e.Grades.Contains(ID.Parse(grade))
                                || e.Grades.Contains(ID.Parse(Constants.ArticleTags.AllChildGrades))
                                || e.Grades.Contains(ID.Parse(Guid.Empty)));
            }

            if (!String.IsNullOrEmpty(issue))
            {
                pred = pred.And(e => e.Issues.Contains(ID.Parse(issue))
                                || e.Issues.Contains(ID.Parse(Constants.ArticleTags.AllChildIssues))
                                || e.Issues.Contains(ID.Parse(Guid.Empty)));
            }

            if (!String.IsNullOrEmpty(topic))
            {
                pred = pred.And(e => e.Topics.Contains(ID.Parse(topic))
                                || e.Topics.Contains(ID.Parse(Guid.Empty)));
            }

            return pred;
        }

        private static List<BaseEventDetailPageItem> GetUpcomingEvents(string templateId, Expression<Func<EventPage, bool>> optionalPredicate = null)
        {
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            
            using (var context = index.CreateSearchContext())
            {
                var query = GetCurrentCultureQueryable<EventPage>(context)
                                .Filter(GetBaseEventPredicate())
                                .Filter(i => i.TemplateId == ID.Parse(templateId))
                                .Filter(i => i.EventStartDateUtc >= DateTime.UtcNow); 

                if (optionalPredicate != null)
                {
                    query = query.Filter(optionalPredicate);
                }

                var ordered = query.OrderBy(i => i.EventStartDate);

                int total = query.Take(1).GetResults().TotalSearchResults;

                var results = ordered.Take(total).ToList();

                return results.Where(i => i.GetItem() != null)
                                .Select(i => new BaseEventDetailPageItem(i.GetItem()))
                                .Where(i => i.Expert.Item != null)
                                .ToList();
            }
        }

        private static Expression<Func<EventPage, bool>> GetBaseEventPredicate()
        {
            return (i => i.Language == Sitecore.Context.Language.Name
                        && i.Path.Contains(Constants.Search.ContentSearchPath));
        }

        private static IQueryable<T> GetCurrentCultureQueryable<T>(IProviderSearchContext context) where T : new()
        {
            return context.GetQueryable<T>(new CultureExecutionContext(CultureInfo.CurrentCulture));
        }

        private static string NormalizeSearchTerm(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                return SolrNet.Impl.QuerySerializers.QueryByFieldSerializer.SpecialCharactersRx.Replace(term, "\\$1");
            }

            return term;
        }

    }
}
