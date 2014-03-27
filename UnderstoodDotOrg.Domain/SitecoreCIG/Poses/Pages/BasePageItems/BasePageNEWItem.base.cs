using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems
{
public partial class BasePageNEWItem : CustomItem
{

public static readonly string TemplateId = "{B79E8EA0-5501-4C46-A002-033BEE6D209D}";


#region Boilerplate CustomItem Code

public BasePageNEWItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BasePageNEWItem(Item innerItem)
{
	return innerItem != null ? new BasePageNEWItem(innerItem) : null;
}

public static implicit operator Item(BasePageNEWItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField GoogleAnalytics
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Google Analytics"]);
	}
}


public CustomTextField IncludeInSitemap
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Include In Sitemap"]);
	}
}


public CustomTextField MetaTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Title"]);
	}
}


public CustomTextField NavigationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Title"]);
	}
}


public CustomCheckboxField IncludeinNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in Navigation"]);
	}
}


public CustomTextField MetaDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Description"]);
	}
}


public CustomTextField MetaKeywords
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Keywords"]);
	}
}


public CustomCheckboxField RobotsNoIndex
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Robots No Index"]);
	}
}


public CustomCheckboxField RobotsNoFollow
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Robots No Follow"]);
	}
}


#endregion //Field Instance Methods
}
}