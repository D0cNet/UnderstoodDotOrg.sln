using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class SearchFilterTypeItem : CustomItem
{

public static readonly string TemplateId = "{1D2050F5-01A1-41C0-8CA9-236A99B43BB2}";


#region Boilerplate CustomItem Code

public SearchFilterTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SearchFilterTypeItem(Item innerItem)
{
	return innerItem != null ? new SearchFilterTypeItem(innerItem) : null;
}

public static implicit operator Item(SearchFilterTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FilterLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Filter Label"]);
	}
}


public CustomTreeListField TemplateTypes
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Template Types"]);
	}
}


#endregion //Field Instance Methods
}
}