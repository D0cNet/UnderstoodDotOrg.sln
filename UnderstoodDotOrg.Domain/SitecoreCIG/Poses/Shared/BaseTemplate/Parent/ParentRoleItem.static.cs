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
        public static IEnumerable<Sitecore.Data.Items.Item> GetParentRoles()
        {
            return Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/Parent Related/Parent Roles/*")
                .Where(x => x.TemplateID.ToString() == ParentRoleItem.TemplateId);
                //.Select(x => new ParentRoleItem(x));
        }
    }
}