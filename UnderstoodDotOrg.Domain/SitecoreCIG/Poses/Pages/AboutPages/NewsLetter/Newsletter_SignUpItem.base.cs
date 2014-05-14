using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.NewsLetter
{
public partial class Newsletter_SignUpItem : CustomItem
{

public static readonly string TemplateId = "{0FE31FBA-0C5D-494C-ADBA-22F7FB1C311C}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public Newsletter_SignUpItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator Newsletter_SignUpItem(Item innerItem)
{
	return innerItem != null ? new Newsletter_SignUpItem(innerItem) : null;
}

public static implicit operator Item(Newsletter_SignUpItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField NextpagetoShow
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Next page to Show"]);
	}
}


public CustomTextField SecureDataTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Secure Data Title"]);
	}
}


public CustomTextField SecureDataDetails
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Secure Data Details"]);
	}
}


public CustomGeneralLinkField LinktoPrivacyPage
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Privacy Page"]);
	}
}


#endregion //Field Instance Methods
}
}