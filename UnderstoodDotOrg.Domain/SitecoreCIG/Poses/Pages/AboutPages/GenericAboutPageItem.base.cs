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
public partial class GenericAboutPageItem : CustomItem
{

public static readonly string TemplateId = "{3633C04C-CCF2-49BF-9CE9-5015910E5EFA}";

#region Inherited Base Templates

private readonly AboutSectionPageItem _AboutSectionPageItem;
public AboutSectionPageItem AboutSectionPage { get { return _AboutSectionPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GenericAboutPageItem(Item innerItem) : base(innerItem)
{
	_AboutSectionPageItem = new AboutSectionPageItem(innerItem);

}

public static implicit operator GenericAboutPageItem(Item innerItem)
{
	return innerItem != null ? new GenericAboutPageItem(innerItem) : null;
}

public static implicit operator Item(GenericAboutPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}