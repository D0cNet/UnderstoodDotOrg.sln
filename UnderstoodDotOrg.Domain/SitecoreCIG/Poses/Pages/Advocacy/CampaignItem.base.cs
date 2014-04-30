using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class CampaignItem : CustomItem
{

public static readonly string TemplateId = "{88856CA5-5392-43F9-B241-606BF25E7C6B}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CampaignItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator CampaignItem(Item innerItem)
{
	return innerItem != null ? new CampaignItem(innerItem) : null;
}

public static implicit operator Item(CampaignItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomTextField LinkButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Button Text"]);
	}
}


//Could not find Field Type for Destination URL
public CustomGeneralLinkField DestinationURL
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Destination URL"]);
    }

}

#endregion //Field Instance Methods
}
}