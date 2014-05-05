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
public partial class ForgotPasswordItem : CustomItem
{

public static readonly string TemplateId = "{74E95CFE-00DC-4E77-8147-D42ED2F8C22B}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ForgotPasswordItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ForgotPasswordItem(Item innerItem)
{
	return innerItem != null ? new ForgotPasswordItem(innerItem) : null;
}

public static implicit operator Item(ForgotPasswordItem customItem)
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


public CustomTextField HintText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hint Text"]);
	}
}


public CustomTextField SuccessMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Success Message"]);
	}
}


#endregion //Field Instance Methods
}
}