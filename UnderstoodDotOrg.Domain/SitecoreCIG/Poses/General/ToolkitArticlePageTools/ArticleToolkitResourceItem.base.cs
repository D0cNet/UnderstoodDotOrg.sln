using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.ToolkitArticlePageTools
{
public partial class ArticleToolkitResourceItem : CustomItem
{

public static readonly string TemplateId = "{814C5092-484C-4544-8D02-E6FAFB582E23}";


#region Boilerplate CustomItem Code

public ArticleToolkitResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArticleToolkitResourceItem(Item innerItem)
{
	return innerItem != null ? new ArticleToolkitResourceItem(innerItem) : null;
}

public static implicit operator Item(ArticleToolkitResourceItem customItem)
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


public CustomTextField ActionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Action Text"]);
	}
}


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


#endregion //Field Instance Methods
}
}