using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class AdvocacyLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{ED38E385-334E-498F-80F1-A2BB32DB8FE7}";

#region Inherited Base Templates

private readonly AdvocacyBasePageItem _AdvocacyBasePageItem;
public AdvocacyBasePageItem AdvocacyBasePage { get { return _AdvocacyBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdvocacyLandingPageItem(Item innerItem) : base(innerItem)
{
	_AdvocacyBasePageItem = new AdvocacyBasePageItem(innerItem);

}

public static implicit operator AdvocacyLandingPageItem(Item innerItem)
{
	return innerItem != null ? new AdvocacyLandingPageItem(innerItem) : null;
}

public static implicit operator Item(AdvocacyLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ActionAlertsHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Action Alerts Heading"]);
	}
}


public CustomTreeListField DisplayedActionAlerts
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Displayed Action Alerts"]);
	}
}


public CustomTextField FeaturedArticlesHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Articles Heading"]);
	}
}


public CustomTextField RelatedContentHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Content Heading"]);
	}
}


public CustomTextField SidebarActionAlertsSignupHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sidebar Action Alerts Signup Heading"]);
	}
}


public CustomImageField SidebarPromoImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Sidebar Promo Image"]);
	}
}


public CustomGeneralLinkField SidebarPromoLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Sidebar Promo Link"]);
	}
}


#endregion //Field Instance Methods
}
}