using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
public partial class AssistiveToolsLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{B4D53C88-10D9-4AAE-A23B-1FA7B5987EC9}";

#region Inherited Base Templates

private readonly AssistiveToolsBasePageItem _AssistiveToolsBasePageItem;
public AssistiveToolsBasePageItem AssistiveToolsBasePage { get { return _AssistiveToolsBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsLandingPageItem(Item innerItem) : base(innerItem)
{
	_AssistiveToolsBasePageItem = new AssistiveToolsBasePageItem(innerItem);

}

public static implicit operator AssistiveToolsLandingPageItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsLandingPageItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Hero
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Hero"]);
	}
}


#endregion //Field Instance Methods
}
}