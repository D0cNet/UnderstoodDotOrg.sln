using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base
{
public partial class ToolWidgetItem : CustomItem
{

public static readonly string TemplateId = "{AFA7DCDB-ECFA-4031-82E3-D6DC65068DBB}";


#region Boilerplate CustomItem Code

public ToolWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ToolWidgetItem(Item innerItem)
{
	return innerItem != null ? new ToolWidgetItem(innerItem) : null;
}

public static implicit operator Item(ToolWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField WidgetTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Title"]);
	}
}


public CustomTextField WidgetCopy
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Copy"]);
	}
}


public CustomTextField WidgetButtonText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Button Text"]);
	}
}


public CustomTextField WidgetFooterHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Widget Footer Heading"]);
	}
}


public CustomImageField WidgetFooterLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Widget Footer Logo"]);
	}
}


public CustomGeneralLinkField WidgetButtonLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Widget Button Link"]);
	}
}


#endregion //Field Instance Methods
}
}