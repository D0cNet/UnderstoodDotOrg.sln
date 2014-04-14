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
public partial class QuizQuestionItem : CustomItem
{

public static readonly string TemplateId = "{0739F45B-B556-43AA-8A65-13342DB4B443}";


#region Boilerplate CustomItem Code

public QuizQuestionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator QuizQuestionItem(Item innerItem)
{
	return innerItem != null ? new QuizQuestionItem(innerItem) : null;
}

public static implicit operator Item(QuizQuestionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField QuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Title"]);
	}
}


public CustomMultiListField QuestionType
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Question Type"]);
	}
}


#endregion //Field Instance Methods
}
}