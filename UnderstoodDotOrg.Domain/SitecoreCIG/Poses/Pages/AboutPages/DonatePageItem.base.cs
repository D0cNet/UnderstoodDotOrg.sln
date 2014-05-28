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
public partial class DonatePageItem : CustomItem
{

public static readonly string TemplateId = "{05E56306-3798-4A7F-BDF5-35A0C5324C2C}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public DonatePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator DonatePageItem(Item innerItem)
{
	return innerItem != null ? new DonatePageItem(innerItem) : null;
}

public static implicit operator Item(DonatePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AmountHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Amount Header"]);
	}
}


public CustomTextField ConvioDonationFormID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Convio Donation Form ID"]);
	}
}


public CustomTextField CVVHelpText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CVV Help Text"]);
	}
}


public CustomTextField CheckHelpImageHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Check Help Image Header"]);
	}
}


public CustomImageField CheckHelpImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Check Help Image"]);
	}
}


public CustomTextField ConvioDonationLevelID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Convio Donation Level ID"]);
	}
}


public CustomTextField GiftforSomeoneHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Gift for Someone Header"]);
	}
}


public CustomTextField RecurringGiftHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Recurring Gift Header"]);
	}
}


public CustomTextField PaymentInformationHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Payment Information Header"]);
	}
}


#endregion //Field Instance Methods
}
}