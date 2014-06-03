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
public partial class ExpertsLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{D05ECA63-49ED-40BD-91E4-3B70851C34E4}";

#region Inherited Base Templates

private readonly AboutSectionPageItem _AboutSectionPageItem;
public AboutSectionPageItem AboutSectionPage { get { return _AboutSectionPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExpertsLandingPageItem(Item innerItem) : base(innerItem)
{
	_AboutSectionPageItem = new AboutSectionPageItem(innerItem);

}

public static implicit operator ExpertsLandingPageItem(Item innerItem)
{
	return innerItem != null ? new ExpertsLandingPageItem(innerItem) : null;
}

public static implicit operator Item(ExpertsLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}