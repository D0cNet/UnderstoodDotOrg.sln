using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle
{
public partial class SimpleExpertArticleItem : CustomItem
{

public static readonly string TemplateId = "{A058A879-6091-46D5-A1A7-1B1C2BFA6EBF}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SimpleExpertArticleItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator SimpleExpertArticleItem(Item innerItem)
{
	return innerItem != null ? new SimpleExpertArticleItem(innerItem) : null;
}

public static implicit operator Item(SimpleExpertArticleItem customItem)
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


//public CustomTextField PromotionalHeadline
//{
//    get
//    {
//        return new CustomTextField(InnerItem, InnerItem.Fields["Promotional Headline"]);
//    }
//}


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