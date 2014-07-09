using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate
{
    public partial class GroupItem
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
                foreach (var child in member.Children)
                {
                    // Child must have grade
                    if (child.Grades.Count == 0)
                    {
                        continue;
                    }

                    bool gradeMatch = false;
                    bool issueMatch = false;

                    var childGrade = child.Grades.FirstOrDefault();
                    var articleGrades = this.Grades.ListItems.Select(i => i.ID.Guid).ToList();

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
                        var articleIssues = this.Issues.ListItems.Select(i => i.ID.Guid).ToList();

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
                List<Guid> mappedInterests = this.Topic.ListItems.Select(i => i.ID.Guid).ToList();
                List<Guid> parentInterests = member.Interests.Select(i => i.Key).ToList();

                return parentInterests.Intersect(mappedInterests).ToList().Count() > 0;
            }

            return false;
        }
    }
}