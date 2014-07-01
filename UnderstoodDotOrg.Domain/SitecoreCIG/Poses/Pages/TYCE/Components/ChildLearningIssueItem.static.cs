using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
    public partial class ChildLearningIssueItem
    {
        public static FolderItem GetChildLearningIssuesFolder()
        {
            return Sitecore.Context.Database.GetItem("{FFC2C76F-4E6C-458F-9E70-4273F562D243}");
        }

        public static IEnumerable<ChildLearningIssueItem> GetChildLearningIssues()
        {
            var tyceIssuesFolder = GetChildLearningIssuesFolder();
            return tyceIssuesFolder != null ?
                tyceIssuesFolder.InnerItem.Children
                    .Where(i => i != null && i.IsOfType(ChildLearningIssueItem.TemplateId))
                    .Select(i => (ChildLearningIssueItem)i) :
                new List<ChildLearningIssueItem>();
        }

        public static IEnumerable<ChildLearningIssueItem> GetTyceIssuesFromTaxonomy(Guid issueTaxonomyId)
        {
            var rawIssueId = issueTaxonomyId.ToString().ToLower();
            return GetChildLearningIssues()
                .Where(issue => issue.IssueTaxonomies.Raw.ToLower().Contains(rawIssueId));
        }

        public static IEnumerable<ChildLearningIssueItem> GetTyceIssuesFromTaxonomy(ID issueTaxonomyId)
        {
            return GetTyceIssuesFromTaxonomy(issueTaxonomyId.Guid);
        }

        public static IEnumerable<ChildLearningIssueItem> GetTyceIssuesFromTaxonomy(Item IssueTaxonomy)
        {
            return GetTyceIssuesFromTaxonomy(IssueTaxonomy.ID.Guid);
        }
    }
}