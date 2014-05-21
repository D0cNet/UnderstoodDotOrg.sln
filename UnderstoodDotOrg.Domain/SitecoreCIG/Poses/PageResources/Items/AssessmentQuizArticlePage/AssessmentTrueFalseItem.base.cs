using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.AssessmentQuizArticlePage;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.AssessmentQuizArticlePage
{
public partial class AssessmentTrueFalseItem : CustomItem
{

public static readonly string TemplateId = "{5EAEBAA2-5E3D-4C42-863E-9E82F34F3355}";

#region Inherited Base Templates

private readonly BaseAssessmentQuizQuestionItem _BaseAssessmentQuizQuestionItem;
public BaseAssessmentQuizQuestionItem BaseAssessmentQuizQuestion { get { return _BaseAssessmentQuizQuestionItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssessmentTrueFalseItem(Item innerItem) : base(innerItem)
{
	_BaseAssessmentQuizQuestionItem = new BaseAssessmentQuizQuestionItem(innerItem);

}

public static implicit operator AssessmentTrueFalseItem(Item innerItem)
{
	return innerItem != null ? new AssessmentTrueFalseItem(innerItem) : null;
}

public static implicit operator Item(AssessmentTrueFalseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomIntegerField FalseValue
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["False Value"]);
	}
}


public CustomIntegerField TrueValue
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["True Value"]);
	}
}


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