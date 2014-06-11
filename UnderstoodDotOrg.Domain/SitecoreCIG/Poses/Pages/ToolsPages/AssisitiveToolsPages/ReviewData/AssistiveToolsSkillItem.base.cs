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
public partial class AssistiveToolsSkillItem : CustomItem
{

public static readonly string TemplateId = "{211B59F7-A96A-4158-94B5-DB027F07D1DF}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsSkillItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsSkillItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsSkillItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsSkillItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}