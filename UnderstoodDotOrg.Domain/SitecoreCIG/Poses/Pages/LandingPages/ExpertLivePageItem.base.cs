using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
public partial class ExpertLivePageItem : CustomItem
{

public static readonly string TemplateId = "{404156BF-A471-41EA-B926-9C11D06381EF}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExpertLivePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ExpertLivePageItem(Item innerItem)
{
	return innerItem != null ? new ExpertLivePageItem(innerItem) : null;
}

public static implicit operator Item(ExpertLivePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ArchiveHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Archive Heading"]);
	}
}


public CustomTextField ChatHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Chat Heading"]);
	}
}


public CustomTreeListField FeaturedEvent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Event"]);
	}
}

public CustomTreeListField FeaturedChat
{
    get
    {
        return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Chat"]);
    }
}

public CustomTextField LiveChatHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Live Chat Heading"]);
	}
}


public CustomTextField WebinarsHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Webinars Heading"]);
	}
}


public CustomTextField ArchiveSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Archive Subheading"]);
	}
}


public CustomTextField ChatSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Chat Subheading"]);
	}
}


public CustomTextField LiveChatSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Live Chat Subheading"]);
	}
}


public CustomTextField WebinarsSubheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Webinars Subheading"]);
	}
}


public CustomTextField NoArchiveMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Archive Message"]);
	}
}


public CustomTextField NoChatMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Chat Message"]);
	}
}


public CustomTextField NoWebinarsMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Webinars Message"]);
	}
}


#endregion //Field Instance Methods
}
}