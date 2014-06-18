using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets
{
public partial class ImageWidgetItem : CustomItem
{

public static readonly string TemplateId = "{BF370BAF-A2D3-4049-8B6A-663AA737A0E4}";


#region Boilerplate CustomItem Code

public ImageWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ImageWidgetItem(Item innerItem)
{
	return innerItem != null ? new ImageWidgetItem(innerItem) : null;
}

public static implicit operator Item(ImageWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WidgetImage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Image"]);
	}
}


public CustomGeneralLinkField WidgetLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Widget Link"]);
	}
}


#endregion //Field Instance Methods
}
}