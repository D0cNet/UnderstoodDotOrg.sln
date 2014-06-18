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
public partial class UpcomingEventWidgetItem : CustomItem
{

public static readonly string TemplateId = "{DDCAA635-6C86-47D6-872C-5CDDDF42FBCD}";


#region Boilerplate CustomItem Code

public UpcomingEventWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator UpcomingEventWidgetItem(Item innerItem)
{
	return innerItem != null ? new UpcomingEventWidgetItem(innerItem) : null;
}

public static implicit operator Item(UpcomingEventWidgetItem customItem)
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


#endregion //Field Instance Methods
}
}