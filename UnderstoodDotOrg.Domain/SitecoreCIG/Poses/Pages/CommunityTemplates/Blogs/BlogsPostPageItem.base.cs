using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs
{
public partial class BlogsPostPageItem : CustomItem
{

public static readonly string TemplateId = "{261A659C-F4D4-4788-BC26-FD0EF5ADE168}";


#region Boilerplate CustomItem Code

public BlogsPostPageItem(Item innerItem) : base(innerItem)
{

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


public CustomDateField Date
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date"]);
	}
}


public CustomTextField Author
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Author"]);
	}
}


#endregion //Field Instance Methods
}
}