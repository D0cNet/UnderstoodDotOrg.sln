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
public partial class ResetYourPasswordItem : CustomItem
{

public static readonly string TemplateId = "{3D700952-891D-423F-8D70-D6E965F506D9}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public ResetYourPasswordItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator ResetYourPasswordItem(Item innerItem)
{
	return innerItem != null ? new ResetYourPasswordItem(innerItem) : null;
}

public static implicit operator Item(ResetYourPasswordItem customItem)
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


public CustomTextField ForgotPasswordText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Forgot Password Text"]);
	}
}


public CustomTextField PasswordUpdatedText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Password Updated Text"]);
	}
}


public CustomTextField ForgotPasswordLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Forgot Password Link Text"]);
	}
}


#endregion //Field Instance Methods
}
}