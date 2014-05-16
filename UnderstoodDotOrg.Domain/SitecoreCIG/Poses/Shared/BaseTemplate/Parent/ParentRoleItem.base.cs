using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent
{
public partial class ParentRoleItem : CustomItem
{

public static readonly string TemplateId = "{79DFBAD6-53E9-45F6-AC69-EE66B2C0F1E0}";


#region Boilerplate CustomItem Code

public ParentRoleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ParentRoleItem(Item innerItem)
{
	return innerItem != null ? new ParentRoleItem(innerItem) : null;
}

public static implicit operator Item(ParentRoleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField RoleName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Role Name"]);
	}
}


#endregion //Field Instance Methods
}
}