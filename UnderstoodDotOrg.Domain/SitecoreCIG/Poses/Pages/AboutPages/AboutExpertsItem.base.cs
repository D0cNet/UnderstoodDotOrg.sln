using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class AboutExpertsItem : CustomItem
{

public static readonly string TemplateId = "{ED82ED80-4C7B-4F05-853F-2C2D1A1B2D8A}";

#region Inherited Base Templates

private readonly AboutSectionPageItem _AboutSectionPageItem;
public AboutSectionPageItem AboutSectionPage { get { return _AboutSectionPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutExpertsItem(Item innerItem) : base(innerItem)
{
	_AboutSectionPageItem = new AboutSectionPageItem(innerItem);

}

public static implicit operator AboutExpertsItem(Item innerItem)
{
	return innerItem != null ? new AboutExpertsItem(innerItem) : null;
}

public static implicit operator Item(AboutExpertsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AboutExpertIntroduction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["About Expert Introduction"]);
	}
}


public CustomTextField ExpertsDetailsHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Experts Details Headline"]);
	}
}


#endregion //Field Instance Methods
}
}