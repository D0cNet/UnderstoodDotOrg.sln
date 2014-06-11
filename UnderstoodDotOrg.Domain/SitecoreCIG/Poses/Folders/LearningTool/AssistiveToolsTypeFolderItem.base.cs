using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool
{
public partial class AssistiveToolsTypeFolderItem : CustomItem
{

public static readonly string TemplateId = "{B957B3FB-1573-4A3A-AF71-0D9F9EC9FDFC}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsTypeFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AssistiveToolsTypeFolderItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsTypeFolderItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsTypeFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}