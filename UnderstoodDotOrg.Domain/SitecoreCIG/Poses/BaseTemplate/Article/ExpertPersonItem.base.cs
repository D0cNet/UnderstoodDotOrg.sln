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


public CustomTextField ExpertName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Name"]);
	}
}


public CustomTextField ExpertBiodata
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Biodata"]);
	}
}


public CustomImageField ExpertImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Expert Image"]);
	}
}


public CustomTextField ExpertTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Expert Title"]);
	}
}


#endregion //Field Instance Methods
}
}