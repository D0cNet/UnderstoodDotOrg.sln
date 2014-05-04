using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle
{
public partial class TextOnlyTipsArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{EA5A6950-0A1F-4199-839A-6F49CB8A9BF9}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TextOnlyTipsArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator TextOnlyTipsArticlePageItem(Item innerItem)
{
	return innerItem != null ? new TextOnlyTipsArticlePageItem(innerItem) : null;
}

public static implicit operator Item(TextOnlyTipsArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}