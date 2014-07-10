using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
public partial class GradeLevelItem : CustomItem
{

public static readonly string TemplateId = "{8F66C22B-74C3-41C7-9250-78A84B80A114}";


#region Boilerplate CustomItem Code

public GradeLevelItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator GradeLevelItem(Item innerItem)
{
	return innerItem != null ? new GradeLevelItem(innerItem) : null;
}

public static implicit operator Item(GradeLevelItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomCheckboxField ExcludeFromWebsiteDisplay
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Exclude From Website Display"]);
	}
}


public CustomIntegerField GradeNumber
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Grade Number"]);
	}
}


public CustomTextField AbbreviatedGrade
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Abbreviated Grade"]);
	}
}


#endregion //Field Instance Methods
}
}