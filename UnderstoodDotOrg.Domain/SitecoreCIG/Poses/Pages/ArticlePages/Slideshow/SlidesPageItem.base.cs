using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Slideshow
{
public partial class SlidesPageItem : CustomItem
{

public static readonly string TemplateId = "{0C64D5E3-6136-414E-9A23-6699D18B35F1}";


#region Boilerplate CustomItem Code

public SlidesPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SlidesPageItem(Item innerItem)
{
	return innerItem != null ? new SlidesPageItem(innerItem) : null;
}

public static implicit operator Item(SlidesPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField SlideTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Slide Title"]);
	}
}


public CustomTextField SlideText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Slide Text"]);
	}
}


public CustomImageField SlideImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Slide Image"]);
	}
}


public CustomMultiListField SlideFormat
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Slide Format"]);
	}
}


#endregion //Field Instance Methods
}
}