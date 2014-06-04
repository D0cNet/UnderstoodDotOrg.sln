using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
    public partial class ChildIssueItem
    {
        public static IEnumerable<ChildIssueItem> GetIssues(bool MakeDisplaySafe = true)
        {
            var ret = Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/Child Related/Issues/*")
                .Where(x => x.TemplateID.ToString() == ChildIssueItem.TemplateId)
                .Select(x => new ChildIssueItem(x));

            if (MakeDisplaySafe)
            {
                return ret.Where(x => x.ExcludeFromWebsiteDisplay == false).ToList<ChildIssueItem>();
            }

            return ret;
        }
    }
}