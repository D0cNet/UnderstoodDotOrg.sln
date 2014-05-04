using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class ArticleLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{46633158-7245-4D3D-A9A4-59AE6348AF7F}";


#region Boilerplate CustomItem Code

public ArticleLandingPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArticleLandingPageItem(Item innerItem)
{
	return innerItem != null ? new ArticleLandingPageItem(innerItem) : null;
}

public static implicit operator Item(ArticleLandingPageItem customItem)
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


public CustomTextField IntroductionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["IntroductionText"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


#endregion //Field Instance Methods
}
}