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
public partial class GenericToolWidgetItem : CustomItem
{

public static readonly string TemplateId = "{C3BB483B-5685-4343-9495-806A30059024}";

#region Inherited Base Templates

private readonly ToolWidgetItem _ToolWidgetItem;
public ToolWidgetItem ToolWidget { get { return _ToolWidgetItem; } }

#endregion

#region Boilerplate CustomItem Code

public GenericToolWidgetItem(Item innerItem) : base(innerItem)
{
	_ToolWidgetItem = new ToolWidgetItem(innerItem);

}

public static implicit operator GenericToolWidgetItem(Item innerItem)
{
	return innerItem != null ? new GenericToolWidgetItem(innerItem) : null;
}

public static implicit operator Item(GenericToolWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WidgetBodyContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Body Content"]);
	}
}


#endregion //Field Instance Methods
}
}