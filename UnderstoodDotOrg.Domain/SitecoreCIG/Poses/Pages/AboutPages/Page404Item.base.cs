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
public partial class Page404Item : CustomItem
{

public static readonly string TemplateId = "{3C51295A-3985-4AF9-BA49-17DDB79985BC}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public Page404Item(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator Page404Item(Item innerItem)
{
	return innerItem != null ? new Page404Item(innerItem) : null;
}

public static implicit operator Item(Page404Item customItem)
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


public CustomTreeListField PromoContent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Promo Content"]);
	}
}


public CustomLookupField Promo1
{
	get
	{
        return new CustomLookupField(InnerItem, InnerItem.Fields["Promo 1"]);
	}
}


public CustomLookupField Promo2
{
	get
	{
        return new CustomLookupField(InnerItem, InnerItem.Fields["Promo 2"]);
	}
}


#endregion //Field Instance Methods
}
}