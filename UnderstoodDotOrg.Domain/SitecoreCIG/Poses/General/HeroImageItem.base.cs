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
public partial class HeroImageItem : CustomItem
{

public static readonly string TemplateId = "{1B4A0DC1-9C2D-4F4B-B401-B6110AC8B016}";


#region Boilerplate CustomItem Code

public HeroImageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HeroImageItem(Item innerItem)
{
	return innerItem != null ? new HeroImageItem(innerItem) : null;
}

public static implicit operator Item(HeroImageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HeroHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hero Heading"]);
	}
}


public CustomTextField HeroSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hero Subheading"]);
	}
}


public CustomTextField HeroCallToAction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hero Call To Action"]);
	}
}


#endregion //Field Instance Methods
}
}