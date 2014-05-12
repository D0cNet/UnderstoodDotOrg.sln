using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages
{
public partial class BehaviorToolsAdvicePageItem : CustomItem
{

public static readonly string TemplateId = "{85EB1AD3-E599-4C32-A796-5242BC4619F6}";

#region Inherited Base Templates

private readonly BehaviorAdvicePageItem _BehaviorAdvicePageItem;
public BehaviorAdvicePageItem BehaviorAdvicePage { get { return _BehaviorAdvicePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorToolsAdvicePageItem(Item innerItem) : base(innerItem)
{
	_BehaviorAdvicePageItem = new BehaviorAdvicePageItem(innerItem);

}

public static implicit operator BehaviorToolsAdvicePageItem(Item innerItem)
{
	return innerItem != null ? new BehaviorToolsAdvicePageItem(innerItem) : null;
}

public static implicit operator Item(BehaviorToolsAdvicePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WhatYouCanDo
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["What You Can Do"]);
	}
}


public CustomTextField WhatYouCanSay
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["What You Can Say"]);
	}
}


public CustomTextField WhyThisWillHelp
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Why This Will Help"]);
	}
}


#endregion //Field Instance Methods
}
}