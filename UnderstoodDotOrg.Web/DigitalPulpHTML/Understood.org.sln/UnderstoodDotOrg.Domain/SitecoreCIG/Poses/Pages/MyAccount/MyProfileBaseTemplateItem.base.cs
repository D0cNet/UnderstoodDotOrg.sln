using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class MyProfileBaseTemplateItem : CustomItem
{

public static readonly string TemplateId = "{7E3D237D-C724-47D9-966A-E181CF5E3A30}";


#region Boilerplate CustomItem Code

public MyProfileBaseTemplateItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MyProfileBaseTemplateItem(Item innerItem)
{
	return innerItem != null ? new MyProfileBaseTemplateItem(innerItem) : null;
}

public static implicit operator Item(MyProfileBaseTemplateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HeaderTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Title"]);
	}
}


public CustomTextField HeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Text"]);
	}
}


public CustomTextField HeaderProgressBarText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Progress Bar Text"]);
	}
}


public CustomImageField HeaderProgressBarImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Progress Bar Image"]);
	}
}


public CustomTextField HeaderProgressBarDoneText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Progress Bar Done Text"]);
	}
}


#endregion //Field Instance Methods
}
}