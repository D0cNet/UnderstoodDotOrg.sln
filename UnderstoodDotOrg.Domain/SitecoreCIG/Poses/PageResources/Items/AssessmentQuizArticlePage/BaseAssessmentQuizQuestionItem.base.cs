using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.AssessmentQuizArticlePage
{
public partial class BaseAssessmentQuizQuestionItem : CustomItem
{

public static readonly string TemplateId = "{F140E44A-4BED-48A2-8058-DD24311332A4}";


#region Boilerplate CustomItem Code

public BaseAssessmentQuizQuestionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BaseAssessmentQuizQuestionItem(Item innerItem)
{
	return innerItem != null ? new BaseAssessmentQuizQuestionItem(innerItem) : null;
}

public static implicit operator Item(BaseAssessmentQuizQuestionItem customItem)
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


#endregion //Field Instance Methods
}
}