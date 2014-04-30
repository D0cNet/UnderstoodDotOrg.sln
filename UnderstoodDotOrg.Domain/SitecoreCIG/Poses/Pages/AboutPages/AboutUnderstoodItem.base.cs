using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class AboutUnderstoodItem : CustomItem
{

public static readonly string TemplateId = "{BD10EB3B-54F6-462A-882D-B99C7628C7A9}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutUnderstoodItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AboutUnderstoodItem(Item innerItem)
{
	return innerItem != null ? new AboutUnderstoodItem(innerItem) : null;
}

public static implicit operator Item(AboutUnderstoodItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomFileField VideotoShow
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Video to Show"]);
	}
}


public CustomTextField ExpertPartnerHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Partner Headline"]);
	}
}


public CustomTextField MissionHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Mission Headline"]);
	}
}


public CustomTextField PartnerListHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Headline"]);
	}
}


public CustomTextField StoryHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Story Headline"]);
	}
}


public CustomTextField TeamHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Team Headline"]);
	}
}


public CustomTextField ExpertPartnerSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Partner Summary"]);
	}
}


public CustomTextField MissionSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Mission Summary"]);
	}
}


public CustomTextField PartnerListSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Summary"]);
	}
}


public CustomTextField StorySummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Story Summary"]);
	}
}


public CustomTextField TeamSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Team Summary"]);
	}
}


public CustomTextField VideoTranscript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Transcript"]);
	}
}


public CustomImageField MissionThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Mission Thumbnail"]);
	}
}


public CustomImageField ExpertPartnerThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Expert Partner Thumbnail"]);
	}
}


//Could not find Field Type for Link to Partner List Page


public CustomImageField StoryThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Story Thumbnail"]);
	}
}


public CustomImageField TeamThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Team Thumbnail"]);
	}
}


public CustomTreeListField PartnersContent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Partners Content"]);
	}
}

public CustomGeneralLinkField LinktoPartnersPage
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Partner List page Link"]);
    }

}


#endregion //Field Instance Methods
}
}