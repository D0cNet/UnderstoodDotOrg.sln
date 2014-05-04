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
public partial class AssessmentQuizArticlePageEndItem : CustomItem
{

public static readonly string TemplateId = "{1F831621-0BE5-48B3-A6D6-9660F701DE24}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssessmentQuizArticlePageEndItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AssessmentQuizArticlePageEndItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizArticlePageEndItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizArticlePageEndItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField QuizHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Quiz Headline"]);
	}
}


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