using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.NewsLetter
{
public partial class Newsletter_ParentInterestItem : CustomItem
{

public static readonly string TemplateId = "{8311D4F3-F460-4733-AB9C-8C820B92BA25}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public Newsletter_ParentInterestItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator Newsletter_ParentInterestItem(Item innerItem)
{
	return innerItem != null ? new Newsletter_ParentInterestItem(innerItem) : null;
}

public static implicit operator Item(Newsletter_ParentInterestItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField NextpagetoShow
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Next page to Show"]);
	}
}


#endregion //Field Instance Methods
}
}