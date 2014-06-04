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
public partial class ExpertDetailPageItem : CustomItem
{

public static readonly string TemplateId = "{823079F3-60E9-4D8A-8357-2AA01D8BFF1D}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExpertDetailPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ExpertDetailPageItem(Item innerItem)
{
	return innerItem != null ? new ExpertDetailPageItem(innerItem) : null;
}

public static implicit operator Item(ExpertDetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField ExpertImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Expert Image"]);
	}
}


public CustomTextField ExpertName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Name"]);
	}
}


public CustomTextField ExpertHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Heading"]);
	}
}


public CustomTextField ExpertSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Subheading"]);
	}
}


public CustomCheckboxField IsGuest
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Is Guest"]);
	}
}


public CustomMultiListField EventParticipation
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Event Participation"]);
	}
}


public CustomGeneralLinkField TwitterLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Twitter Link"]);
	}
}


public CustomGeneralLinkField BlogLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Blog Link"]);
	}
}


public CustomTextField OnlineOfficeHours
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Online Office Hours"]);
	}
}


public CustomTextField ExpertEventsHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Events Heading"]);
	}
}


public CustomTextField ExpertBlogsHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Blogs Heading"]);
	}
}


#endregion //Field Instance Methods
}
}