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
public partial class SlideshowArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{1A7DE3A8-3752-4F12-9354-25A043E32382}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SlideshowArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator SlideshowArticlePageItem(Item innerItem)
{
	return innerItem != null ? new SlideshowArticlePageItem(innerItem) : null;
}

public static implicit operator Item(SlideshowArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}