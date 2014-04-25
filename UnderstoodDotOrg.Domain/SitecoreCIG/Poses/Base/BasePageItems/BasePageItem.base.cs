using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
public partial class BasePageItem : CustomItem
{

public static readonly string TemplateId = "{DE701142-DD24-4B9B-9FDA-ACA2B0BCDA92}";


#region Boilerplate CustomItem Code

public BasePageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BasePageItem(Item innerItem)
{
	return innerItem != null ? new BasePageItem(innerItem) : null;
}

public static implicit operator Item(BasePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for Author Name


//Could not find Field Type for Reviewed By


public CustomImageField ContentThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Content Thumbnail"]);
	}
}


//Could not find Field Type for Primary Categorization


public CustomTreeListField RelatedLink
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Link"]);
	}
}


//Could not find Field Type for Secondary Categorization


public CustomCheckboxField RelatedActiveLink
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Related Active Link"]);
	}
}


//Could not find Field Type for Tertiary Categorization


public CustomDateField Reviewedon
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Reviewed on"]);
	}
}


public CustomTextField HeadlineText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Headline Text"]);
	}
}


public CustomTextField SubHeadlineText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sub Headline Text"]);
	}
}


#endregion //Field Instance Methods
}
}