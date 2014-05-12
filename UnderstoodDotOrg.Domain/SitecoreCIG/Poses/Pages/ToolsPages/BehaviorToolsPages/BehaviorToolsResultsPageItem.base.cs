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
public partial class BehaviorToolsResultsPageItem : CustomItem
{

public static readonly string TemplateId = "{B07AABF9-7B8A-4079-BF15-AF6B3D088C64}";

#region Inherited Base Templates

private readonly CSSTemplateItem _CSSTemplateItem;
public CSSTemplateItem CSSTemplate { get { return _CSSTemplateItem; } }
private readonly JSTemplateItem _JSTemplateItem;
public JSTemplateItem JSTemplate { get { return _JSTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorToolsResultsPageItem(Item innerItem) : base(innerItem)
{
	_CSSTemplateItem = new CSSTemplateItem(innerItem);
	_JSTemplateItem = new JSTemplateItem(innerItem);

}

public static implicit operator BehaviorToolsResultsPageItem(Item innerItem)
{
	return innerItem != null ? new BehaviorToolsResultsPageItem(innerItem) : null;
}

public static implicit operator Item(BehaviorToolsResultsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}