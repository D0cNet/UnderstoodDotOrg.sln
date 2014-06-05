using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class PromosFolderItem
    {
        /// <summary>
        /// Get promos items.
        /// </summary>
        /// <returns></returns>
        public List<Item> GetPromoItems()
        {
            return InnerItem.Children.Where(i => i.IsOfType(PromoItem.TemplateId)).ToList();
        }
    }
}