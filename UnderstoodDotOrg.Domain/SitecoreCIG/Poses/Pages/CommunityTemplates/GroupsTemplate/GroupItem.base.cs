using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate
{
public partial class GroupItem : CustomItem
{

public static readonly string TemplateId = "{92FB8D67-690A-45F1-B330-C4BBAE189AAF}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public GroupItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

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

public CustomTextField NavigationTitle
{
	get
	{
        return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Title"]);
	}
}

public CustomTreeListField Issues
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Issues"]);
	}
}


public CustomTreeListField Topic
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Topic"]);
	}
}


public CustomTreeListField Grades
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Grades"]);
	}
}


public CustomTreeListField States
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["States"]);
	}
}


public CustomTreeListField Partners
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Partners"]);
	}
}


#endregion //Field Instance Methods
}
}