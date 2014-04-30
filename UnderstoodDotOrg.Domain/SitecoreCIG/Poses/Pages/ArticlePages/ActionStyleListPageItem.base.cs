using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class ActionStyleListPageItem : CustomItem
{

public static readonly string TemplateId = "{DE610867-BB6C-4E3F-957C-3A340BF028F5}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ActionStyleListPageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator ActionStyleListPageItem(Item innerItem)
{
	return innerItem != null ? new ActionStyleListPageItem(innerItem) : null;
}

public static implicit operator Item(ActionStyleListPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField KeepReadingHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Keep Reading Headline"]);
	}
}


public CustomTreeListField KeepReadingContent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Keep Reading Content"]);
	}
}


public CustomCheckboxField ShowPromotionalControl
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Promotional Control"]);
	}
}


public CustomTextField PromotionalHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promotional Headline"]);
	}
}


public CustomTreeListField PromotionalContent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Promotional Content"]);
	}
}


#endregion //Field Instance Methods
}
}