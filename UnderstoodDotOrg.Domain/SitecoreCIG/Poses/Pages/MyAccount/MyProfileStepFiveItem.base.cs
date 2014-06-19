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
public partial class MyProfileStepFiveItem : CustomItem
{

public static readonly string TemplateId = "{64F68167-5AC0-4A74-AF1E-5A02317DA864}";

#region Inherited Base Templates

private readonly MyProfileBaseTemplateItem _MyProfileBaseTemplateItem;
public MyProfileBaseTemplateItem MyProfileBaseTemplate { get { return _MyProfileBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileStepFiveItem(Item innerItem) : base(innerItem)
{
	_MyProfileBaseTemplateItem = new MyProfileBaseTemplateItem(innerItem);

}

public static implicit operator MyProfileStepFiveItem(Item innerItem)
{
	return innerItem != null ? new MyProfileStepFiveItem(innerItem) : null;
}

public static implicit operator Item(MyProfileStepFiveItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TakeMeBackText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Take Me Back Text"]);
	}
}


public CustomTreeListField ToolkitItems
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Toolkit Items"]);
	}
}


public CustomTextField GoNowText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Go Now Text"]);
	}
}


public CustomTextField LinkPageTitleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Page Title Text"]);
	}
}


#endregion //Field Instance Methods
}
}