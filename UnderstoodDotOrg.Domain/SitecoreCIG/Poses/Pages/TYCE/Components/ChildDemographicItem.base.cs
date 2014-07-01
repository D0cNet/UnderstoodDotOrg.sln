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
public partial class ChildDemographicItem : CustomItem
{

public static readonly string TemplateId = "{81814536-F9A9-46BD-928E-DEDD2CFA43C7}";


#region Boilerplate CustomItem Code

public ChildDemographicItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ChildDemographicItem(Item innerItem)
{
	return innerItem != null ? new ChildDemographicItem(innerItem) : null;
}

public static implicit operator Item(ChildDemographicItem customItem)
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


public CustomTextField CssClass
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CssClass"]);
	}
}


#endregion //Field Instance Methods
}
}