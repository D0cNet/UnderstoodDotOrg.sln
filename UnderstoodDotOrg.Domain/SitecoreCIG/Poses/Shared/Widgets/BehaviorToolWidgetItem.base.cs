using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets
{
public partial class BehaviorToolWidgetItem : CustomItem
{

public static readonly string TemplateId = "{8CE50010-C4D2-4A11-95D7-FB17DC955EE5}";

#region Inherited Base Templates

private readonly ToolWidgetItem _ToolWidgetItem;
public ToolWidgetItem ToolWidget { get { return _ToolWidgetItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorToolWidgetItem(Item innerItem) : base(innerItem)
{
	_ToolWidgetItem = new ToolWidgetItem(innerItem);

}

public static implicit operator BehaviorToolWidgetItem(Item innerItem)
{
	return innerItem != null ? new BehaviorToolWidgetItem(innerItem) : null;
}

public static implicit operator Item(BehaviorToolWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}