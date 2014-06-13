using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class ArticleTypeItem : CustomItem
{

public static readonly string TemplateId = "{BC179817-0438-4CE0-9F39-4ABC83FFBC8F}";


#region Boilerplate CustomItem Code

public ArticleTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArticleTypeItem(Item innerItem)
{
	return innerItem != null ? new ArticleTypeItem(innerItem) : null;
}

public static implicit operator Item(ArticleTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ArticleTypeName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Article Type Name"]);
	}
}


public CustomLookupField ArticleTypeTemplate
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Article Type Template"]);
	}
}


#endregion //Field Instance Methods
}
}