using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.KnowledgeQuizArticlePage;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.KnowledgeQuizArticlePage
{
public partial class MultipleChoiceQuestionItem : CustomItem
{

public static readonly string TemplateId = "{D9DA4560-BE02-4736-8C23-51907643DF46}";

#region Inherited Base Templates

private readonly BaseKnowledgeQuizQuestionItem _BaseKnowledgeQuizQuestionItem;
public BaseKnowledgeQuizQuestionItem BaseKnowledgeQuizQuestion { get { return _BaseKnowledgeQuizQuestionItem; } }

#endregion

#region Boilerplate CustomItem Code

public MultipleChoiceQuestionItem(Item innerItem) : base(innerItem)
{
	_BaseKnowledgeQuizQuestionItem = new BaseKnowledgeQuizQuestionItem(innerItem);

}

public static implicit operator MultipleChoiceQuestionItem(Item innerItem)
{
	return innerItem != null ? new MultipleChoiceQuestionItem(innerItem) : null;
}

public static implicit operator Item(MultipleChoiceQuestionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField CorrectAnswer
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Correct Answer"]);
	}
}


#endregion //Field Instance Methods
}
}