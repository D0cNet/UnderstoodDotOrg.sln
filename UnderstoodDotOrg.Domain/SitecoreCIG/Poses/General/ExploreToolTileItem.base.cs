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
public partial class ExploreToolTileItem : CustomItem
{

public static readonly string TemplateId = "{6A53B1BD-0D38-4C08-A0C6-BA70F2A963BC}";


#region Boilerplate CustomItem Code

public ExploreToolTileItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ExploreToolTileItem(Item innerItem)
{
	return innerItem != null ? new ExploreToolTileItem(innerItem) : null;
}

public static implicit operator Item(ExploreToolTileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TileTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tile Title"]);
	}
}


public CustomTextField TileDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tile Description"]);
	}
}


public CustomLookupField ToolWidget
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Tool Widget"]);
	}
}


#endregion //Field Instance Methods
}
}