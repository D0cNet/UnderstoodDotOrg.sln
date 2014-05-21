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
public partial class AssessmentMultipleChoiceAnswerItem : CustomItem
{

public static readonly string TemplateId = "{E257E492-AA87-499A-AB2D-AC578B547833}";


#region Boilerplate CustomItem Code

public AssessmentMultipleChoiceAnswerItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentMultipleChoiceAnswerItem(Item innerItem)
{
	return innerItem != null ? new AssessmentMultipleChoiceAnswerItem(innerItem) : null;
}

public static implicit operator Item(AssessmentMultipleChoiceAnswerItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Answer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Answer"]);
	}
}


public CustomIntegerField Value
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Value"]);
	}
}


#endregion //Field Instance Methods
}
}