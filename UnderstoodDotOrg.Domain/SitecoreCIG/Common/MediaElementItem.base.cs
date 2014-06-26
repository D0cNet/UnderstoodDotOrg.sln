using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Common
{
public partial class MediaElementItem : CustomItem
{

public static readonly string TemplateId = "{7C758A18-26A4-48F0-A2AA-068246A27322}";


#region Boilerplate CustomItem Code

public MediaElementItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MediaElementItem(Item innerItem)
{
	return innerItem != null ? new MediaElementItem(innerItem) : null;
}

public static implicit operator Item(MediaElementItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField Events
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Events"]);
	}
}


#endregion //Field Instance Methods
}
}