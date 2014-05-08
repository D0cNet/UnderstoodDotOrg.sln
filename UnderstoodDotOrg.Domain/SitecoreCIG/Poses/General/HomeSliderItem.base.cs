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
public partial class HomeSliderItem : CustomItem
{

public static readonly string TemplateId = "{6E46C890-CE6E-4A3E-BF7A-6AA6F4010ED9}";


#region Boilerplate CustomItem Code

public HomeSliderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HomeSliderItem(Item innerItem)
{
	return innerItem != null ? new HomeSliderItem(innerItem) : null;
}

public static implicit operator Item(HomeSliderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField HeroImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Hero Image"]);
	}
}


public CustomTextField Text
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Text"]);
	}
}


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


public CustomTextField TextCss
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Text Css"]);
	}
}


#endregion //Field Instance Methods
}
}