using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class SiteSettingsItem : CustomItem
{

public static readonly string TemplateId = "{643F5C27-886E-4A2A-820F-5A308980F596}";


#region Boilerplate CustomItem Code

public SiteSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SiteSettingsItem(Item innerItem)
{
	return innerItem != null ? new SiteSettingsItem(innerItem) : null;
}

public static implicit operator Item(SiteSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TellAFriendLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tell A Friend Label"]);
	}
}


public CustomGeneralLinkField Twitter
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Twitter"]);
	}
}


public CustomGeneralLinkField Facebook
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Facebook"]);
	}
}


#endregion //Field Instance Methods
}
}