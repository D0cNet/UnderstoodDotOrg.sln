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
public partial class MyProfileStepThreeItem : CustomItem
{

public static readonly string TemplateId = "{CB209295-AF31-4F5E-938B-469B86BA80C8}";

#region Inherited Base Templates

private readonly MyProfileBaseTemplateItem _MyProfileBaseTemplateItem;
public MyProfileBaseTemplateItem MyProfileBaseTemplate { get { return _MyProfileBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileStepThreeItem(Item innerItem) : base(innerItem)
{
	_MyProfileBaseTemplateItem = new MyProfileBaseTemplateItem(innerItem);

}

public static implicit operator MyProfileStepThreeItem(Item innerItem)
{
	return innerItem != null ? new MyProfileStepThreeItem(innerItem) : null;
}

public static implicit operator Item(MyProfileStepThreeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AttentionAndFocusQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Attention And Focus Question Title"]);
	}
}


public CustomTextField FormTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Form Title"]);
	}
}


public CustomTextField IEPQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Question Title"]);
	}
}


public CustomTextField LearningDisordersQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Learning Disorders Question Title"]);
	}
}


public CustomTextField NextButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Next Button Text"]);
	}
}


public CustomTextField OtherDisorderQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Other Disorder Question Title"]);
	}
}


public CustomTextField Section504PlanQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Plan Question Title"]);
	}
}


public CustomTextField AFArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["AF Area 1"]);
	}
}


public CustomTextField IEPOptionDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option Default"]);
	}
}


public CustomTextField LearningDisordersQuestionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Learning Disorders Question Text"]);
	}
}


public CustomTextField ODArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["OD Area 1"]);
	}
}


public CustomTextField Section504OptionDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option Default"]);
	}
}


public CustomTextField IEPMousoverText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Mousover Text"]);
	}
}


public CustomTextField AFArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["AF Area 2"]);
	}
}


public CustomTextField IEPOption1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 1"]);
	}
}


public CustomTextField LDArea1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 1"]);
	}
}


public CustomTextField Section504MouseoverText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Mouseover Text"]);
	}
}


public CustomTextField LDArea1MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 1 Mouse Over Title"]);
	}
}


public CustomTextField AFArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["AF Area 3"]);
	}
}


public CustomTextField IEPOption2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 2"]);
	}
}


public CustomTextField LDArea1MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 1 Mouse Over"]);
	}
}


public CustomTextField Section504MouseoverTextTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Mouseover Text Title"]);
	}
}


public CustomGeneralLinkField LDArea1Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 1 Hyperlink"]);
	}
}


public CustomTextField IEPOption3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 3"]);
	}
}


public CustomTextField LDArea2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 2"]);
	}
}


public CustomTextField Section504Option1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 1"]);
	}
}


public CustomTextField LDArea2MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 2 Mouse Over Title"]);
	}
}


public CustomTextField IEPOption4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 4"]);
	}
}


public CustomTextField LDArea2MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 2 Mouse Over"]);
	}
}


public CustomTextField Section504Option2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 2"]);
	}
}


public CustomGeneralLinkField LDArea2Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 2 Hyperlink"]);
	}
}


public CustomTextField IEPOption5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Option 5"]);
	}
}


public CustomTextField LDArea3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 3"]);
	}
}


public CustomTextField Section504Option3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 3"]);
	}
}


public CustomTextField LDArea3MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 3 Mouse Over Title"]);
	}
}


public CustomTextField IEPMousoverTextTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IEP Mousover Text Title"]);
	}
}


public CustomTextField LDArea3MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 3 Mouse Over"]);
	}
}


public CustomTextField Section504Option4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Section 504 Option 4"]);
	}
}


public CustomGeneralLinkField LDArea3Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 3 Hyperlink"]);
	}
}


public CustomTextField LDArea4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 4"]);
	}
}


public CustomTextField LDArea4MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 4 Mouse Over Title"]);
	}
}


public CustomTextField LDArea4MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 4 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea4Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 4 Hyperlink"]);
	}
}


public CustomTextField LDArea5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 5"]);
	}
}


public CustomTextField LDArea5MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 5 Mouse Over Title"]);
	}
}


public CustomTextField LDArea5MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 5 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea5Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 5 Hyperlink"]);
	}
}


public CustomTextField LDArea6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 6"]);
	}
}


public CustomTextField LDArea6MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 6 Mouse Over Title"]);
	}
}


public CustomTextField LDArea6MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 6 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea6Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 6 Hyperlink"]);
	}
}


public CustomTextField LDArea7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 7"]);
	}
}


public CustomTextField LDArea7MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 7 Mouse Over Title"]);
	}
}


public CustomTextField LDArea7MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 7 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea7Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 7 Hyperlink"]);
	}
}


public CustomTextField LDArea8
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 8"]);
	}
}


public CustomTextField LDArea8MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 8 Mouse Over Title"]);
	}
}


public CustomTextField LDArea8MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 8 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea8Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 8 Hyperlink"]);
	}
}


public CustomTextField LDArea9
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 9"]);
	}
}


public CustomTextField LDArea9MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 9 Mouse Over Title"]);
	}
}


public CustomTextField LDArea9MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 9 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea9Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 9 Hyperlink"]);
	}
}


public CustomTextField LDArea10
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 10"]);
	}
}


public CustomTextField LDArea10MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 10 Mouse Over Title"]);
	}
}


public CustomTextField LDArea10MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 10 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea10Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 10 Hyperlink"]);
	}
}


public CustomTextField LDArea11
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 11"]);
	}
}


public CustomTextField LDArea11MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 11 Mouse Over Title"]);
	}
}


public CustomTextField LDArea11MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 11 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea11Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 11 Hyperlink"]);
	}
}


public CustomTextField LDArea12
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 12"]);
	}
}


public CustomTextField LDArea12MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 12 Mouse Over Title"]);
	}
}


public CustomTextField LDArea12MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 12 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea12Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 12 Hyperlink"]);
	}
}


public CustomTextField LDArea13
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 13"]);
	}
}


public CustomTextField LDArea13MouseOverTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 13 Mouse Over Title"]);
	}
}


public CustomTextField LDArea13MouseOver
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["LD Area 13 Mouse Over"]);
	}
}


public CustomGeneralLinkField LDArea13Hyperlink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["LD Area 13 Hyperlink"]);
	}
}


#endregion //Field Instance Methods
}
}