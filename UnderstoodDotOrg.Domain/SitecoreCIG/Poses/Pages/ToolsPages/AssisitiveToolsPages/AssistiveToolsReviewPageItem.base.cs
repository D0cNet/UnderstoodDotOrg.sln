using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
public partial class AssistiveToolsReviewPageItem : CustomItem
{

public static readonly string TemplateId = "{C9DFC576-7750-4A84-9A79-61F16585E64E}";

#region Inherited Base Templates

private readonly AssistiveToolsBasePageItem _AssistiveToolsBasePageItem;
public AssistiveToolsBasePageItem AssistiveToolsBasePage { get { return _AssistiveToolsBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsReviewPageItem(Item innerItem) : base(innerItem)
{
	_AssistiveToolsBasePageItem = new AssistiveToolsBasePageItem(innerItem);

}

public static implicit operator AssistiveToolsReviewPageItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsReviewPageItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsReviewPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField Categories
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Categories"]);
	}
}


public CustomTreeListField Platforms
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Platforms"]);
	}
}


public CustomTreeListField Skills
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Skills"]);
	}
}


public CustomTreeListField Subjects
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Subjects"]);
	}
}


public CustomTextField AppleAppStoreID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Apple App Store ID"]);
	}
}


public CustomTreeListField Screenshots
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Screenshots"]);
	}
}


public CustomIntegerField TargetGrade
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Target Grade"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTreeListField Type
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Type"]);
	}
}


public CustomTreeListField Genre
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Genre"]);
	}
}


public CustomTextField GooglePlayStoreID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Google Play Store ID"]);
	}
}


public CustomIntegerField OnGrade
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["On Grade"]);
	}
}


public CustomTextField Summary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Summary"]);
	}
}


public CustomTextField Price
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Price"]);
	}
}


public CustomGeneralLinkField ExternalLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["External Link"]);
	}
}


public CustomTreeListField Issues
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Issues"]);
	}
}


public CustomIntegerField OffGrade
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Off Grade"]);
	}
}


public CustomImageField ThumbnailImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail Image"]);
	}
}


public CustomTextField WhatParentsNeedtoKnow
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["What Parents Need to Know"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomIntegerField Quality
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Quality"]);
	}
}


public CustomTextField TelligentID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Telligent ID"]);
	}
}


public CustomTextField CSMID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CSM ID"]);
	}
}


public CustomIntegerField Learning
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Learning"]);
	}
}


public CustomTextField WhatKidsCanLearn
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["What Kids Can Learn"]);
	}
}


public CustomTextField AnyGood
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Any Good"]);
	}
}


public CustomTextField HowParentsCanHelp
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["How Parents Can Help"]);
	}
}


public CustomDateField PublishDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Publish Date"]);
	}
}


#endregion //Field Instance Methods
}
}