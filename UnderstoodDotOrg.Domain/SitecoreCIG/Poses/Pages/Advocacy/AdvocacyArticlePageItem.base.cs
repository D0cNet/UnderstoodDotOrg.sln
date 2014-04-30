using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class AdvocacyArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{85D31E56-DE2F-4EAA-8687-F8F63C8578A7}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdvocacyArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator AdvocacyArticlePageItem(Item innerItem)
{
	return innerItem != null ? new AdvocacyArticlePageItem(innerItem) : null;
}

public static implicit operator Item(AdvocacyArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField DisplayTextforLink1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Text for Link1"]);
	}
}


public CustomTextField NavigationURLforLink1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation URL for Link1"]);
	}
}


public CustomTextField DisplayTextforLink2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Text for Link2"]);
	}
}


public CustomTextField NavigationURLforLink2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation URL for Link2"]);
	}
}


public CustomTextField DisplayTextforLink3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Text for Link3"]);
	}
}


public CustomTextField NavigationURLforLink3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation URL for Link3"]);
	}
}


#endregion //Field Instance Methods
}
}