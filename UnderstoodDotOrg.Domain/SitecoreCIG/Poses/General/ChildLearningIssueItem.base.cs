using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class ChildLearningIssueItem : CustomItem
{

public static readonly string TemplateId = "{81814536-F9A9-46BD-928E-DEDD2CFA43C7}";


#region Boilerplate CustomItem Code

public ChildLearningIssueItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ChildLearningIssueItem(Item innerItem)
{
	return innerItem != null ? new ChildLearningIssueItem(innerItem) : null;
}

public static implicit operator Item(ChildLearningIssueItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField NavigationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Title"]);
	}
}


public CustomTextField Abstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Abstract"]);
	}
}


public CustomTextField IssueCssClass
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Issue CssClass"]);
	}
}


//Could not find Field Type for Featured Stories


#endregion //Field Instance Methods
}
}