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
public partial class ViewProfileItem : CustomItem
{

public static readonly string TemplateId = "{F80E0D1F-2932-4208-9447-FC4C4BE6ED30}";

#region Inherited Base Templates

private readonly CSSTemplateItem _CSSTemplateItem;
public CSSTemplateItem CSSTemplate { get { return _CSSTemplateItem; } }
private readonly JSTemplateItem _JSTemplateItem;
public JSTemplateItem JSTemplate { get { return _JSTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public ViewProfileItem(Item innerItem) : base(innerItem)
{
	_CSSTemplateItem = new CSSTemplateItem(innerItem);
	_JSTemplateItem = new JSTemplateItem(innerItem);

}

public static implicit operator ViewProfileItem(Item innerItem)
{
	return innerItem != null ? new ViewProfileItem(innerItem) : null;
}

public static implicit operator Item(ViewProfileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField UserNotAcceptingConnectionsMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["User Not Accepting Connections Message"]);
	}
}


public CustomTextField PrivateUserProfileHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Private User Profile Heading"]);
	}
}


public CustomTextField PrivateUserProfileSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Private User Profile Subheading"]);
	}
}


public CustomTextField PrivateUserProfileCallToAction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Private User Profile Call To Action"]);
	}
}


#endregion //Field Instance Methods
}
}