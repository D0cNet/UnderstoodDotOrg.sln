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
public partial class MyProfileStepOneItem : CustomItem
{

public static readonly string TemplateId = "{52E8305A-043E-4B1B-BDDA-BA809A9BD99D}";

#region Inherited Base Templates

private readonly MyProfileBaseTemplateItem _MyProfileBaseTemplateItem;
public MyProfileBaseTemplateItem MyProfileBaseTemplate { get { return _MyProfileBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileStepOneItem(Item innerItem) : base(innerItem)
{
	_MyProfileBaseTemplateItem = new MyProfileBaseTemplateItem(innerItem);

}

public static implicit operator MyProfileStepOneItem(Item innerItem)
{
	return innerItem != null ? new MyProfileStepOneItem(innerItem) : null;
}

public static implicit operator Item(MyProfileStepOneItem customItem)
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


public CustomTextField FormTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Form Title"]);
	}
}


public CustomTextField MoreChildrenQuestionPart1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Children Question Part 1"]);
	}
}


public CustomTextField SiblingsQuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Siblings Question Title"]);
	}
}


public CustomTextField GirlButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Girl Button Text"]);
	}
}


public CustomTextField MoreChildrenQuestionPart2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Children Question Part 2"]);
	}
}


public CustomTextField SiblingsYesButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Siblings Yes Button Text"]);
	}
}


public CustomTextField InText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["In Text"]);
	}
}


public CustomTextField MoreChildrenYesButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Children Yes Button Text"]);
	}
}


public CustomTextField SiblingsNoButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Siblings No Button Text"]);
	}
}


public CustomTextField MoreChildrenNoButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Children No Button Text"]);
	}
}


public CustomTextField SelectGradeFieldDefault
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field Default"]);
	}
}


public CustomTextField SelectGradeField1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 1"]);
	}
}


public CustomTextField SelectGradeField2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 2"]);
	}
}


public CustomTextField SelectGradeField3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 3"]);
	}
}


public CustomTextField SelectGradeField4
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 4"]);
	}
}


public CustomTextField SelectGradeField5
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 5"]);
	}
}


public CustomTextField SelectGradeField6
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 6"]);
	}
}


public CustomTextField SelectGradeField7
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Select Grade Field 7"]);
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