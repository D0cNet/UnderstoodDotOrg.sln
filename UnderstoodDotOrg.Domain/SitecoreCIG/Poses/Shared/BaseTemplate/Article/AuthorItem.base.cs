using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article
{
public partial class AuthorItem : CustomItem
{

public static readonly string TemplateId = "{3F153988-B0C9-4C5D-9234-D9ADC2A3D55A}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }
private readonly BasePageNEWItem _BasePageNEWItem;
public BasePageNEWItem BasePageNEW { get { return _BasePageNEWItem; } }

#endregion

#region Boilerplate CustomItem Code

public AuthorItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);
	_BasePageNEWItem = new BasePageNEWItem(innerItem);

}

public static implicit operator AuthorItem(Item innerItem)
{
	return innerItem != null ? new AuthorItem(innerItem) : null;
}

public static implicit operator Item(AuthorItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AuthorName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Author Name"]);
	}
}


public CustomTextField AuthorBiodata
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Author Biodata"]);
	}
}


public CustomImageField AuthorImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Author Image"]);
	}
}


public CustomTextField AuthorBioAbstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Author Bio Abstract"]);
	}
}


#endregion //Field Instance Methods
}
}