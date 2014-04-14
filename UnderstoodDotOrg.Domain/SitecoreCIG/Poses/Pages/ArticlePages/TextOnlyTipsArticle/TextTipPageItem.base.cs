using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle
{
public partial class TextTipPageItem : CustomItem
{

public static readonly string TemplateId = "{F70B81A5-1FD4-4345-BBDE-BE68F255170D}";


#region Boilerplate CustomItem Code

public TextTipPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TextTipPageItem(Item innerItem)
{
	return innerItem != null ? new TextTipPageItem(innerItem) : null;
}

public static implicit operator Item(TextTipPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Tiptitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tip title"]);
	}
}


public CustomTextField Tiptext
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tip text"]);
	}
}


public CustomMultiListField Backgroundcolor
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Background color"]);
	}
}


public CustomCheckboxField ShowasEndSlide
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show as End Slide"]);
	}
}


#endregion //Field Instance Methods
}
}