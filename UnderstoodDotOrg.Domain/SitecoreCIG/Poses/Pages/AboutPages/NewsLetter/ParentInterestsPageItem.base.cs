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
public partial class ParentInterestsPageItem : CustomItem
{

public static readonly string TemplateId = "{8311D4F3-F460-4733-AB9C-8C820B92BA25}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ParentInterestsPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ParentInterestsPageItem(Item innerItem)
{
	return innerItem != null ? new ParentInterestsPageItem(innerItem) : null;
}

public static implicit operator Item(ParentInterestsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField LanguageRequiredError
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Language Required Error"]);
	}
}


public CustomTextField SchoolIssuesHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["School Issues Heading"]);
	}
}


public CustomTextField WaysToHelpHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Ways To Help Heading"]);
	}
}


public CustomTextField HomeLifeHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Home Life Heading"]);
	}
}


public CustomTextField GrowingUpHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Growing Up Heading"]);
	}
}


public CustomTextField SocialEmotionalHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Social Emotional Heading"]);
	}
}


public CustomTextField PreferredLanguageHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Preferred Language Heading"]);
	}
}


#endregion //Field Instance Methods
}
}