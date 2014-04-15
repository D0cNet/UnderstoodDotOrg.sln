using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class MyProfileStepFourItem : CustomItem
{

public static readonly string TemplateId = "{9C3E62C8-0987-48C1-8FC7-09D6F55300B7}";

#region Inherited Base Templates

private readonly MyProfileBaseTemplateItem _MyProfileBaseTemplateItem;
public MyProfileBaseTemplateItem MyProfileBaseTemplate { get { return _MyProfileBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileStepFourItem(Item innerItem) : base(innerItem)
{
	_MyProfileBaseTemplateItem = new MyProfileBaseTemplateItem(innerItem);

}

public static implicit operator MyProfileStepFourItem(Item innerItem)
{
	return innerItem != null ? new MyProfileStepFourItem(innerItem) : null;
}

public static implicit operator Item(MyProfileStepFourItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ConnectQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Connect Question Title"]);
	}
}


public CustomTextField FormTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Form Title"]);
	}
}


public CustomTextField GrowingUpQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Growing Up Question Title"]);
	}
}


public CustomTextField HomeLifeQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Home Life Question Title"]);
	}
}


public CustomTextField SchoolIssuesQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["School Issues Question Title"]);
	}
}


public CustomTextField SocialEmotionalIssuesQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Social Emotional Issues Question Title"]);
	}
}


public CustomTextField SubmitButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Submit Button Text"]);
	}
}


public CustomTextField WaysToHelpQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Ways To Help Question Title"]);
	}
}


public CustomTextField WhatIsYourRoleQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["What Is Your Role Question Title"]);
	}
}


public CustomTextField WhereAreYouQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Where Are You Question Title"]);
	}
}


public CustomTextField ConnectQuestionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Connect Question Text"]);
	}
}


public CustomTextField GUArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GU Area 1"]);
	}
}


public CustomTextField HLArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["HL Area 1"]);
	}
}


public CustomTextField MomButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Mom Button Text"]);
	}
}


public CustomTextField SEIArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SEI Area 1"]);
	}
}


public CustomTextField SIArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 1"]);
	}
}


public CustomTextField WAYArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WAY Area 1"]);
	}
}


public CustomTextField WTHArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WTH Area 1"]);
	}
}


public CustomTextField DadButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Dad Button Text"]);
	}
}


public CustomTextField GUArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GU Area 2"]);
	}
}


public CustomTextField HLArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["HL Area 2"]);
	}
}


public CustomTextField ScreenNameWatermark
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Screen Name Watermark"]);
	}
}


public CustomTextField SEIArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SEI Area 2"]);
	}
}


public CustomTextField SIArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 2"]);
	}
}


public CustomTextField WAYArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WAY Area 2"]);
	}
}


public CustomTextField WTHArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WTH Area 2"]);
	}
}


public CustomTextField GUArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GU Area 3"]);
	}
}


public CustomTextField HLArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["HL Area 3"]);
	}
}


public CustomTextField OtherFieldDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field Default"]);
	}
}


public CustomTextField SEIArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SEI Area 3"]);
	}
}


public CustomTextField SIArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 3"]);
	}
}


public CustomTextField WAYArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WAY Area 3"]);
	}
}


public CustomTextField WTHArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WTH Area 3"]);
	}
}


public CustomTextField ZipCodeWatermark
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Zip Code Watermark"]);
	}
}


public CustomTextField GUArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GU Area 4"]);
	}
}


public CustomTextField HLArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["HL Area 4"]);
	}
}


public CustomTextField OtherField1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 1"]);
	}
}


public CustomTextField SIArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 4"]);
	}
}


public CustomTextField WhyDoWeAskText1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Text 1"]);
	}
}


public CustomTextField WTHArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WTH Area 4"]);
	}
}


public CustomTextField WhyDoWeAskSubtextHeader1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Subtext Header 1"]);
	}
}


public CustomTextField GUArea5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["GU Area 5"]);
	}
}


public CustomTextField OtherField2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 2"]);
	}
}


public CustomTextField SIArea5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 5"]);
	}
}


public CustomTextField WhyDoWeAskSubtext1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Subtext 1"]);
	}
}


public CustomTextField WTHArea5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WTH Area 5"]);
	}
}


public CustomTextField OtherField3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 3"]);
	}
}


public CustomTextField SIArea6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 6"]);
	}
}


public CustomTextField WhyDoWeAskText2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Text 2"]);
	}
}


public CustomTextField WhyDoWeAskSubtextHeader2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Subtext Header 2"]);
	}
}


public CustomTextField OtherField4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 4"]);
	}
}


public CustomTextField SIArea7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 7"]);
	}
}


public CustomTextField WhyDoWeAskSubtext2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why Do We Ask Subtext 2"]);
	}
}


public CustomTextField InterestText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Interest Text"]);
	}
}


public CustomTextField OtherField5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 5"]);
	}
}


public CustomTextField SIArea8
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SI Area 8"]);
	}
}


public CustomTextField OtherField6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Field 6"]);
	}
}


public CustomTextField PersonalizedNewsletterText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personalized Newsletter Text"]);
	}
}


#endregion //Field Instance Methods
}
}