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
public partial class TimeZoneItem : CustomItem
{

public static readonly string TemplateId = "{CE44EFF5-1DE4-4CB9-A347-80F85D70EC27}";


#region Boilerplate CustomItem Code

public TimeZoneItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TimeZoneItem(Item innerItem)
{
	return innerItem != null ? new TimeZoneItem(innerItem) : null;
}

public static implicit operator Item(TimeZoneItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Timezone
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Timezone"]);
	}
}


#endregion //Field Instance Methods
}
}