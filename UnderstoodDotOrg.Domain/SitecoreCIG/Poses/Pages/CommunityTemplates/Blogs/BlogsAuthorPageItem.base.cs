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
public partial class BlogsAuthorPageItem : CustomItem
{

public static readonly string TemplateId = "{2935D59E-3ACE-4143-9768-BF6D3921B2DB}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public BlogsAuthorPageItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

}

public static implicit operator BlogsAuthorPageItem(Item innerItem)
{
	return innerItem != null ? new BlogsAuthorPageItem(innerItem) : null;
}

public static implicit operator Item(BlogsAuthorPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}


public CustomTextField Biography
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Biography"]);
	}
}


public CustomImageField Avatar
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Avatar"]);
	}
}


#endregion //Field Instance Methods
}
}