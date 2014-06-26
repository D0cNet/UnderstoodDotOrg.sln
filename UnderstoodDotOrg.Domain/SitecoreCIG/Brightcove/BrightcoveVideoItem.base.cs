using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Brightcove;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Brightcove
{
public partial class BrightcoveVideoItem : CustomItem
{

public static readonly string TemplateId = "{6A5C6835-6E11-4602-A11D-B626E9255397}";

#region Inherited Base Templates

private readonly BrightcoveMediaElementItem _BrightcoveMediaElementItem;
public BrightcoveMediaElementItem BrightcoveMediaElement { get { return _BrightcoveMediaElementItem; } }

#endregion

#region Boilerplate CustomItem Code

public BrightcoveVideoItem(Item innerItem) : base(innerItem)
{
	_BrightcoveMediaElementItem = new BrightcoveMediaElementItem(innerItem);

}

public static implicit operator BrightcoveVideoItem(Item innerItem)
{
	return innerItem != null ? new BrightcoveVideoItem(innerItem) : null;
}

public static implicit operator Item(BrightcoveVideoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for CreationDate


public CustomTextField LongDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LongDescription"]);
	}
}


//Could not find Field Type for PublishedDate


//Could not find Field Type for LastModifiedDate


public CustomMultiListField Economics
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Economics"]);
	}
}


//Could not find Field Type for LinkURL


//Could not find Field Type for LinkText


public CustomMultiListField Tags
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Tags"]);
	}
}


//Could not find Field Type for VideoStillURL


//Could not find Field Type for Length


//Could not find Field Type for PlaysTotal


//Could not find Field Type for PlaysTrailingWeek


//Could not find Field Type for CustomFields


#endregion //Field Instance Methods
}
}