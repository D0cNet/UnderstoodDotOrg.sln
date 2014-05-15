using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
public partial class EventLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{4D6AF04D-EC7B-4103-B4E4-B0FB77EB3035}";


#region Boilerplate CustomItem Code

public EventLandingPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EventLandingPageItem(Item innerItem)
{
	return innerItem != null ? new EventLandingPageItem(innerItem) : null;
}

public static implicit operator Item(EventLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}