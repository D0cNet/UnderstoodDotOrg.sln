using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.KnowledgeQuizArticlePage
{
public partial class BaseKnowledgeQuizQuestionItem : CustomItem
{

public static readonly string TemplateId = "{D588CBCB-611F-4B05-9980-2D23CBA2455B}";


#region Boilerplate CustomItem Code

public BaseKnowledgeQuizQuestionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BaseKnowledgeQuizQuestionItem(Item innerItem)
{
	return innerItem != null ? new BaseKnowledgeQuizQuestionItem(innerItem) : null;
}

public static implicit operator Item(BaseKnowledgeQuizQuestionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Question
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question"]);
	}
}


public CustomTextField AnswerExplanation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Answer Explanation"]);
	}
}


#endregion //Field Instance Methods
}
}