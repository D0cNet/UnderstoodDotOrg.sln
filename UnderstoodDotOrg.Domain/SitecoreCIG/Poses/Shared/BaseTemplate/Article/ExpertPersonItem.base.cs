using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article
{
public partial class ExpertPersonItem : CustomItem
{

public static readonly string TemplateId = "{0A6E0FC9-7CB2-4E64-AF58-A38B6B3C1CFD}";


#region Boilerplate CustomItem Code

public ExpertPersonItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ExpertPersonItem(Item innerItem)
{
	return innerItem != null ? new ExpertPersonItem(innerItem) : null;
}

public static implicit operator Item(ExpertPersonItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FullName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Full Name"]);
	}
}


public CustomTextField Biodata
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Biodata"]);
	}
}


public CustomImageField Photo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Photo"]);
	}
}


public CustomTextField TitleandInstitution
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title and Institution"]);
	}
}


public CustomTreeListField Participation
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Participation"]);
	}
}


public CustomGeneralLinkField TwitterLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Twitter Link"]);
	}
}


public CustomCheckboxField ShowBioPage
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Bio Page"]);
	}
}


public CustomGeneralLinkField BlogPageLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Blog Page Link"]);
	}
}


#endregion //Field Instance Methods
}
}