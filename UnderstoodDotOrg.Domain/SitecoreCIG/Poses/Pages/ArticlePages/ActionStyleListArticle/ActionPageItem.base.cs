using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ActionStyleListArticle
{
public partial class ActionPageItem : CustomItem
{

public static readonly string TemplateId = "{951C32F2-2201-4BD2-B7C8-C542E550663F}";


#region Boilerplate CustomItem Code

public ActionPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ActionPageItem(Item innerItem)
{
	return innerItem != null ? new ActionPageItem(innerItem) : null;
}

public static implicit operator Item(ActionPageItem customItem)
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


public CustomTextField Introduction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Introduction"]);
	}
}


//public CustomIntegerField ActionNumber
//{
//    get
//    {
//        return new CustomIntegerField(InnerItem, InnerItem.Fields["Action Number"]);
//    }
//}


#endregion //Field Instance Methods
}
}