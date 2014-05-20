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
public partial class MyAccountBaseItem : CustomItem
{

public static readonly string TemplateId = "{4EB619B6-938B-4EFE-AF4B-E9FCB71852BD}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyAccountBaseItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator MyAccountBaseItem(Item innerItem)
{
	return innerItem != null ? new MyAccountBaseItem(innerItem) : null;
}

public static implicit operator Item(MyAccountBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AccountNavigationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Account Navigation Title"]);
	}
}


public CustomTextField IconCssClass
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Icon CssClass"]);
	}
}


#endregion //Field Instance Methods
}
}