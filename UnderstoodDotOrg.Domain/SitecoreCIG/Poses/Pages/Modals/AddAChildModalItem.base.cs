using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Modals
{
public partial class AddAChildModalItem : CustomItem
{

public static readonly string TemplateId = "{83A39A6E-699B-48D4-868C-2B67D6FAA886}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AddAChildModalItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AddAChildModalItem(Item innerItem)
{
	return innerItem != null ? new AddAChildModalItem(innerItem) : null;
}

public static implicit operator Item(AddAChildModalItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for Child Struggling Question Title


public CustomTextField BoyButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Boy Button Text"]);
	}
}


public CustomTextField ChildNicknameQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Child Nickname Question Title"]);
	}
}


public CustomTextField FormallyEvaluatedQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Formally Evaluated Question Title"]);
	}
}


public CustomTextField IEPQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Question Title"]);
	}
}


public CustomTextField NextButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Next Button Text"]);
	}
}


public CustomTextField Section504PlanQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Plan Question Title"]);
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


public CustomTextField GirlButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Girl Button Text"]);
	}
}


public CustomTextField IEPOptionDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option Default"]);
	}
}


public CustomTextField SCArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 1"]);
	}
}


public CustomTextField Section504OptionDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option Default"]);
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


public CustomTextField IEPMousoverText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Mousover Text"]);
	}
}


public CustomTextField IEPOption1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 1"]);
	}
}


public CustomTextField InText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["In Text"]);
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


public CustomTextField Section504MouseoverText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Mouseover Text"]);
	}
}


public CustomTextField TAArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 2"]);
	}
}


public CustomTextField IEPOption2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 2"]);
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


public CustomTextField Section504MouseoverTextTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Mouseover Text Title"]);
	}
}


public CustomTextField SelectGradeFieldDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field Default"]);
	}
}


public CustomTextField TAArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 3"]);
	}
}


public CustomTextField IEPOption3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 3"]);
	}
}


public CustomTextField SCArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SC Area 4"]);
	}
}


public CustomTextField Section504Option1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 1"]);
	}
}


public CustomTextField SelectGradeField1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 1"]);
	}
}


public CustomTextField TAArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 4"]);
	}
}


public CustomTextField IEPOption4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 4"]);
	}
}


public CustomTextField Section504Option2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 2"]);
	}
}


public CustomTextField SelectGradeField2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 2"]);
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


public CustomTextField IEPOption5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 5"]);
	}
}


public CustomTextField Section504Option3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 3"]);
	}
}


public CustomTextField SelectGradeField3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 3"]);
	}
}


public CustomTextField TAArea6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 6"]);
	}
}


public CustomTextField IEPMousoverTextTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Mousover Text Title"]);
	}
}


public CustomTextField Section504Option4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 4"]);
	}
}


public CustomTextField SelectGradeField4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 4"]);
	}
}


public CustomTextField TAArea7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 7"]);
	}
}


public CustomTextField SelectGradeField5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 5"]);
	}
}


public CustomTextField TAArea8
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 8"]);
	}
}


public CustomTextField SelectGradeField6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 6"]);
	}
}


public CustomTextField TAArea9
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 9"]);
	}
}


public CustomTextField SelectGradeField7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 7"]);
	}
}


public CustomTextField TAArea10
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TA Area 10"]);
	}
}


public CustomTextField SelectGradeField8
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 8"]);
	}
}


public CustomTextField SelectGradeField9
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 9"]);
	}
}


public CustomTextField SelectGradeField10
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 10"]);
	}
}


public CustomTextField SelectGradeField11
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 11"]);
	}
}


public CustomTextField SelectGradeField12
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 12"]);
	}
}


#endregion //Field Instance Methods
}
}