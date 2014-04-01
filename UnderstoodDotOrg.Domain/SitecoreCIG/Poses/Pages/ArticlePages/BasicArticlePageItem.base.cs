using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class BasicArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{67D1EA88-ECA0-4B4F-BA2A-AD2E83ED4FF0}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BasicArticlePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator BasicArticlePageItem(Item innerItem)
{
	return innerItem != null ? new BasicArticlePageItem(innerItem) : null;
}

public static implicit operator Item(BasicArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTreeListField ApplicableInterests
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Applicable Interests"]);
	}
}


public CustomTreeListField ChildIssues
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Issues"]);
	}
}


public CustomTreeListField ComplexityLevels
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Complexity Levels"]);
	}
}


public CustomImageField ContentThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Content Thumbnail"]);
	}
}


public CustomTreeListField ImportanceLevel
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Importance Level"]);
	}
}


public CustomTreeListField PrimaryCategorization
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Primary Categorization"]);
	}
}


public CustomTreeListField ApplicablePersonalities
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Applicable Personalities"]);
	}
}


public CustomTreeListField Categories
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Categories"]);
	}
}


public CustomTreeListField ChildGrades
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Grades"]);
	}
}


public CustomTextField KeyTakeawayTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaway Title"]);
	}
}


public CustomTreeListField OverrideType
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Override Type"]);
	}
}


public CustomTreeListField RelatedLink
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Link"]);
	}
}


public CustomTreeListField SecondaryCategorization
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Secondary Categorization"]);
	}
}


public CustomTextField Summary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Summary"]);
	}
}


public CustomLookupField AuthorName
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Author Name"]);
	}
}


public CustomTreeListField ChildDiagnoses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Diagnoses"]);
	}
}


public CustomTextField KeyTakeawayData
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Takeaway Data"]);
	}
}


public CustomTreeListField OtherApplicableEvaluations
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Other Applicable Evaluations"]);
	}
}


public CustomCheckboxField RelatedActiveLink
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Related Active Link"]);
	}
}


public CustomTreeListField TertiaryCategorization
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Tertiary Categorization"]);
	}
}


public CustomTreeListField DiagnosedCondition
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Diagnosed Condition"]);
	}
}


public CustomLookupField Reviewedby
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Reviewed by"]);
	}
}


public CustomDateField ReviewedDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Reviewed Date"]);
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