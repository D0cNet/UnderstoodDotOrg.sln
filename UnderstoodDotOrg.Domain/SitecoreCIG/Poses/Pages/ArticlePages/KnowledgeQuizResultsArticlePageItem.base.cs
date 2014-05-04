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
public partial class KnowledgeQuizResultsArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{A75612B8-9D45-4863-8B1A-FD8BC256562E}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public KnowledgeQuizResultsArticlePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator KnowledgeQuizResultsArticlePageItem(Item innerItem)
{
	return innerItem != null ? new KnowledgeQuizResultsArticlePageItem(innerItem) : null;
}

public static implicit operator Item(KnowledgeQuizResultsArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Reviewedby
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Reviewed by"]);
	}
}


public CustomDateField ReviewedDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Reviewed Date"]);
	}
}


#endregion //Field Instance Methods
}
}