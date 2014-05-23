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
public partial class AdvocacyLinkItem : CustomItem
{

public static readonly string TemplateId = "{842117FB-FBD4-4BD0-889E-02DD8210E3A8}";


#region Boilerplate CustomItem Code

public AdvocacyLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AdvocacyLinkItem(Item innerItem)
{
	return innerItem != null ? new AdvocacyLinkItem(innerItem) : null;
}

public static implicit operator Item(AdvocacyLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Heading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Heading"]);
	}
}


public CustomTextField Abstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Abstract"]);
	}
}


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


public CustomTextField ActNowButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Act Now Button Text"]);
	}
}


#endregion //Field Instance Methods
}
}