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
public partial class PDFToolkitResourceItem : CustomItem
{

public static readonly string TemplateId = "{01533FF8-8564-423B-BA85-117827B24095}";


#region Boilerplate CustomItem Code

public PDFToolkitResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PDFToolkitResourceItem(Item innerItem)
{
	return innerItem != null ? new PDFToolkitResourceItem(innerItem) : null;
}

public static implicit operator Item(PDFToolkitResourceItem customItem)
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