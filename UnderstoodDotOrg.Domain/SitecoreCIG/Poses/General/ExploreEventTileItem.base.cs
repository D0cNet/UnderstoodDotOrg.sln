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
public partial class ExploreEventTileItem : CustomItem
{

public static readonly string TemplateId = "{15A8B4DC-D729-466D-8D25-2E1A520D3F42}";


#region Boilerplate CustomItem Code

public ExploreEventTileItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ExploreEventTileItem(Item innerItem)
{
	return innerItem != null ? new ExploreEventTileItem(innerItem) : null;
}

public static implicit operator Item(ExploreEventTileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MoreText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Text"]);
	}
}


public CustomImageField EventImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Event Image"]);
	}
}


public CustomLookupField OverrideEvent
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Override Event"]);
	}
}


#endregion //Field Instance Methods
}
}