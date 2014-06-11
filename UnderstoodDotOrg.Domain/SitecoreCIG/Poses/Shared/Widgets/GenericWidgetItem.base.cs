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
public partial class GenericWidgetItem : CustomItem
{

public static readonly string TemplateId = "{0E6E0B09-EAE3-4084-8599-5A183ABB9A9E}";


#region Boilerplate CustomItem Code

public GenericWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator GenericWidgetItem(Item innerItem)
{
	return innerItem != null ? new GenericWidgetItem(innerItem) : null;
}

public static implicit operator Item(GenericWidgetItem customItem)
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


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


#endregion //Field Instance Methods
}
}