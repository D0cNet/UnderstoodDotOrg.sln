using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
public partial class SimulationItem : CustomItem
{

public static readonly string TemplateId = "{47C41593-0BF6-49F2-8288-089329541CA8}";


#region Boilerplate CustomItem Code

public SimulationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SimulationItem(Item innerItem)
{
	return innerItem != null ? new SimulationItem(innerItem) : null;
}

public static implicit operator Item(SimulationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField GameJS
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Game JS"]);
	}
}


public CustomTreeListField GameCSS
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Game CSS"]);
	}
}


#endregion //Field Instance Methods
}
}