using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive
{
public partial class MonthlyEventsListViewItem : CustomItem
{

public static readonly string TemplateId = "{34B7AB9D-A0CF-43E6-8306-03A5EE99D455}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public MonthlyEventsListViewItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator MonthlyEventsListViewItem(Item innerItem)
{
	return innerItem != null ? new MonthlyEventsListViewItem(innerItem) : null;
}

public static implicit operator Item(MonthlyEventsListViewItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}