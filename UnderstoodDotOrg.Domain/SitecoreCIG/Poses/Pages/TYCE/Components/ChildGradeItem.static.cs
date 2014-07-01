using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
    public partial class ChildGradeItem
    {
        public static FolderItem GetTyceGradesFolder()
        {
            return Sitecore.Context.Database.GetItem("{17BF4487-9EC2-4434-A86E-B27D41CC3BC7}");
        }

        public static IEnumerable<ChildGradeItem> GetChildGrades()
        {
            var tyceGradesFolder = GetTyceGradesFolder();
            return tyceGradesFolder != null ?
                tyceGradesFolder.InnerItem.Children
                    .Where(i => i != null && i.IsOfType(ChildGradeItem.TemplateId))
                    .Select(i => (ChildGradeItem)i) :
                new List<ChildGradeItem>();
        }

        public static ChildGradeItem GetTyceGradeFromTaxonomy(Guid gradeTaxonomyId)
        {
            var rawGradeId = gradeTaxonomyId.ToString().ToLower();
            return GetChildGrades()
                .FirstOrDefault(g => g.GradeTaxonomy.Raw.ToLower().Contains(rawGradeId));
        }

        public static ChildGradeItem GetTyceGradeFromTaxonomy(ID gradeTaxonomyId)
        {
            return GetTyceGradeFromTaxonomy(gradeTaxonomyId.Guid);
        }

        public static ChildGradeItem GetTyceGradeFromTaxonomy(Item gradeTaxonomy)
        {
            return GetTyceGradeFromTaxonomy(gradeTaxonomy.ID.Guid);
        }
    }
}