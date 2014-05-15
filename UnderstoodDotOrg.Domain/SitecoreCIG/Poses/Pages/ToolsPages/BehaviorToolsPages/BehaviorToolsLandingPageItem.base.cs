using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages
{
public partial class BehaviorToolsLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{00F8825A-95C3-47D4-80E1-ACA70FAD282A}";

#region Inherited Base Templates

private readonly BasePageNEWItem _BasePageNEWItem;
public BasePageNEWItem BasePageNEW { get { return _BasePageNEWItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorToolsLandingPageItem(Item innerItem) : base(innerItem)
{
	_BasePageNEWItem = new BasePageNEWItem(innerItem);

}

public static implicit operator BehaviorToolsLandingPageItem(Item innerItem)
{
	return innerItem != null ? new BehaviorToolsLandingPageItem(innerItem) : null;
}

public static implicit operator Item(BehaviorToolsLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField HeroImageDatasource
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Hero Image Datasource"]);
	}
}


#endregion //Field Instance Methods
}
}