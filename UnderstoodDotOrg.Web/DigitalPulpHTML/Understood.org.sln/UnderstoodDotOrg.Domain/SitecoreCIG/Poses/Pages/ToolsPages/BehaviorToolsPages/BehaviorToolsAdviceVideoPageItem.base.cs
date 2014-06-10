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
public partial class BehaviorToolsAdviceVideoPageItem : CustomItem
{

public static readonly string TemplateId = "{E43BB9A7-D1E9-46E5-8F82-A57D3D6BC7CB}";

#region Inherited Base Templates

private readonly BehaviorAdvicePageItem _BehaviorAdvicePageItem;
public BehaviorAdvicePageItem BehaviorAdvicePage { get { return _BehaviorAdvicePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorToolsAdviceVideoPageItem(Item innerItem) : base(innerItem)
{
	_BehaviorAdvicePageItem = new BehaviorAdvicePageItem(innerItem);

}

public static implicit operator BehaviorToolsAdviceVideoPageItem(Item innerItem)
{
	return innerItem != null ? new BehaviorToolsAdviceVideoPageItem(innerItem) : null;
}

public static implicit operator Item(BehaviorToolsAdviceVideoPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TipTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tip Title"]);
	}
}


public CustomTextField BrightcoveVideoURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Brightcove Video URL"]);
	}
}


#endregion //Field Instance Methods
}
}