using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class MyProfileItem : CustomItem
{

public static readonly string TemplateId = "{8BD18552-C1CC-4300-AB28-FB2005D540A0}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator MyProfileItem(Item innerItem)
{
	return innerItem != null ? new MyProfileItem(innerItem) : null;
}

public static implicit operator Item(MyProfileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField SignInPage
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Sign In Page"]);
	}
}


public CustomTextField VisitorsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Visitors Text"]);
	}
}


public CustomTextField MembersText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Members Text"]);
	}
}


public CustomTextField FriendsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Friends Text"]);
	}
}


public CustomTextField NoProfileText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Profile Text"]);
	}
}


public CustomTextField AddChildText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Add Child Text"]);
	}
}


#endregion //Field Instance Methods
}
}