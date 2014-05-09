using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class DonationThankYouPageItem : CustomItem
{

public static readonly string TemplateId = "{C11B0CED-9542-4151-A703-555F7FE7F1B4}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public DonationThankYouPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator DonationThankYouPageItem(Item innerItem)
{
	return innerItem != null ? new DonationThankYouPageItem(innerItem) : null;
}

public static implicit operator Item(DonationThankYouPageItem customItem)
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


public CustomTextField RecommendationHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Recommendation Header"]);
	}
}


#endregion //Field Instance Methods
}
}