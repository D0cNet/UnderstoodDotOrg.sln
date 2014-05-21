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
public partial class ChildInformationPageItem : CustomItem
{

public static readonly string TemplateId = "{0255C952-5F53-4C74-A6A3-F002640F7518}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChildInformationPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ChildInformationPageItem(Item innerItem)
{
	return innerItem != null ? new ChildInformationPageItem(innerItem) : null;
}

public static implicit operator Item(ChildInformationPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ChildIssuesHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Issues Heading"]);
	}
}


public CustomTextField RequiredIssuesError
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Required Issues Error"]);
	}
}


public CustomTextField ChildEnrollmentHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Enrollment Heading"]);
	}
}


public CustomTextField RequiredNicknameError
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Required Nickname Error"]);
	}
}


public CustomTextField ChildNicknameHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Nickname Heading"]);
	}
}


public CustomTextField RequiredGradeError
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Required Grade Error"]);
	}
}


public CustomTextField ChildNicknameNote
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Nickname Note"]);
	}
}


public CustomTextField AnotherChildLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Another Child Label"]);
	}
}


#endregion //Field Instance Methods
}
}