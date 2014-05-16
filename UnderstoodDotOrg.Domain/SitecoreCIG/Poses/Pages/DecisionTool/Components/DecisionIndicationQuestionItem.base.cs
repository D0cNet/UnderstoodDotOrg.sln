using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components
{
public partial class DecisionIndicationQuestionItem : CustomItem
{

public static readonly string TemplateId = "{3D2D6064-F075-4BAF-8523-9135EA91523F}";


#region Boilerplate CustomItem Code

public DecisionIndicationQuestionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DecisionIndicationQuestionItem(Item innerItem)
{
	return innerItem != null ? new DecisionIndicationQuestionItem(innerItem) : null;
}

public static implicit operator Item(DecisionIndicationQuestionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField DisplayText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Text"]);
	}
}


#endregion //Field Instance Methods
}
}