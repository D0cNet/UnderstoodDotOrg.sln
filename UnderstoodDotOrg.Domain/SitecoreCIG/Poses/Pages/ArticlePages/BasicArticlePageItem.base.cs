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


public CustomTextField KeyTakeawayTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaway Title"]);
	}
}


public CustomTextField KeyTakeawayData
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaway Data"]);
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


public CustomTextField AtaglanceHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["At-a-glance Header"]);
	}
}


public CustomTextField AtaglanceContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["At-a-glance Content"]);
	}
}


#endregion //Field Instance Methods
}
}