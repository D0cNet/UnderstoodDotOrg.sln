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
public partial class PastWebinarEventPageItem : CustomItem
{

public static readonly string TemplateId = "{9F7129FF-6008-4A48-B0CB-D46D6847F5FA}";

#region Inherited Base Templates

private readonly BaseEventDetailPageItem _BaseEventDetailPageItem;
public BaseEventDetailPageItem BaseEventDetailPage { get { return _BaseEventDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PastWebinarEventPageItem(Item innerItem) : base(innerItem)
{
	_BaseEventDetailPageItem = new BaseEventDetailPageItem(innerItem);

}

public static implicit operator PastWebinarEventPageItem(Item innerItem)
{
	return innerItem != null ? new PastWebinarEventPageItem(innerItem) : null;
}

public static implicit operator Item(PastWebinarEventPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}