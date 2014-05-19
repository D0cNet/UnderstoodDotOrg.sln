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
public partial class AuthenticationNavigationLinkItem : CustomItem
{

public static readonly string TemplateId = "{7B15ACFE-CEC6-4D8E-94B6-2CBBEDA0A8A8}";


#region Boilerplate CustomItem Code

public AuthenticationNavigationLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AuthenticationNavigationLinkItem(Item innerItem)
{
	return innerItem != null ? new AuthenticationNavigationLinkItem(innerItem) : null;
}

public static implicit operator Item(AuthenticationNavigationLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField LoginLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Login Link"]);
	}
}


public CustomTextField LogoutText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Logout Text"]);
	}
}


#endregion //Field Instance Methods
}
}