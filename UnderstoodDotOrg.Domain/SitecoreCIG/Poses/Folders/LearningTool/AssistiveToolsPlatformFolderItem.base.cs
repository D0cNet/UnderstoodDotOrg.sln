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
public partial class AssistiveToolsPlatformFolderItem : CustomItem
{

public static readonly string TemplateId = "{BAEF90F1-9605-4513-8F6E-88204C9F29E2}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsPlatformFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AssistiveToolsPlatformFolderItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsPlatformFolderItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsPlatformFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}