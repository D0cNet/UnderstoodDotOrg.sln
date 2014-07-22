using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Tools.BehaviorTool
{
public partial class BehaviorSearchCalloutItem : CustomItem
{

public static readonly string TemplateId = "{C76DADCF-9E0C-4C95-89A0-998AB90E3508}";


#region Boilerplate CustomItem Code

public BehaviorSearchCalloutItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BehaviorSearchCalloutItem(Item innerItem)
{
	return innerItem != null ? new BehaviorSearchCalloutItem(innerItem) : null;
}

public static implicit operator Item(BehaviorSearchCalloutItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CalloutTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Callout Title"]);
	}
}


public CustomTextField SuccessTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Success Title"]);
	}
}


public CustomTextField SuggestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Suggestion Title"]);
	}
}


public CustomTextField CalloutSuggestionsLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Callout Suggestions Link Text"]);
	}
}


public CustomTextField SuccessText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Success Text"]);
	}
}


public CustomTextField SuggestionInstructions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Suggestion Instructions"]);
	}
}


public CustomTextField CalloutChallengeRequiredFieldMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Callout Challenge Required Field Message"]);
	}
}


public CustomTextField SuccessSignUpText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Success Sign-Up Text"]);
	}
}


public CustomTextField SuggestionEmailAddress
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Suggestion E-mail Address"]);
	}
}


public CustomTextField CalloutGradeRequiredFieldMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Callout Grade Required Field Message"]);
	}
}


public CustomTextField SuggestionRequiredFieldMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Suggestion Required Field Message"]);
	}
}


public CustomMultiListField CalloutGradeChoices
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Callout Grade Choices"]);
	}
}


public CustomTextField SuggestionSubmitFailedMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Suggestion Submit Failed Message"]);
	}
}


#endregion //Field Instance Methods
}
}