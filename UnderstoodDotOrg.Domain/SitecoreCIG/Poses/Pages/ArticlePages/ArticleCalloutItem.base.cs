using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class ArticleCalloutItem : CustomItem
{

public static readonly string TemplateId = "{F65A1443-FC27-4E7B-A3B2-4A18BB557AA3}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public ArticleCalloutItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator ArticleCalloutItem(Item innerItem)
{
	return innerItem != null ? new ArticleCalloutItem(innerItem) : null;
}

public static implicit operator Item(ArticleCalloutItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ContentDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content Description"]);
	}
}


#endregion //Field Instance Methods
}
}