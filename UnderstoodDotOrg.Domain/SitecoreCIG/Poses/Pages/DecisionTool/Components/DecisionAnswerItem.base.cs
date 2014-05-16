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
public partial class DecisionAnswerItem : CustomItem
{

public static readonly string TemplateId = "{83A061D3-A294-480B-A262-E0819BB7DA0C}";


#region Boilerplate CustomItem Code

public DecisionAnswerItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DecisionAnswerItem(Item innerItem)
{
	return innerItem != null ? new DecisionAnswerItem(innerItem) : null;
}

public static implicit operator Item(DecisionAnswerItem customItem)
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


#endregion //Field Instance Methods
}
}