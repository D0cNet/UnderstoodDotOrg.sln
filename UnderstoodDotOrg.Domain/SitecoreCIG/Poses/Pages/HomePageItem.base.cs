using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages
{
public partial class HomePageItem : CustomItem
{

public static readonly string TemplateId = "{20477F15-FA1C-4E80-8B0D-2BFD3651AB4C}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public HomePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator HomePageItem(Item innerItem)
{
	return innerItem != null ? new HomePageItem(innerItem) : null;
}

public static implicit operator Item(HomePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField YourParentToolkitHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Your Parent Toolkit Heading"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomTextField YourParentToolkitDetails
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Your Parent Toolkit Details"]);
	}
}


public CustomLookupField YourParentToolkitList
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Your Parent Toolkit List"]);
	}
}


#endregion //Field Instance Methods
}
}