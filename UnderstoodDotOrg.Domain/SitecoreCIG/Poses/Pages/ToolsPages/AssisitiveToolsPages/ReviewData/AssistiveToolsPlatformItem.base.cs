using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData
{
public partial class AssistiveToolsPlatformItem : CustomItem
{

public static readonly string TemplateId = "{22A923A1-13C0-4093-ABEC-1A9959DAE0E8}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsPlatformItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsPlatformItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsPlatformItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsPlatformItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField CorrespondingType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Corresponding Type"]);
	}
}


#endregion //Field Instance Methods
}
}