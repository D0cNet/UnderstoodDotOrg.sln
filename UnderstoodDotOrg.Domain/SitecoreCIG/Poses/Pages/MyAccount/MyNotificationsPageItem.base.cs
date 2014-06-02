using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class MyNotificationsPageItem : CustomItem
{

public static readonly string TemplateId = "{A1C45ACB-824D-4FDE-86AB-ACABDBE2749B}";

#region Inherited Base Templates

private readonly BasePageNEWItem _BasePageNEWItem;
public BasePageNEWItem BasePageNEW { get { return _BasePageNEWItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyNotificationsPageItem(Item innerItem) : base(innerItem)
{
	_BasePageNEWItem = new BasePageNEWItem(innerItem);

}

public static implicit operator MyNotificationsPageItem(Item innerItem)
{
	return innerItem != null ? new MyNotificationsPageItem(innerItem) : null;
}

public static implicit operator Item(MyNotificationsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}