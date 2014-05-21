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
public partial class AssessmentQuizQuestionPageItem : CustomItem
{

public static readonly string TemplateId = "{F89363AC-5124-49DF-B174-67B399AEAA37}";


#region Boilerplate CustomItem Code

public AssessmentQuizQuestionPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizQuestionPageItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizQuestionPageItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizQuestionPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField IntroText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Intro Text"]);
	}
}


#endregion //Field Instance Methods
}
}