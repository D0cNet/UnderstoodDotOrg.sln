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
public partial class PartnerInfoItem : CustomItem
{

public static readonly string TemplateId = "{BA989DC5-33AD-4064-B4AA-48881FA52EC6}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PartnerInfoItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator PartnerInfoItem(Item innerItem)
{
	return innerItem != null ? new PartnerInfoItem(innerItem) : null;
}

public static implicit operator Item(PartnerInfoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField ArticlestoShow
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Articles to Show"]);
	}
}


public CustomTextField NewsletterHeadLine
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Newsletter Head Line"]);
	}
}


public CustomTextField PartnerName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Name"]);
	}
}


public CustomTextField FeaturedHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Headline"]);
	}
}


public CustomGeneralLinkField NewsletterNavigantionpage
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Newsletter Navigantion page"]);
	}
}


public CustomTextField SubHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sub Headline"]);
	}
}


public CustomTextField DonationHeadLine
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Donation Head Line"]);
	}
}


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Description"]);
	}
}


public CustomGeneralLinkField DonationNavigantionpage
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Donation Navigantion page"]);
	}
}


public CustomTextField Link
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link"]);
	}
}


public CustomImageField Logo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Logo"]);
	}
}


#endregion //Field Instance Methods
}
}