using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate
{
public partial class ForumItem : CustomItem
{

public static readonly string TemplateId = "{F14D990C-8809-4C02-BCF7-AE6719C78CBB}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ForumItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ForumItem(Item innerItem)
{
	return innerItem != null ? new ForumItem(innerItem) : null;
}

public static implicit operator Item(ForumItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomTextField ForumID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ForumID"]);
	}
}


public CustomTextField GroupID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GroupID"]);
	}
}


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}


#endregion //Field Instance Methods
}
}