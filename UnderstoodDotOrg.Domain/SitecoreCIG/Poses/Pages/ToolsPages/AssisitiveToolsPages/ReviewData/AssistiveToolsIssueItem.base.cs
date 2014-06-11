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
public partial class AssistiveToolsIssueItem : CustomItem
{

public static readonly string TemplateId = "{80ACE318-1C8F-4E91-9C36-41187BA0E567}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsIssueItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsIssueItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsIssueItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsIssueItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}