using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class LandingPageResourceArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{A4D4F492-6782-44B5-89AC-C513065152C5}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public LandingPageResourceArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator LandingPageResourceArticlePageItem(Item innerItem)
{
	return innerItem != null ? new LandingPageResourceArticlePageItem(innerItem) : null;
}

public static implicit operator Item(LandingPageResourceArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField SelectArticles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Select Articles"]);
	}
}


#endregion //Field Instance Methods
}
}