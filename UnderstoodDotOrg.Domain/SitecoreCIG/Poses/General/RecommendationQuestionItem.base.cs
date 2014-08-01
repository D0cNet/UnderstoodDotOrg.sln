using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class RecommendationQuestionItem : CustomItem
{

public static readonly string TemplateId = "{18CB2403-2CF2-4BEB-A6F1-D5DD61613E36}";


#region Boilerplate CustomItem Code

public RecommendationQuestionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RecommendationQuestionItem(Item innerItem)
{
	return innerItem != null ? new RecommendationQuestionItem(innerItem) : null;
}

public static implicit operator Item(RecommendationQuestionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Question
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question"]);
	}
}


public CustomTextField QuestionHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Header"]);
	}
}


public CustomTextField WhyAreWeAskingHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Are We Asking Header"]);
	}
}


public CustomTextField WhyAreWeAskingContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Are We Asking Content"]);
	}
}


public CustomTextField ButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Button Text"]);
	}
}


#endregion //Field Instance Methods
}
}