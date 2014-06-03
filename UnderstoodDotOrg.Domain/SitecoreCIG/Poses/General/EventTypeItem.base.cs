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
public partial class EventTypeItem : CustomItem
{

public static readonly string TemplateId = "{211BFD6A-1074-49D1-8E05-704994A22F8C}";


#region Boilerplate CustomItem Code

public EventTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EventTypeItem(Item innerItem)
{
	return innerItem != null ? new EventTypeItem(innerItem) : null;
}

public static implicit operator Item(EventTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EventTypeName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Type Name"]);
	}
}


public CustomLookupField EventTypeTemplate
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Event Type Template"]);
	}
}


#endregion //Field Instance Methods
}
}