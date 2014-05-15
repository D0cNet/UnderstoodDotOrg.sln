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
public partial class GroupDiscussionItem : CustomItem
{

public static readonly string TemplateId = "{E230410F-77D7-4E8C-8E6C-0FF9F9335EE5}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GroupDiscussionItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator GroupDiscussionItem(Item innerItem)
{
	return innerItem != null ? new GroupDiscussionItem(innerItem) : null;
}

public static implicit operator Item(GroupDiscussionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


public CustomTextField ForumID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ForumID"]);
	}
}


public CustomTextField ThreadID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ThreadID"]);
	}
}


#endregion //Field Instance Methods
}
}