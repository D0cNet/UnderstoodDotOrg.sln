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
public partial class AssistiveToolsGenreItem : CustomItem
{

public static readonly string TemplateId = "{9CB69965-9E93-4755-8571-CAD6A78F241E}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsGenreItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsGenreItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsGenreItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsGenreItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}