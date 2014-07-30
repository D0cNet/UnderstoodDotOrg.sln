using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Generic.Common
{
public partial class StateItem : CustomItem
{

public static readonly string TemplateId = "{AAFA91D0-8EA0-4553-8855-37C61A95EF7A}";


#region Boilerplate CustomItem Code

public StateItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator StateItem(Item innerItem)
{
	return innerItem != null ? new StateItem(innerItem) : null;
}

public static implicit operator Item(StateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField StateCode
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["State Code"]);
	}
}


#endregion //Field Instance Methods
}
}