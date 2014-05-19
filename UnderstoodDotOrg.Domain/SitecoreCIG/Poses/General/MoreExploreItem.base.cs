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
public partial class MoreExploreItem : CustomItem
{

public static readonly string TemplateId = "{837C5673-E61E-4BBA-834E-048442CF35E9}";


#region Boilerplate CustomItem Code

public MoreExploreItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MoreExploreItem(Item innerItem)
{
	return innerItem != null ? new MoreExploreItem(innerItem) : null;
}

public static implicit operator Item(MoreExploreItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ExploreText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Explore Text"]);
	}
}


#endregion //Field Instance Methods
}
}