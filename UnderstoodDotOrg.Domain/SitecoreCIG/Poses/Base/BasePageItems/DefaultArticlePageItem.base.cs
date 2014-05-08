using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
public partial class DefaultArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{2D5AF94C-1668-44C4-978A-E96E1F42CBFE}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public DefaultArticlePageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator DefaultArticlePageItem(Item innerItem)
{
	return innerItem != null ? new DefaultArticlePageItem(innerItem) : null;
}

public static implicit operator Item(DefaultArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomDateField DateStart
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date Start"]);
	}
}


public CustomTreeListField ImportanceLevel
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Importance Level"]);
	}
}


public CustomTreeListField ApplicablePersonalities
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Applicable Personalities"]);
	}
}


public CustomLookupField AuthorName
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Author Name"]);
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


public CustomDateField DateEnd
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date End"]);
	}
}


public CustomTreeListField OverrideType
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Override Type"]);
	}
}


public CustomTextField RelatedLinkHeaderTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Link Header Title"]);
	}
}


public CustomTreeListField ChildDiagnoses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Diagnoses"]);
	}
}


public CustomTreeListField OtherApplicableEvaluations
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Other Applicable Evaluations"]);
	}
}


public CustomTreeListField RelatedLink
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Link"]);
	}
}


public CustomLookupField Reviewedby
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Reviewed by"]);
	}
}


public CustomTreeListField DiagnosedCondition
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Diagnosed Condition"]);
	}
}


public CustomCheckboxField HideRelatedActiveLinks
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Related Active Links"]);
	}
}


public CustomDateField ReviewedDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Reviewed Date"]);
	}
}


public CustomImageField FeaturedImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Featured Image"]);
	}
}


public CustomTextField BlogId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["BlogId"]);
	}
}


public CustomTextField BlogPostId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["BlogPostId"]);
	}
}


public CustomTextField ContentId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ContentId"]);
	}
}


#endregion //Field Instance Methods
}
}