using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.QuizPages
{
public partial class AssesmentQuizPageItem : CustomItem
{

public static readonly string TemplateId = "{E6D96973-22CE-4022-8B07-C9907A4F6999}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssesmentQuizPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AssesmentQuizPageItem(Item innerItem)
{
	return innerItem != null ? new AssesmentQuizPageItem(innerItem) : null;
}

public static implicit operator Item(AssesmentQuizPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField QuizIntroduction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Quiz Introduction"]);
	}
}


public CustomIntegerField NumberofQuestiononPage1
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Number of Question on Page 1"]);
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