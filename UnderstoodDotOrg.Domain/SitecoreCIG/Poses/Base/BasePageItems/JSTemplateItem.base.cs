using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
public partial class JSTemplateItem : CustomItem
{

public static readonly string TemplateId = "{9D8C4AD8-1C11-4960-BDE1-57D24083C9F0}";


#region Boilerplate CustomItem Code

public JSTemplateItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator JSTemplateItem(Item innerItem)
{
	return innerItem != null ? new JSTemplateItem(innerItem) : null;
}

public static implicit operator Item(JSTemplateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField JSInclude
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["JSInclude"]);
	}
}


#endregion //Field Instance Methods
}
}