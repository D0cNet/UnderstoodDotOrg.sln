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
public partial class TrueFalseQuestionItem : CustomItem
{

public static readonly string TemplateId = "{1585E5D6-9FEB-48C3-9A34-FDF582A59EBD}";

#region Inherited Base Templates

private readonly BaseKnowledgeQuizQuestionItem _BaseKnowledgeQuizQuestionItem;
public BaseKnowledgeQuizQuestionItem BaseKnowledgeQuizQuestion { get { return _BaseKnowledgeQuizQuestionItem; } }

#endregion

#region Boilerplate CustomItem Code

public TrueFalseQuestionItem(Item innerItem) : base(innerItem)
{
	_BaseKnowledgeQuizQuestionItem = new BaseKnowledgeQuizQuestionItem(innerItem);

}

public static implicit operator TrueFalseQuestionItem(Item innerItem)
{
	return innerItem != null ? new TrueFalseQuestionItem(innerItem) : null;
}

public static implicit operator Item(TrueFalseQuestionItem customItem)
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