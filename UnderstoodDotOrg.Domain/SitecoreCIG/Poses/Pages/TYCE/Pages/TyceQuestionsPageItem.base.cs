using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages
{
public partial class TyceQuestionsPageItem : CustomItem
{

public static readonly string TemplateId = "{E59866E4-3B6F-41F5-A70E-4E94C4106B45}";

#region Inherited Base Templates

private readonly TyceBasePageItem _TyceBasePageItem;
public TyceBasePageItem TyceBasePage { get { return _TyceBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TyceQuestionsPageItem(Item innerItem) : base(innerItem)
{
	_TyceBasePageItem = new TyceBasePageItem(innerItem);

}

public static implicit operator TyceQuestionsPageItem(Item innerItem)
{
	return innerItem != null ? new TyceQuestionsPageItem(innerItem) : null;
}

public static implicit operator Item(TyceQuestionsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField QuestionOneText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question One Text"]);
	}
}


public CustomTextField QuestionOneInstructions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question One Instructions"]);
	}
}


public CustomTextField QuestionOneAnswerText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question One Answer Text"]);
	}
}


public CustomTextField QuestionTwoText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Two Text"]);
	}
}


public CustomTextField QuestionTwoInstructions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Two Instructions"]);
	}
}


public CustomTextField QuestionTwoAnswerText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Two Answer Text"]);
	}
}


public CustomTextField GetStartedButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Get Started Button Text"]);
	}
}


public CustomTextField DontSeeChildHereText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Dont See Child Here Text"]);
	}
}


public CustomTextField WhyAreWeAskingText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Are We Asking Text"]);
	}
}


public CustomTextField OtherChallengesModalHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Challenges Modal Header Text"]);
	}
}


public CustomTextField OtherChallengesModalContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Challenges Modal Content"]);
	}
}


public CustomTextField AfterHighSchoolModalHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["After High School Modal Header Text"]);
	}
}


public CustomTextField AfterHighSchoolModalContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["After High School Modal Content"]);
	}
}


#endregion //Field Instance Methods
}
}