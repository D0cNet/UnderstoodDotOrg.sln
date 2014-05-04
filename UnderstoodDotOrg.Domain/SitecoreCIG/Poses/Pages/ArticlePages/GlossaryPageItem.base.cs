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
public partial class GlossaryPageItem : CustomItem
{

public static readonly string TemplateId = "{69D0938A-BC3A-4060-8F08-6DE0DB315712}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GlossaryPageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator GlossaryPageItem(Item innerItem)
{
	return innerItem != null ? new GlossaryPageItem(innerItem) : null;
}

public static implicit operator Item(GlossaryPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Introduction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Introduction"]);
	}
}


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