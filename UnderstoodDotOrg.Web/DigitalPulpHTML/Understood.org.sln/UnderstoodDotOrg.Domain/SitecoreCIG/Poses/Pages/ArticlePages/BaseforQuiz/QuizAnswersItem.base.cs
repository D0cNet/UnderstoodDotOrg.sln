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
public partial class QuizAnswersItem : CustomItem
{

public static readonly string TemplateId = "{D5F85D02-EC39-4D09-A628-B1B0CF27B1DD}";


#region Boilerplate CustomItem Code

public QuizAnswersItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator QuizAnswersItem(Item innerItem)
{
	return innerItem != null ? new QuizAnswersItem(innerItem) : null;
}

public static implicit operator Item(QuizAnswersItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TrueAnswer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["True Answer"]);
	}
}


public CustomTextField Answer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Answer"]);
	}
}


public CustomTextField FalseAnswer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["False Answer"]);
	}
}


public CustomIntegerField Score
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Score"]);
	}
}


public CustomCheckboxField SetCorrectAnswer
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Set Correct Answer"]);
	}
}


#endregion //Field Instance Methods
}
}