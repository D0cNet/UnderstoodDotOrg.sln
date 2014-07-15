using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class MyAccountItem : CustomItem
{

public static readonly string TemplateId = "{B4A23529-E97F-4C7C-BC7B-AE9F841E85ED}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyAccountItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator MyAccountItem(Item innerItem)
{
	return innerItem != null ? new MyAccountItem(innerItem) : null;
}

public static implicit operator Item(MyAccountItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField UpcomingEventsLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Upcoming Events Link Text"]);
	}
}


public CustomTextField UpcomingEventsHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Upcoming Events Header Text"]);
	}
}


public CustomTextField MyGroupsHeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["My Groups Header Text"]);
	}
}


public CustomTextField SeeAllGroupsLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See All Groups Link Text"]);
	}
}


public CustomTextField CompleteProfileText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Complete Profile Text"]);
	}
}


public CustomGeneralLinkField CompleteProfileLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Complete Profile Link"]);
	}
}


public CustomTextField NoGroupsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Groups Text"]);
	}
}


public CustomGeneralLinkField NoGroupsLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["No Groups Link"]);
	}
}


public CustomTextField NoFavoritesText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Favorites Text"]);
	}
}


public CustomTextField MyFavoritesText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["My Favorites Text"]);
	}
}


public CustomTextField SeeAllFavoritesText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See All Favorites Text"]);
	}
}


public CustomTextField NoCommentsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Comments Text"]);
	}
}


public CustomTextField SeeAllCommentsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See All Comments Text"]);
	}
}


public CustomTextField SeeAllConnectionsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See All Connections Text"]);
	}
}


public CustomTextField ConnectionsSeeActivityButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Connections See Activity Button Text"]);
	}
}


public CustomTextField ConnectionsSeeProfileButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Connections See Profile Button Text"]);
	}
}


public CustomTextField SeeAllNotificationsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["See All Notifications Text"]);
	}
}


public CustomTextField NotificationsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Notifications Text"]);
	}
}


public CustomTextField MyNotifications
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["My Notifications"]);
	}
}


#endregion //Field Instance Methods
}
}