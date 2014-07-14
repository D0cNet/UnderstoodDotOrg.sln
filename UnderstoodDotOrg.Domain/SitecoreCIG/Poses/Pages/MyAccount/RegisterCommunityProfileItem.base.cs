using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class RegisterCommunityProfileItem : CustomItem
{

public static readonly string TemplateId = "{ED6A48E9-39A8-408F-926E-8A1884CE2B40}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public RegisterCommunityProfileItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator RegisterCommunityProfileItem(Item innerItem)
{
	return innerItem != null ? new RegisterCommunityProfileItem(innerItem) : null;
}

public static implicit operator Item(RegisterCommunityProfileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Header
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header"]);
	}
}


public CustomTextField Subtitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Subtitle"]);
	}
}


public CustomTextField WhyDoWeAskLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Link Text"]);
	}
}


public CustomTextField WhyDoWeAskPopupContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Popup Content"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomTextField NewsletterText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Newsletter Text"]);
	}
}


public CustomTextField CompleteMyFullProfileText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Complete My Full Profile Text"]);
	}
}


#endregion //Field Instance Methods
}
}