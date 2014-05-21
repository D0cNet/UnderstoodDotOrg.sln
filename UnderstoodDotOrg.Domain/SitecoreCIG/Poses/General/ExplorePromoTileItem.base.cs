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
public partial class ExplorePromoTileItem : CustomItem
{

public static readonly string TemplateId = "{0D35832A-6ED6-42D2-8D63-9258777702AE}";


#region Boilerplate CustomItem Code

public ExplorePromoTileItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ExplorePromoTileItem(Item innerItem)
{
	return innerItem != null ? new ExplorePromoTileItem(innerItem) : null;
}

public static implicit operator Item(ExplorePromoTileItem customItem)
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


public CustomImageField TileImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Tile Image"]);
	}
}


public CustomGeneralLinkField TileLink1
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Tile Link 1"]);
	}
}


public CustomGeneralLinkField TileLink2
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Tile Link 2"]);
	}
}


#endregion //Field Instance Methods
}
}