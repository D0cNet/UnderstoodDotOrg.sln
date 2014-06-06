using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent
{
    public partial class ParentInterestItem
    {
        public static IEnumerable<Sitecore.Data.Items.Item> GetParentInterests(string Path)
        {
            return Sitecore.Context.Database.SelectItems(Path + "*")
                .Where(x => x.TemplateID.ToString() == ParentInterestItem.TemplateId);
                //.Select(x => new ParentInterestItem(x));
        }
    }
}