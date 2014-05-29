using System;
using Sitecore.Data.Items;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class DonatePageItem
    {
        public DonationConfirmationPageItem GetConfirmationPage()
        {
            return InnerItem.Children
                .FirstOrDefault(i => i.IsOfType(DonationConfirmationPageItem.TemplateId));
        }
    }
}