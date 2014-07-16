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
public partial class RegisterChildInformationItem : CustomItem
{

public static readonly string TemplateId = "{3C979F62-5A3E-4847-B17F-50D060B17415}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public RegisterChildInformationItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator RegisterChildInformationItem(Item innerItem)
{
	return innerItem != null ? new RegisterChildInformationItem(innerItem) : null;
}

public static implicit operator Item(RegisterChildInformationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Header
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header"]);
	}
}


public CustomTextField Question
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question"]);
	}
}


public CustomTextField Gradedefaultselection
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Grade default selection"]);
	}
}


public CustomTextField Childnicknameplaceholder
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child nickname placeholder"]);
	}
}


public CustomTextField Childnicknamenotice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child nickname notice"]);
	}
}


public CustomTextField SeeMyRecommendationsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See My Recommendations Text"]);
	}
}


public CustomTextField CompleteMyFullProfileText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Complete My Full Profile Text"]);
	}
}


#endregion //Field Instance Methods
}
}