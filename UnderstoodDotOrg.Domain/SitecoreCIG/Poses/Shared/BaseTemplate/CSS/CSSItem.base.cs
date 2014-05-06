using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.CSS
{
public partial class CSSItem : CustomItem
{

public static readonly string TemplateId = "{27254023-51F7-4125-B776-B1C963F7C27A}";


#region Boilerplate CustomItem Code

public CSSItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator CSSItem(Item innerItem)
{
	return innerItem != null ? new CSSItem(innerItem) : null;
}

public static implicit operator Item(CSSItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CSSFilename
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CSSFilename"]);
	}
}


public CustomTextField CSSFilepath
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CSSFilepath"]);
	}
}


#endregion //Field Instance Methods
}
}