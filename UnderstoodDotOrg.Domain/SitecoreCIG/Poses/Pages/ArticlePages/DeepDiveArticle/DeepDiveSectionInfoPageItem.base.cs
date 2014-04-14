using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle
{
public partial class DeepDiveSectionInfoPageItem : CustomItem
{

public static readonly string TemplateId = "{728E1CA2-955E-4D58-8331-F764910A6225}";


#region Boilerplate CustomItem Code

public DeepDiveSectionInfoPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DeepDiveSectionInfoPageItem(Item innerItem)
{
	return innerItem != null ? new DeepDiveSectionInfoPageItem(innerItem) : null;
}

public static implicit operator Item(DeepDiveSectionInfoPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField SubTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["SubTitle"]);
	}
}


public CustomTextField Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content"]);
	}
}


#endregion //Field Instance Methods
}
}