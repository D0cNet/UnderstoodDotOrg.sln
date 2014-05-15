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
public partial class PastChatEventPageItem : CustomItem
{

public static readonly string TemplateId = "{B4ED8A59-7EC3-40A9-A74B-5B83641A9714}";

#region Inherited Base Templates

private readonly BaseEventDetailPageItem _BaseEventDetailPageItem;
public BaseEventDetailPageItem BaseEventDetailPage { get { return _BaseEventDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PastChatEventPageItem(Item innerItem) : base(innerItem)
{
	_BaseEventDetailPageItem = new BaseEventDetailPageItem(innerItem);

}

public static implicit operator PastChatEventPageItem(Item innerItem)
{
	return innerItem != null ? new PastChatEventPageItem(innerItem) : null;
}

public static implicit operator Item(PastChatEventPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField LiveChat
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Live Chat"]);
	}
}


#endregion //Field Instance Methods
}
}