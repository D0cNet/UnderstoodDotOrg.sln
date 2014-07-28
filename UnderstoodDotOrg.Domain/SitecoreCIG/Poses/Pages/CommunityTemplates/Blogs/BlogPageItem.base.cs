using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs
{
public partial class BlogPageItem : CustomItem
{

public static readonly string TemplateId = "{96DBBE63-5F3E-4505-9B8D-7CECCF1C73F1}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public BlogPageItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

}

public static implicit operator BlogPageItem(Item innerItem)
{
	return innerItem != null ? new BlogPageItem(innerItem) : null;
}

public static implicit operator Item(BlogPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField BlogId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["BlogId"]);
	}
}


public CustomTextField SearchThisBlogText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Search This Blog Text"]);
	}
}


public CustomTextField MostSharedThisWeekText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Most Shared This Week Text"]);
	}
}


public CustomTextField ParentsAreTalkingText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Parents Are Talking Text"]);
	}
}


public CustomTextField PostedText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Posted Text"]);
	}
}


public CustomTextField ByText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["By Text"]);
	}
}


public CustomTextField CommentsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Comments Text"]);
	}
}


#endregion //Field Instance Methods
}
}