using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Brightcove
{
public partial class BrightcoveMediaElementItem : CustomItem
{

public static readonly string TemplateId = "{C4EA24F3-C8BB-44CA-A224-DEF748ADF582}";

#region Inherited Base Templates

private readonly MediaElementItem _MediaElementItem;
public MediaElementItem MediaElement { get { return _MediaElementItem; } }

#endregion

#region Boilerplate CustomItem Code

public BrightcoveMediaElementItem(Item innerItem) : base(innerItem)
{
	_MediaElementItem = new MediaElementItem(innerItem);

}

public static implicit operator BrightcoveMediaElementItem(Item innerItem)
{
	return innerItem != null ? new BrightcoveMediaElementItem(innerItem) : null;
}

public static implicit operator Item(BrightcoveMediaElementItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for ID


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}


public CustomTextField ReferenceId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ReferenceId"]);
	}
}


//Could not find Field Type for ThumbnailURL


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ShortDescription"]);
	}
}


#endregion //Field Instance Methods
}
}