using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class NavigationLinkItem : CustomItem
{

public static readonly string TemplateId = "{96C5B304-8E5D-46CA-AFA8-1507A93541B1}";


#region Boilerplate CustomItem Code

public NavigationLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NavigationLinkItem(Item innerItem)
{
	return innerItem != null ? new NavigationLinkItem(innerItem) : null;
}

public static implicit operator Item(NavigationLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


public CustomCheckboxField ShowImage
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Image"]);
	}
}


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomCheckboxField DisplayOnlyForLoggedInUsers
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display Only For Logged In Users"]);
	}
}


#endregion //Field Instance Methods
}
}