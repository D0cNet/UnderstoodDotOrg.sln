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
public partial class LiveChatEventPageItem : CustomItem
{

public static readonly string TemplateId = "{C6F85C8E-66B4-4240-8522-38BB406ACBF7}";

#region Inherited Base Templates

private readonly BaseEventDetailPageItem _BaseEventDetailPageItem;
public BaseEventDetailPageItem BaseEventDetailPage { get { return _BaseEventDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public LiveChatEventPageItem(Item innerItem) : base(innerItem)
{
	_BaseEventDetailPageItem = new BaseEventDetailPageItem(innerItem);

}

public static implicit operator LiveChatEventPageItem(Item innerItem)
{
	return innerItem != null ? new LiveChatEventPageItem(innerItem) : null;
}

public static implicit operator Item(LiveChatEventPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}