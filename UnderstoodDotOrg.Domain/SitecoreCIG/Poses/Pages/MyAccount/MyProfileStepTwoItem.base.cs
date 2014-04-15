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
public partial class MyProfileStepTwoItem : CustomItem
{

public static readonly string TemplateId = "{53902C3C-01DF-47C7-8A78-E2A47379F542}";

#region Inherited Base Templates

private readonly MyProfileBaseTemplateItem _MyProfileBaseTemplateItem;
public MyProfileBaseTemplateItem MyProfileBaseTemplate { get { return _MyProfileBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileStepTwoItem(Item innerItem) : base(innerItem)
{
	_MyProfileBaseTemplateItem = new MyProfileBaseTemplateItem(innerItem);

}

public static implicit operator MyProfileStepTwoItem(Item innerItem)
{
	return innerItem != null ? new MyProfileStepTwoItem(innerItem) : null;
}

public static implicit operator Item(MyProfileStepTwoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ChildNicknameQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Nickname Question Title"]);
	}
}


public CustomTextField FormTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Form Title"]);
	}
}


public CustomTextField FormallyEvaluatedQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Formally Evaluated Question Title"]);
	}
}


public CustomTextField NextButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Next Button Text"]);
	}
}


public CustomTextField SpecialCircumstancesQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Special Circumstances Question Title"]);
	}
}


public CustomTextField TroubleAreasQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Trouble Areas Question Title"]);
	}
}


public CustomTextField ChildNicknameQuestionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Nickname Question Text"]);
	}
}


public CustomTextField SCArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 1"]);
	}
}


public CustomTextField TAArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 1"]);
	}
}


public CustomTextField YesButton
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Yes Button"]);
	}
}


public CustomTextField NoButton
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Button"]);
	}
}


public CustomTextField SCArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 2"]);
	}
}


public CustomTextField TAArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 2"]);
	}
}


public CustomTextField InProgressButton
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["In Progress Button"]);
	}
}


public CustomTextField SCArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 3"]);
	}
}


public CustomTextField TAArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 3"]);
	}
}


public CustomTextField SCArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 4"]);
	}
}


public CustomTextField TAArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 4"]);
	}
}


public CustomTextField SpecialCircumstancesQuestionSubText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Special Circumstances Question SubText"]);
	}
}


public CustomTextField TAArea5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 5"]);
	}
}


public CustomTextField TAArea6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 6"]);
	}
}


public CustomTextField TAArea7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 7"]);
	}
}


public CustomTextField TAArea8
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 8"]);
	}
}


public CustomTextField TAArea9
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 9"]);
	}
}


public CustomTextField TAArea10
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 10"]);
	}
}


#endregion //Field Instance Methods
}
}