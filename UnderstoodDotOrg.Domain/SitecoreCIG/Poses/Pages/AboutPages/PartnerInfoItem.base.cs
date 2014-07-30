using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class PartnerInfoItem : CustomItem
{

public static readonly string TemplateId = "{BA989DC5-33AD-4064-B4AA-48881FA52EC6}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PartnerInfoItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator PartnerInfoItem(Item innerItem)
{
	return innerItem != null ? new PartnerInfoItem(innerItem) : null;
}

public static implicit operator Item(PartnerInfoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FirstFeaturedItemTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Featured Item Title"]);
	}
}


public CustomTextField PartnerName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Name"]);
	}
}


public CustomTextField PartnerNewsletterHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Newsletter Heading"]);
	}
}


public CustomGeneralLinkField FirstFeaturedItemLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["First Featured Item Link"]);
	}
}


public CustomGeneralLinkField PartnerNewsletterLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Partner Newsletter Link"]);
	}
}


public CustomTextField PartnerTagline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Tagline"]);
	}
}


public CustomTextField PartnerDonationHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Donation Heading"]);
	}
}


public CustomTextField PartnerShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner Short Description"]);
	}
}


public CustomGeneralLinkField PartnerDonationLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Partner Donation Link"]);
	}
}


public CustomGeneralLinkField PartnerLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Partner Link"]);
	}
}


public CustomTextField SecondFeaturedItemTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Second Featured Item Title"]);
	}
}


public CustomGeneralLinkField SecondFeaturedItemLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Second Featured Item Link"]);
	}
}


public CustomImageField PartnerLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Partner Logo"]);
	}
}


public CustomTextField TwitterHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter Heading"]);
	}
}


public CustomTextField TwitterWidget
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter Widget"]);
	}
}


public CustomGeneralLinkField TwitterUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Twitter Url"]);
	}
}


public CustomTextField TwitterCallToAction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter Call To Action"]);
	}
}


public CustomTextField FacebookHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facebook Heading"]);
	}
}


public CustomTextField FacebookWidget
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facebook Widget"]);
	}
}


public CustomGeneralLinkField FacebookUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Facebook Url"]);
	}
}


public CustomTextField FacebookCallToAction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facebook Call To Action"]);
	}
}


#endregion //Field Instance Methods
}
}