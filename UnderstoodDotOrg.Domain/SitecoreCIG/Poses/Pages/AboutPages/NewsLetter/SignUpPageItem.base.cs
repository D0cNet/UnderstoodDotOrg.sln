using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter
{
public partial class SignUpPageItem : CustomItem
{

public static readonly string TemplateId = "{1BA824D7-5F27-4E1A-97E5-070C52AC00B3}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SignUpPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator SignUpPageItem(Item innerItem)
{
	return innerItem != null ? new SignUpPageItem(innerItem) : null;
}

public static implicit operator Item(SignUpPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField InvalidEmailError
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Invalid Email Error"]);
	}
}


public CustomTextField SecureDataTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Secure Data Title"]);
	}
}


public CustomTextField SecureDataDetails
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Secure Data Details"]);
	}
}


#endregion //Field Instance Methods
}
}