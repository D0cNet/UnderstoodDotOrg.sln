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
public partial class CSSTemplateItem : CustomItem
{

public static readonly string TemplateId = "{A4E26C01-046B-4EC1-AAB8-C26C3FEE4910}";


#region Boilerplate CustomItem Code

public CSSTemplateItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator CSSTemplateItem(Item innerItem)
{
	return innerItem != null ? new CSSTemplateItem(innerItem) : null;
}

public static implicit operator Item(CSSTemplateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField CSSInclude
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["CSSInclude"]);
	}
}


#endregion //Field Instance Methods
}
}