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
public partial class TopicLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{030C7DA9-8F36-459A-B7EE-990D0E89C766}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TopicLandingPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator TopicLandingPageItem(Item innerItem)
{
	return innerItem != null ? new TopicLandingPageItem(innerItem) : null;
}

public static implicit operator Item(TopicLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField EventWidget
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Event Widget"]);
	}
}


public CustomTreeListField GalleryFeaturedArticles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Gallery Featured Articles"]);
	}
}


public CustomTreeListField SectionFeaturedArticles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Section Featured Articles"]);
	}
}


public CustomTreeListField TopicFeaturedArticles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Topic Featured Articles"]);
	}
}


#endregion //Field Instance Methods
}
}