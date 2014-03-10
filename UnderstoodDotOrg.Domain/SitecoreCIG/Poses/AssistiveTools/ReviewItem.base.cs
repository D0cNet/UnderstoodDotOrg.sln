using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.AssistiveTools
{
public partial class ReviewItem : CustomItem
{

public static readonly string TemplateId = "{C9DFC576-7750-4A84-9A79-61F16585E64E}";


#region Boilerplate CustomItem Code

public ReviewItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ReviewItem(Item innerItem)
{
	return innerItem != null ? new ReviewItem(innerItem) : null;
}

public static implicit operator Item(ReviewItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AppleAppStoreID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Apple App Store ID"]);
	}
}


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


public CustomTreeListField Screenshots
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Screenshots"]);
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


public CustomTextField TargetGrade
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Target Grade"]);
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


public CustomTextField OnGrade
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["On Grade"]);
	}
}


public CustomTextField Summary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Summary"]);
	}
}


public CustomGeneralLinkField ExternalLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["External Link"]);
	}
}


public CustomTextField OffGrade
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Off Grade"]);
	}
}


public CustomImageField ThumbnailImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail Image"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomTextField Quality
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Quality"]);
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


public CustomTextField Learning
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Learning"]);
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


#endregion //Field Instance Methods
}
}