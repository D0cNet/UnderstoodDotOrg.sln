using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
public partial class ChildLearningIssueItem : CustomItem
{

public static readonly string TemplateId = "{97051BC0-3B60-414A-A855-BD636D17B529}";

#region Inherited Base Templates

private readonly ChildDemographicItem _ChildDemographicItem;
public ChildDemographicItem ChildDemographic { get { return _ChildDemographicItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChildLearningIssueItem(Item innerItem) : base(innerItem)
{
	_ChildDemographicItem = new ChildDemographicItem(innerItem);

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


//Could not find Field Type for Expert Summary With Subtitles


//Could not find Field Type for Expert Summary Without Subtitles


public CustomTreeListField SimulationJS
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Simulation JS"]);
	}
}


public CustomTreeListField SimulationCSS
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Simulation CSS"]);
	}
}


public CustomTextField SimulationCssClass
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Simulation CssClass"]);
	}
}


#endregion //Field Instance Methods
}
}