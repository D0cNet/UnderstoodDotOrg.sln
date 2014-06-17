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
public partial class AssistiveToolWidgetItem : CustomItem
{

public static readonly string TemplateId = "{55DB47D0-D195-45A8-8CC4-E40BAA68F952}";

#region Inherited Base Templates

private readonly ToolWidgetItem _ToolWidgetItem;
public ToolWidgetItem ToolWidget { get { return _ToolWidgetItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolWidgetItem(Item innerItem) : base(innerItem)
{
	_ToolWidgetItem = new ToolWidgetItem(innerItem);

}

public static implicit operator AssistiveToolWidgetItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolWidgetItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}