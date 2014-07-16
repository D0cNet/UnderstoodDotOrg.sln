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
public partial class SignInPageItem : CustomItem
{

public static readonly string TemplateId = "{BDE9B35B-BC86-4E61-93F2-1AF66EE5731B}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public SignInPageItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator SignInPageItem(Item innerItem)
{
	return innerItem != null ? new SignInPageItem(innerItem) : null;
}

public static implicit operator Item(SignInPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Directions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Directions"]);
	}
}


public CustomImageField FacebookSigninImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["FacebookSigninImage"]);
	}
}


public CustomTextField NotaMemberText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Not a Member Text"]);
	}
}


public CustomTextField ForgotPasswordText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Forgot Password Text"]);
	}
}


#endregion //Field Instance Methods
}
}