using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class PromoItem : CustomItem
{

public static readonly string TemplateId = "{667D0991-EAE8-43EA-A1A9-52716195EFC1}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PromoItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator PromoItem(Item innerItem)
{
	return innerItem != null ? new PromoItem(innerItem) : null;
}

public static implicit operator Item(PromoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField PromoURL
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Promo URL"]);
	}
}


public CustomCheckboxField IncludeinPromoTool
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in PromoTool"]);
	}
}


public CustomImageField PromoImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Promo Image"]);
	}
}


public CustomFileField MediaFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Media File"]);
	}
}


public CustomCheckboxField ShowMediaFile
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Media File"]);
	}
}


#endregion //Field Instance Methods
}
}