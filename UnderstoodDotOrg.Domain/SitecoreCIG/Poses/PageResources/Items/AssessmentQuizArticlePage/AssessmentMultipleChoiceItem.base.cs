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
public partial class AssessmentMultipleChoiceItem : CustomItem
{

public static readonly string TemplateId = "{16CE5130-290C-472E-A2BC-5605399CC441}";

#region Inherited Base Templates

private readonly BaseAssessmentQuizQuestionItem _BaseAssessmentQuizQuestionItem;
public BaseAssessmentQuizQuestionItem BaseAssessmentQuizQuestion { get { return _BaseAssessmentQuizQuestionItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssessmentMultipleChoiceItem(Item innerItem) : base(innerItem)
{
	_BaseAssessmentQuizQuestionItem = new BaseAssessmentQuizQuestionItem(innerItem);

}

public static implicit operator AssessmentMultipleChoiceItem(Item innerItem)
{
	return innerItem != null ? new AssessmentMultipleChoiceItem(innerItem) : null;
}

public static implicit operator Item(AssessmentMultipleChoiceItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField IsDropDownList
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Is Drop Down List"]);
	}
}


public CustomTextField DropDownDefaultText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Drop Down Default Text"]);
	}
}


#endregion //Field Instance Methods
}
}