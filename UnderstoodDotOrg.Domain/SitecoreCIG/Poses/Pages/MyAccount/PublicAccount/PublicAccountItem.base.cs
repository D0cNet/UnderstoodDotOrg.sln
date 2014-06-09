using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount
{
public partial class PublicAccountItem : CustomItem
{

public static readonly string TemplateId = "{28EE7BE8-6672-4443-B2EB-CDD5D4C7AE3A}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public PublicAccountItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator PublicAccountItem(Item innerItem)
{
	return innerItem != null ? new PublicAccountItem(innerItem) : null;
}

public static implicit operator Item(PublicAccountItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}