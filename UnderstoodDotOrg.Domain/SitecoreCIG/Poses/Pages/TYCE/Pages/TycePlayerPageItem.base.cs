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
public partial class TycePlayerPageItem : CustomItem
{

public static readonly string TemplateId = "{EF1DF541-354B-4420-9BC0-57437B902331}";

#region Inherited Base Templates

private readonly TyceBasePageItem _TyceBasePageItem;
public TyceBasePageItem TyceBasePage { get { return _TyceBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TycePlayerPageItem(Item innerItem) : base(innerItem)
{
	_TyceBasePageItem = new TyceBasePageItem(innerItem);

}

public static implicit operator TycePlayerPageItem(Item innerItem)
{
	return innerItem != null ? new TycePlayerPageItem(innerItem) : null;
}

public static implicit operator Item(TycePlayerPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}