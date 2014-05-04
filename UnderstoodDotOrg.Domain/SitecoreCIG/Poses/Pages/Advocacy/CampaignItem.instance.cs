using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class CampaignItem 
{
    public CustomGeneralLinkField DestinationURL
    {
        get
        {
            return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Destination URL"]);
        }

    }
}
}