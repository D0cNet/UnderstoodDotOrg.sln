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
public partial class ChatEventPageItem : CustomItem
{

public static readonly string TemplateId = "{F5D0D610-9E5B-4C28-B9D3-F6ADD8412E45}";

#region Inherited Base Templates

private readonly BaseEventDetailPageItem _BaseEventDetailPageItem;
public BaseEventDetailPageItem BaseEventDetailPage { get { return _BaseEventDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChatEventPageItem(Item innerItem) : base(innerItem)
{
	_BaseEventDetailPageItem = new BaseEventDetailPageItem(innerItem);

}

public static implicit operator ChatEventPageItem(Item innerItem)
{
	return innerItem != null ? new ChatEventPageItem(innerItem) : null;
}

public static implicit operator Item(ChatEventPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField OpenOfficeHour
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Open Office Hour"]);
	}
}


#endregion //Field Instance Methods
}
}