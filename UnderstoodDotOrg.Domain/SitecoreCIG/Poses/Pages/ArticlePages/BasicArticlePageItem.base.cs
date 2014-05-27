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
public partial class BasicArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{67D1EA88-ECA0-4B4F-BA2A-AD2E83ED4FF0}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BasicArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator BasicArticlePageItem(Item innerItem)
{
	return innerItem != null ? new BasicArticlePageItem(innerItem) : null;
}

public static implicit operator Item(BasicArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ArticleOriginalID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Article Original ID"]);
	}
}


public CustomCheckboxField ShowComment
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Comment"]);
	}
}


public CustomTextField CommentOverrideID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Comment Override ID"]);
	}
}


public CustomTextField KeyTakeawayData
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaway Data"]);
	}
}


public CustomTextField AtaglanceContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["At a glance Content"]);
	}
}


#endregion //Field Instance Methods
}
}