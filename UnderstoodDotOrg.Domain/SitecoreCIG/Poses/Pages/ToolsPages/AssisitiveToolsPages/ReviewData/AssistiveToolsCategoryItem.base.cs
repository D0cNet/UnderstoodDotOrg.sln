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
public partial class AssistiveToolsCategoryItem : CustomItem
{

public static readonly string TemplateId = "{8D19AF89-0EE6-4524-8E6F-8A7842AAFB7C}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsCategoryItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsCategoryItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsCategoryItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsCategoryItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}