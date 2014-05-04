using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class AboutPartnersItem : CustomItem
{

public static readonly string TemplateId = "{0A2C1F1E-3104-4C12-BB9F-2A245542200F}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutPartnersItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AboutPartnersItem(Item innerItem)
{
	return innerItem != null ? new AboutPartnersItem(innerItem) : null;
}

public static implicit operator Item(AboutPartnersItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PartnerListHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Headline"]);
	}
}


public CustomTextField PartnerPageHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Page Headline"]);
	}
}


public CustomTextField PartnerListSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Summary"]);
	}
}


public CustomTextField PartnerPageSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Page Summary"]);
	}
}


#endregion //Field Instance Methods
}
}