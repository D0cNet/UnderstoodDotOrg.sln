using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class EmailandAlertPreferencesPageItem : CustomItem
{

public static readonly string TemplateId = "{FBF1A447-51CC-41C8-853F-3ED75FC323A3}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public EmailandAlertPreferencesPageItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator EmailandAlertPreferencesPageItem(Item innerItem)
{
	return innerItem != null ? new EmailandAlertPreferencesPageItem(innerItem) : null;
}

public static implicit operator Item(EmailandAlertPreferencesPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WeeklyPersonalizedNewsletter
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Weekly Personalized Newsletter"]);
	}
}


public CustomTextField NotificationsDigest
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Notifications Digest"]);
	}
}


public CustomTextField SupportPlanReminders
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Support Plan Reminders"]);
	}
}


public CustomTextField ObservationLogReminders
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Observation Log Reminders"]);
	}
}


public CustomTextField EventReminders
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Reminders"]);
	}
}


public CustomTextField ContentReminders
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content Reminders"]);
	}
}


public CustomTextField AdvocacyAlerts
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Advocacy Alerts"]);
	}
}


public CustomTextField PrivateMessageAlerts
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Private Message Alerts"]);
	}
}


public CustomTextField Daily
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Daily"]);
	}
}


public CustomTextField Weekly
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Weekly"]);
	}
}


#endregion //Field Instance Methods
}
}