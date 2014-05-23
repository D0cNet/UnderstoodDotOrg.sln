using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class AdvocacyBasePageItem : CustomItem
{

public static readonly string TemplateId = "{0ADDC41E-EA9D-499E-93E1-6033459BB099}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdvocacyBasePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AdvocacyBasePageItem(Item innerItem)
{
	return innerItem != null ? new AdvocacyBasePageItem(innerItem) : null;
}

public static implicit operator Item(AdvocacyBasePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField PoweredbyLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Powered by Logo"]);
	}
}


public CustomGeneralLinkField PoweredbyLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Powered by Link"]);
	}
}


#endregion //Field Instance Methods
}
}