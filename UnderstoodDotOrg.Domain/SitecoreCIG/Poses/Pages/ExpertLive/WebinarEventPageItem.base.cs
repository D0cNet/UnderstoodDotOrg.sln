using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive
{
public partial class WebinarEventPageItem : CustomItem
{

public static readonly string TemplateId = "{173A599B-2836-4A4B-B780-834DD515C701}";

#region Inherited Base Templates

private readonly BaseEventDetailPageItem _BaseEventDetailPageItem;
public BaseEventDetailPageItem BaseEventDetailPage { get { return _BaseEventDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public WebinarEventPageItem(Item innerItem) : base(innerItem)
{
	_BaseEventDetailPageItem = new BaseEventDetailPageItem(innerItem);

}

public static implicit operator WebinarEventPageItem(Item innerItem)
{
	return innerItem != null ? new WebinarEventPageItem(innerItem) : null;
}

public static implicit operator Item(WebinarEventPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}