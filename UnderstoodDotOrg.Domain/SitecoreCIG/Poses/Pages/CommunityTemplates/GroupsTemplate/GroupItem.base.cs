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
public partial class GroupItem : CustomItem
{

public static readonly string TemplateId = "{92FB8D67-690A-45F1-B330-C4BBAE189AAF}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GroupItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator GroupItem(Item innerItem)
{
	return innerItem != null ? new GroupItem(innerItem) : null;
}

public static implicit operator Item(GroupItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField UserID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["UserID"]);
	}
}


public CustomTextField GroupID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GroupID"]);
	}
}


public CustomTreeListField Issues
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Issues"]);
	}
}


#endregion //Field Instance Methods
}
}