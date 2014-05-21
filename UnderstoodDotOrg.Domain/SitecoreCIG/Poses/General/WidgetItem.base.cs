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
public partial class WidgetItem : CustomItem
{

public static readonly string TemplateId = "{1D3235C6-1AD4-4BF2-813B-DC5038338855}";


#region Boilerplate CustomItem Code

public WidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WidgetItem(Item innerItem)
{
	return innerItem != null ? new WidgetItem(innerItem) : null;
}

public static implicit operator Item(WidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WidgetTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Title"]);
	}
}


public CustomTextField WidgetDetail
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Detail"]);
	}
}


#endregion //Field Instance Methods
}
}