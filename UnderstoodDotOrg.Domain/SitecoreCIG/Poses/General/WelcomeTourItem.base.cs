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
public partial class WelcomeTourItem : CustomItem
{

public static readonly string TemplateId = "{EC227F9B-50E6-4863-8529-E4E4D69DC636}";


#region Boilerplate CustomItem Code

public WelcomeTourItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WelcomeTourItem(Item innerItem)
{
	return innerItem != null ? new WelcomeTourItem(innerItem) : null;
}

public static implicit operator Item(WelcomeTourItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Detail
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Detail"]);
	}
}


public CustomGeneralLinkField JoinTheCommunityButton
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Join The Community Button"]);
	}
}


public CustomGeneralLinkField NotNow
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Not Now"]);
	}
}


public CustomImageField BackgroundImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Background Image"]);
	}
}


#endregion //Field Instance Methods
}
}