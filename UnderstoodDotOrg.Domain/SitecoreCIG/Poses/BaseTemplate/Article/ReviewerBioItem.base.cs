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
public partial class ReviewerBioItem : CustomItem
{

public static readonly string TemplateId = "{D7FAD5BB-9D8B-40F0-9FC1-9C242B746BC4}";


#region Boilerplate CustomItem Code

public ReviewerBioItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ReviewerBioItem(Item innerItem)
{
	return innerItem != null ? new ReviewerBioItem(innerItem) : null;
}

public static implicit operator Item(ReviewerBioItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField RevierwerName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Revierwer Name"]);
	}
}


public CustomTextField ReviewerBio
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Reviewer Bio"]);
	}
}


#endregion //Field Instance Methods
}
}