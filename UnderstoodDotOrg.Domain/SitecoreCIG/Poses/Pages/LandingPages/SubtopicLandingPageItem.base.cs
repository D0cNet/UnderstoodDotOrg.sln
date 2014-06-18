using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
public partial class SubtopicLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{14713049-6A36-4B6D-9003-35F7F179985F}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SubtopicLandingPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator SubtopicLandingPageItem(Item innerItem)
{
	return innerItem != null ? new SubtopicLandingPageItem(innerItem) : null;
}

public static implicit operator Item(SubtopicLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField Widgets
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Widgets"]);
	}
}


#endregion //Field Instance Methods
}
}