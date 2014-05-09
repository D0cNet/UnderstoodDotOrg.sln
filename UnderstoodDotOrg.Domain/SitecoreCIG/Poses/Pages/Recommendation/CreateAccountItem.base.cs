using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation
{
public partial class CreateAccountItem : CustomItem
{

public static readonly string TemplateId = "{0E73A982-2939-44DF-A9CA-4D37D0C5C356}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CreateAccountItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator CreateAccountItem(Item innerItem)
{
	return innerItem != null ? new CreateAccountItem(innerItem) : null;
}

public static implicit operator Item(CreateAccountItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField ImageContent
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image Content"]);
	}
}


//Could not find Field Type for Promo Content

public CustomTreeListField PromoContent
{
    get
    {
        return new CustomTreeListField(InnerItem, InnerItem.Fields["Promo Content"]);
    }
}


//Could not find Field Type for Sign up Page Link
public CustomGeneralLinkField SignupPageLink
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Sign up Page Link"]);
    }

}


public CustomTextField RecommendationHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Recommendation Header"]);
	}
}


//Could not find Field Type for Sign in Page Link
public CustomGeneralLinkField SigninPageLink
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Sign in Page Link"]);
    }

}


#endregion //Field Instance Methods
}
}