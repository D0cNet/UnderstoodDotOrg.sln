using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
    public partial class GradeLevelItem
    {
        public static IEnumerable<GradeLevelItem> GetGrades(bool MakeDisplaySafe = true)
        {
            var ret = Sitecore.Context.Database.GetItem("/sitecore/content/Globals/Content Taxonomies/Child Related/Grade/")
                .GetChildren()
                .Where(x => x.TemplateID.ToString() == GradeLevelItem.TemplateId)
                .Select(x => new GradeLevelItem(x));

            if (MakeDisplaySafe)
            {
                return ret.Where(x => x.ExcludeFromWebsiteDisplay == false).ToList<GradeLevelItem>();
            }

            return ret;
        }
    }
}