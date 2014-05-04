using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
public partial class ContentPageItem : CustomItem
{

public static readonly string TemplateId = "{0D6484DE-2E24-438E-A220-DFCE839E48E9}";

#region Inherited Base Templates

private readonly BasePageNEWItem _BasePageNEWItem;
public BasePageNEWItem BasePageNEW { get { return _BasePageNEWItem; } }

#endregion

#region Boilerplate CustomItem Code

public ContentPageItem(Item innerItem) : base(innerItem)
{
	_BasePageNEWItem = new BasePageNEWItem(innerItem);

}

public static implicit operator ContentPageItem(Item innerItem)
{
	return innerItem != null ? new ContentPageItem(innerItem) : null;
}

public static implicit operator Item(ContentPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField SectionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section Title"]);
	}
}


public CustomTextField PageTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Title"]);
	}
}


public CustomTextField PageSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Summary"]);
	}
}


public CustomTextField BodyContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body Content"]);
	}
}


#endregion //Field Instance Methods
}
}