using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Resources.Media;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
    public partial class DefaultArticlePageItem 
    {
        /// <summary>
        /// Returns matching children for grades and issues
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetMatchingChildrenIds(Domain.Membership.Member member)
        {
            var matches = new List<Guid>();
            
            // Require parent interests and child
            if (member != null && member.Children.Count > 0) 
            {
                foreach(var child in member.Children) 
                {
                    // Child must have grade
                    if (child.Grades.Count == 0)
                    {
                        continue;
                    }

                    bool gradeMatch = false;
                    bool issueMatch = false;

                    var childGrade = child.Grades.FirstOrDefault();
                    var articleGrades = ChildGrades.ListItems.Select(i => i.ID.Guid).ToList();

                    // Unmapped or All grades is considered a match in addition to child's grade
                    if (!articleGrades.Any()
                        || articleGrades.Contains(Guid.Parse(Constants.ArticleTags.AllChildGrades))
                        || articleGrades.Contains(childGrade.Key))
                    {
                        gradeMatch = true;
                    }

                    if (child.Issues.Count == 0)
                    {
                        issueMatch = true;
                    }
                    else
                    {
                        var childIssues = child.Issues.Select(i => i.Key).ToList();
                        var articleIssues = ChildIssues.ListItems.Select(i => i.ID.Guid).ToList();

                        if (articleIssues.Contains(Guid.Parse(Constants.ArticleTags.AllChildIssues)))
                        {
                            issueMatch = true;
                        }
                        else
                        {
                            issueMatch = childIssues.Intersect(articleIssues).ToList().Count() > 0;
                        }
                    }

                    if (gradeMatch && issueMatch)
                    {
                        matches.Add(child.ChildId);
                    }
                }
            }

            return matches;
        }

        public bool HasMatchingParentInterest(Domain.Membership.Member member)
        {
            if (member != null && member.Interests.Count > 0)
            {
                List<Guid> mappedInterests = this.ApplicableInterests.ListItems.Select(i => i.ID.Guid).ToList();
                List<Guid> parentInterests = member.Interests.Select(i => i.Key).ToList();

                return parentInterests.Intersect(mappedInterests).ToList().Count() > 0;
            }

            return false;
        }

        /// <summary>
        /// Get Content Thumbnail URL, with fallback to Featured Image
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public string GetArticleThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = ContentThumbnail.MediaItem ?? FeaturedImage.MediaItem;

            return item.GetMediaUrlWithFallback(maxWidth, maxHeight);
        }

        /// <summary>
        /// Get Featured Image URL, with fallback to Content Thumbnail
        /// </summary>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public string GetArticleFeaturedThumbnailUrl(int maxWidth, int maxHeight)
        {
            MediaItem item = FeaturedImage.MediaItem ?? ContentThumbnail.MediaItem;

            return item.GetMediaUrlWithFallback(maxWidth, maxHeight);
        }

        public string GetArticleType()
        {
            return DefaultArticlePageItem.GetArticleType(InnerItem.TemplateID);
        }

        public List<DefaultArticlePageItem> GetMoreLikeThisArticles()
        {
            var results = new List<DefaultArticlePageItem>();

            if (CuratedMoreLikeThisArticles.ListItems.Any())
            {
                results = CuratedMoreLikeThisArticles.ListItems.FilterByContextLanguageVersion()
                                .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                                .Where(i => i.ID != InnerItem.ID)
                                .Select(i => new DefaultArticlePageItem(i))
                                .Take(Constants.MORE_LIKE_THIS_ENTRIES)
                                .ToList();
            }
            else
            {
                // Look up to subtopic
                var parent = InnerItem.Parent;
                if (parent != null 
                    && parent.InheritsTemplate(SubtopicLandingPageItem.TemplateId))
                {
                    results = SearchHelper.GetRandomMoreLikeThisArticles(parent.ID, InnerItem.ID)
                                    .Where(i => i.GetItem() != null)
                                    .Select(i => new DefaultArticlePageItem(i.GetItem()))
                                    .Take(Constants.MORE_LIKE_THIS_ENTRIES)
                                    .ToList();
                }
            }

            return results;
        }
    }
}