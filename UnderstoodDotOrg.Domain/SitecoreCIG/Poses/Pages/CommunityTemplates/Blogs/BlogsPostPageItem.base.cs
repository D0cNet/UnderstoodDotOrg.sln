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
public partial class BlogsPostPageItem : CustomItem
{

public static readonly string TemplateId = "{261A659C-F4D4-4788-BC26-FD0EF5ADE168}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public BlogsPostPageItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

}

public static implicit operator BlogsPostPageItem(Item innerItem)
{
	return innerItem != null ? new BlogsPostPageItem(innerItem) : null;
}

public static implicit operator Item(BlogsPostPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField BlogPostId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["BlogPostId"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField BlogId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["BlogId"]);
	}
}


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


public CustomTextField ContentId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ContentId"]);
	}
}


public CustomDateField Date
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date"]);
	}
}


public CustomMultiListField Author
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Author"]);
	}
}


public CustomTextField TelligentUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TelligentUrl"]);
	}
}


public CustomImageField BlogImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Blog Image"]);
	}
}


public CustomTextField ContentTypeId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ContentTypeId"]);
	}
}


#endregion //Field Instance Methods
}
}