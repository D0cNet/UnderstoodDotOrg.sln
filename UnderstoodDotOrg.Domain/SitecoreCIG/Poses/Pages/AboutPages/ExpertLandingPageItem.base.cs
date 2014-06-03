using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class ExpertLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{B5C6DFF1-8BED-42F2-9313-C829DDDA426A}";

#region Inherited Base Templates

private readonly AboutSectionPageItem _AboutSectionPageItem;
public AboutSectionPageItem AboutSectionPage { get { return _AboutSectionPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExpertLandingPageItem(Item innerItem) : base(innerItem)
{
	_AboutSectionPageItem = new AboutSectionPageItem(innerItem);

}

public static implicit operator ExpertLandingPageItem(Item innerItem)
{
	return innerItem != null ? new ExpertLandingPageItem(innerItem) : null;
}

public static implicit operator Item(ExpertLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EventCarouselHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Carousel Heading"]);
	}
}


public CustomTextField ExpertListHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert List Heading"]);
	}
}


#endregion //Field Instance Methods
}
}