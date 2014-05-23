using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class AboutPartnersItem
    {

        public IEnumerable<PartnerInfoItem> GetPartners()
        {
            return InnerItem.GetChildren().FilterByContextLanguageVersion()
                            .Where(i => i.IsOfType(PartnerInfoItem.TemplateId))
                            .Select(i => new PartnerInfoItem(i));
        }
    }
}