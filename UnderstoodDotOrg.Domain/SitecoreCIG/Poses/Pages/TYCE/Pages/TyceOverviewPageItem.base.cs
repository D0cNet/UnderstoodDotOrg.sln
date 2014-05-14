using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages
{
public partial class TyceOverviewPageItem : CustomItem
{

public static readonly string TemplateId = "{35E678BF-870D-4916-95E3-FB7E190A5A65}";

#region Inherited Base Templates

private readonly TyceBasePageItem _TyceBasePageItem;
public TyceBasePageItem TyceBasePage { get { return _TyceBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TyceOverviewPageItem(Item innerItem) : base(innerItem)
{
	_TyceBasePageItem = new TyceBasePageItem(innerItem);

}

public static implicit operator TyceOverviewPageItem(Item innerItem)
{
	return innerItem != null ? new TyceOverviewPageItem(innerItem) : null;
}

public static implicit operator Item(TyceOverviewPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ChildSelectionBoxTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Selection Box Title"]);
	}
}


public CustomTextField SimulationListingTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Simulation Listing Title"]);
	}
}


public CustomTextField ChildSelectionBoxAbstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Selection Box Abstract"]);
	}
}


public CustomTextField SimulationListingAbstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Simulation Listing Abstract"]);
	}
}


public CustomTextField ChildSelectionModalTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Selection Modal Title"]);
	}
}


#endregion //Field Instance Methods
}
}