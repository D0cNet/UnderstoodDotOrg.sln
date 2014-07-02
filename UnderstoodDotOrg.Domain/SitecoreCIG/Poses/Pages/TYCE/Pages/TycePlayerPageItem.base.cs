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
public partial class TycePlayerPageItem : CustomItem
{

public static readonly string TemplateId = "{EF1DF541-354B-4420-9BC0-57437B902331}";

#region Inherited Base Templates

private readonly TyceBasePageItem _TyceBasePageItem;
public TyceBasePageItem TyceBasePage { get { return _TyceBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TycePlayerPageItem(Item innerItem) : base(innerItem)
{
	_TyceBasePageItem = new TyceBasePageItem(innerItem);

}

public static implicit operator TycePlayerPageItem(Item innerItem)
{
	return innerItem != null ? new TycePlayerPageItem(innerItem) : null;
}

public static implicit operator Item(TycePlayerPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HowThisWorksTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["How This Works Title"]);
	}
}


public CustomTextField MenuText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Menu Text"]);
	}
}


public CustomTextField StepOneText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Step One Text"]);
	}
}


public CustomTextField ExperienceChildsWorldText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Experience Childs World Text"]);
	}
}


public CustomTextField HowThisWorksBody
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["How This Works Body"]);
	}
}


public CustomTextField StepTwoText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Step Two Text"]);
	}
}


public CustomTextField CaptionsBubbleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Captions Bubble Text"]);
	}
}


public CustomTextField PersonalizedForChildText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personalized For Child Text"]);
	}
}


public CustomTextField StepThreeText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Step Three Text"]);
	}
}


public CustomTextField HelpText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Help Text"]);
	}
}


public CustomTextField VolumeBubbleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Volume Bubble Text"]);
	}
}


public CustomImageField HeaderLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Logo"]);
	}
}


public CustomTextField ProgressBubbleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Progress Bubble Text"]);
	}
}


public CustomTextField SkipBubbleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Skip Bubble Text"]);
	}
}


public CustomTextField BeforeYouBeginTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Before You Begin Title"]);
	}
}


public CustomTextField BeforeYouBeginContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Before You Begin Content"]);
	}
}


public CustomTextField YourDoneModalHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Your Done Modal Header Text"]);
	}
}


public CustomTextField YourDoneModalContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Your Done Modal Content"]);
	}
}


public CustomTextField YourDoneModalLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Your Done Modal Link Text"]);
	}
}


#endregion //Field Instance Methods
}
}