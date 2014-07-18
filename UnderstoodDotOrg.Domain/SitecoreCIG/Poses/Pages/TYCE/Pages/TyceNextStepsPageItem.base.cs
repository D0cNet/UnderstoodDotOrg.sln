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
public partial class TyceNextStepsPageItem : CustomItem
{

public static readonly string TemplateId = "{0838A55A-5910-47C3-B0DC-8086BA892128}";

#region Inherited Base Templates

private readonly TyceBasePageItem _TyceBasePageItem;
public TyceBasePageItem TyceBasePage { get { return _TyceBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TyceNextStepsPageItem(Item innerItem) : base(innerItem)
{
	_TyceBasePageItem = new TyceBasePageItem(innerItem);

}

public static implicit operator TyceNextStepsPageItem(Item innerItem)
{
	return innerItem != null ? new TyceNextStepsPageItem(innerItem) : null;
}

public static implicit operator Item(TyceNextStepsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ExpertHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Header Text"]);
	}
}


public CustomTextField ExploreTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Explore Title"]);
	}
}


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomTextField PersonalizationBoxTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personalization Box Title"]);
	}
}


public CustomTextField ShareItTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Share It Title"]);
	}
}


public CustomTextField SpecialThanksHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Special Thanks Header"]);
	}
}


public CustomTextField TalkWithYouChildTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Talk With You Child Title"]);
	}
}


public CustomTextField ExpertContentText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Content Text"]);
	}
}


public CustomTextField ExploreContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Explore Content"]);
	}
}


public CustomTextField PersonalizationBoxAbstract
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personalization Box Abstract"]);
	}
}


public CustomMultiListField SchoolContributions
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["School Contributions"]);
	}
}


public CustomTextField ShareItContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Share It Content"]);
	}
}


public CustomTextField CreateProfileButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Create Profile Button Text"]);
	}
}


public CustomTextField PlaceholderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Placeholder Text"]);
	}
}


#endregion //Field Instance Methods
}
}