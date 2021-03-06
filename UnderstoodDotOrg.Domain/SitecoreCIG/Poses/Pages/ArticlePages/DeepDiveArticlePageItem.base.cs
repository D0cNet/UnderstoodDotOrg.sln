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
public partial class DeepDiveArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{155A3DF6-CE18-4332-A872-7FE10693AECA}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public DeepDiveArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator DeepDiveArticlePageItem(Item innerItem)
{
	return innerItem != null ? new DeepDiveArticlePageItem(innerItem) : null;
}

public static implicit operator Item(DeepDiveArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AppendixTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Appendix Title"]);
	}
}


public CustomTextField SourcesHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sources Header"]);
	}
}


public CustomTextField KeyTakeawaysDetails
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaways Details"]);
	}
}


public CustomTextField SourcesContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sources Content"]);
	}
}


public CustomCheckboxField ShowKeyTakeawayContent
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Key Takeaway Content"]);
	}
}


#endregion //Field Instance Methods
}
}