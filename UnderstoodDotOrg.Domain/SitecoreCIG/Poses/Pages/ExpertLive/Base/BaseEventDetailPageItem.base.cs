using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base
{
public partial class BaseEventDetailPageItem : CustomItem
{

public static readonly string TemplateId = "{89B1A2C1-3520-42D4-A528-15009E9B5201}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BaseEventDetailPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator BaseEventDetailPageItem(Item innerItem)
{
	return innerItem != null ? new BaseEventDetailPageItem(innerItem) : null;
}

public static implicit operator Item(BaseEventDetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EventSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Subheading"]);
	}
}


public CustomTextField EventHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Heading"]);
	}
}


public CustomLookupField Expert
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Expert"]);
	}
}


public CustomLookupField EventTimezone
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Event Timezone"]);
	}
}


public CustomDateField EventDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Event Date"]);
	}
}


public CustomTreeListField ChildIssue
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Issue"]);
	}
}


public CustomTreeListField Grade
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Grade"]);
	}
}


public CustomTreeListField ParentInterest
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Parent Interest"]);
	}
}


public CustomGeneralLinkField RSVPforEvent
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["RSVP for Event"]);
	}
}


#endregion //Field Instance Methods
}
}