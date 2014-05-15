using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
public partial class ArchiveItem : CustomItem
{

public static readonly string TemplateId = "{88E85996-CB62-410D-B858-A50999905A18}";


#region Boilerplate CustomItem Code

public ArchiveItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArchiveItem(Item innerItem)
{
	return innerItem != null ? new ArchiveItem(innerItem) : null;
}

public static implicit operator Item(ArchiveItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Heading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Heading"]);
	}
}


#endregion //Field Instance Methods
}
}