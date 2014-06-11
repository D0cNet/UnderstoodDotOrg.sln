using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets
{
public partial class DonateWidgetItem : CustomItem
{

public static readonly string TemplateId = "{821850C5-6DE4-4A18-ACBF-E58123662202}";


#region Boilerplate CustomItem Code

public DonateWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DonateWidgetItem(Item innerItem)
{
	return innerItem != null ? new DonateWidgetItem(innerItem) : null;
}

public static implicit operator Item(DonateWidgetItem customItem)
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


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


public CustomTextField OtherOptionLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Option Label"]);
	}
}


#endregion //Field Instance Methods
}
}