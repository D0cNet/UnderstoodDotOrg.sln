using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class AdvocacyArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{19F73E56-7E0D-4E77-A7BE-E71E757556F6}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }
private readonly AdvocacyBasePageItem _AdvocacyBasePageItem;
public AdvocacyBasePageItem AdvocacyBasePage { get { return _AdvocacyBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdvocacyArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);
	_AdvocacyBasePageItem = new AdvocacyBasePageItem(innerItem);

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


#endregion //Field Instance Methods
}
}