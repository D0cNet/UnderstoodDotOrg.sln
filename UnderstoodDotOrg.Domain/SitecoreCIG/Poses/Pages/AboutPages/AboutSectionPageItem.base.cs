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
public partial class AboutSectionPageItem : CustomItem
{

public static readonly string TemplateId = "{60A42D08-862D-4788-B3F6-3A4CED124027}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutSectionPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AboutSectionPageItem(Item innerItem)
{
	return innerItem != null ? new AboutSectionPageItem(innerItem) : null;
}

public static implicit operator Item(AboutSectionPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField NavigationSectionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Section Title"]);
	}
}


public CustomTextField NavigationSectionSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Section Summary"]);
	}
}


public CustomImageField NavigationSectionImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Navigation Section Image"]);
	}
}


#endregion //Field Instance Methods
}
}