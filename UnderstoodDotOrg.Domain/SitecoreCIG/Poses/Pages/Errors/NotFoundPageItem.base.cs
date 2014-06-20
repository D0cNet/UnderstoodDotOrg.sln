using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Errors
{
public partial class NotFoundPageItem : CustomItem
{

public static readonly string TemplateId = "{503908C3-9877-4B52-96F8-F0BB5CE0C206}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public NotFoundPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator NotFoundPageItem(Item innerItem)
{
	return innerItem != null ? new NotFoundPageItem(innerItem) : null;
}

public static implicit operator Item(NotFoundPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PromoAreaHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo Area Heading"]);
	}
}


public CustomTextField Promo1Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo 1 Title"]);
	}
}


public CustomImageField HeroImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Hero Image"]);
	}
}


public CustomImageField Promo1Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Promo 1 Image"]);
	}
}


public CustomTextField HeroTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hero Title"]);
	}
}


public CustomGeneralLinkField Promo1Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Promo 1 Link"]);
	}
}


public CustomTextField HeroSubtitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hero Subtitle"]);
	}
}


public CustomTextField Promo2Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo 2 Title"]);
	}
}


public CustomTextField SearchBoxTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Search Box Title"]);
	}
}


public CustomImageField Promo2Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Promo 2 Image"]);
	}
}


public CustomTextField SearchBoxButton
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Search Box Button"]);
	}
}


public CustomGeneralLinkField Promo2Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Promo 2 Link"]);
	}
}


public CustomTextField Promo3Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo 3 Content"]);
	}
}


#endregion //Field Instance Methods
}
}