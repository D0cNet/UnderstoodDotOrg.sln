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
public partial class TakeActionPageItem : CustomItem
{

public static readonly string TemplateId = "{C49E2DC6-F4E1-4060-886C-8CBDFE710BEA}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TakeActionPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator TakeActionPageItem(Item innerItem)
{
	return innerItem != null ? new TakeActionPageItem(innerItem) : null;
}

public static implicit operator Item(TakeActionPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CampaignSectionHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Campaign Section Headline"]);
	}
}


public CustomTextField FeaturedsectionHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured section Headline"]);
	}
}


public CustomTreeListField ArticlestoShow
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Articles to Show"]);
	}
}


public CustomTreeListField CompaignstoShow
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Compaigns to Show"]);
	}
}


public CustomTextField RelatedLinkHeaderTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Link Header Title"]);
	}
}


public CustomTreeListField RelatedLink
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Link"]);
	}
}


public CustomCheckboxField HideRelatedActiveLinks
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Related Active Links"]);
	}
}


public CustomLookupField PromotionalContent
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Promotional Content"]);
	}
}


#endregion //Field Instance Methods
}
}