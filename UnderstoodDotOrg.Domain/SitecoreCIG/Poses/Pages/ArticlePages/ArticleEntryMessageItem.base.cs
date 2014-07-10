using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class ArticleEntryMessageItem : CustomItem
{

public static readonly string TemplateId = "{BF69BE3F-625E-4118-AE4A-9FA58AB1044D}";


#region Boilerplate CustomItem Code

public ArticleEntryMessageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArticleEntryMessageItem(Item innerItem)
{
	return innerItem != null ? new ArticleEntryMessageItem(innerItem) : null;
}

public static implicit operator Item(ArticleEntryMessageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content"]);
	}
}


public CustomTextField PersonalizeExperienceLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personalize Experience Label"]);
	}
}


public CustomTextField CloseButtonLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Close Button Label"]);
	}
}


public CustomTextField YesButtonLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Yes Button Label"]);
	}
}


public CustomTextField NoThanksButtonLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Thanks Button Label"]);
	}
}


public CustomTextField ChildNeedsHelpWithLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Needs Help With Label"]);
	}
}


public CustomTextField ChildIsEnrolledInLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Is Enrolled In Label"]);
	}
}


public CustomTextField MyChildsNameLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["My Childs Name Label"]);
	}
}


public CustomTextField ChildsNameIsPrivateText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Childs Name Is Private Text"]);
	}
}


public CustomTextField SubmitButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Submit Button Text"]);
	}
}


#endregion //Field Instance Methods
}
}