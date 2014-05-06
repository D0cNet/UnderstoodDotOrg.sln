using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.JS
{
public partial class JSItem : CustomItem
{

public static readonly string TemplateId = "{3A4ABE14-D054-4E21-92AE-6FCFBDE06C38}";


#region Boilerplate CustomItem Code

public JSItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator JSItem(Item innerItem)
{
	return innerItem != null ? new JSItem(innerItem) : null;
}

public static implicit operator Item(JSItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField JSFilename
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["JSFilename"]);
	}
}


public CustomTextField JSFilepath
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["JSFilepath"]);
	}
}


#endregion //Field Instance Methods
}
}