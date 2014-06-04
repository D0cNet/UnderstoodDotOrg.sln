using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
    public partial class ChildDiagnosisItem
    {
        public static IEnumerable<ChildDiagnosisItem> GetDiagnoses()
        {
            return Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/Child Related/Diagnosis/*")
                .Where(x => x.TemplateID.ToString() == ChildDiagnosisItem.TemplateId)
                .Select(x => new ChildDiagnosisItem(x));
        }
    }
}