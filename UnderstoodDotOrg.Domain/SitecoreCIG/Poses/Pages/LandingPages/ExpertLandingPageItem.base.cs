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
public partial class ExpertLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{B5C6DFF1-8BED-42F2-9313-C829DDDA426A}";


#region Boilerplate CustomItem Code

public ExpertLandingPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ExpertLandingPageItem(Item innerItem)
{
	return innerItem != null ? new ExpertLandingPageItem(innerItem) : null;
}

public static implicit operator Item(ExpertLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}