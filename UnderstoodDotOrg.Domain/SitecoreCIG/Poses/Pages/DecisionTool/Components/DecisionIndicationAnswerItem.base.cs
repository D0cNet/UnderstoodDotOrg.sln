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
public partial class DecisionIndicationAnswerItem : CustomItem
{

public static readonly string TemplateId = "{923F74A2-3043-4ED2-8CC9-27FBBD4111D3}";


#region Boilerplate CustomItem Code

public DecisionIndicationAnswerItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DecisionIndicationAnswerItem(Item innerItem)
{
	return innerItem != null ? new DecisionIndicationAnswerItem(innerItem) : null;
}

public static implicit operator Item(DecisionIndicationAnswerItem customItem)
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


public CustomTextField Abstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Abstract"]);
	}
}


public CustomLookupField Indicator
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Indicator"]);
	}
}


#endregion //Field Instance Methods
}
}