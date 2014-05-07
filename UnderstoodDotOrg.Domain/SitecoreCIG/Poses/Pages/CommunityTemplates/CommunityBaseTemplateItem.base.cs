using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates
{
public partial class CommunityBaseTemplateItem : CustomItem
{

public static readonly string TemplateId = "{AF26EF9A-13CA-416D-A9B9-20B3FFB34DFD}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CommunityBaseTemplateItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator CommunityBaseTemplateItem(Item innerItem)
{
	return innerItem != null ? new CommunityBaseTemplateItem(innerItem) : null;
}

public static implicit operator Item(CommunityBaseTemplateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WelcomeText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Welcome Text"]);
	}
}


public CustomTextField DescriptionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description Text"]);
	}
}


public CustomTextField ShareandSaveText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Share and Save Text"]);
	}
}


public CustomTextField WhatsHappeningText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Whats Happening Text"]);
	}
}


public CustomTextField ExpertsLiveText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Experts Live Text"]);
	}
}


public CustomTextField QandAText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Q and A Text"]);
	}
}


public CustomTextField ParentsLikeMeText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Parents Like Me Text"]);
	}
}


public CustomTextField GroupsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Groups Text"]);
	}
}


public CustomTextField BlogsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Blogs Text"]);
	}
}


#endregion //Field Instance Methods
}
}