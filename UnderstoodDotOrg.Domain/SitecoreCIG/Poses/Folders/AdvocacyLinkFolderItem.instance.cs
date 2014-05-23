using System;
using Sitecore.Data.Items;
using System.Linq;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class AdvocacyLinkFolderItem
    {
        public IEnumerable<AdvocacyLinkItem> GetAdvocacyLinks()
        {
            return InnerItem.Children
                .Where(i => i.IsOfType(AdvocacyLinkItem.TemplateId))
                .Select(i => (AdvocacyLinkItem)i);
        }
    }
}