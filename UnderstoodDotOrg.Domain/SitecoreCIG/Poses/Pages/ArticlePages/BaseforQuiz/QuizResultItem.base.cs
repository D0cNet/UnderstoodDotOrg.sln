using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz
{
public partial class QuizResultItem : CustomItem
{

public static readonly string TemplateId = "{F13DB919-6BF8-4A26-A8D7-BCA4F5A3E67F}";


#region Boilerplate CustomItem Code

public QuizResultItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator QuizResultItem(Item innerItem)
{
	return innerItem != null ? new QuizResultItem(innerItem) : null;
}

public static implicit operator Item(QuizResultItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ResultTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Result Title"]);
	}
}


public CustomTextField ResultDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Result Description"]);
	}
}


public CustomIntegerField MinimumScore
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Minimum Score"]);
	}
}


public CustomIntegerField MaximumScore
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Maximum Score"]);
	}
}


#endregion //Field Instance Methods
}
}