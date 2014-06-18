using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent
{
    public partial class ParentRoleItem
    {
        public static IEnumerable<ParentRoleItem> GetParentRoles()
        {
            return Sitecore.Context.Database.GetItem("/sitecore/content/Globals/Content Taxonomies/Parent Related/Parent Roles/")
                .GetChildren()
                .Where(x => x.TemplateID.ToString() == ParentRoleItem.TemplateId)
                .Select(x => new ParentRoleItem(x));
        }
    }
}