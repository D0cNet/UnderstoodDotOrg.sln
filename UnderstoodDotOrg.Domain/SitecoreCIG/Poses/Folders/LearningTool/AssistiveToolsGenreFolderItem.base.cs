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
public partial class AssistiveToolsGenreFolderItem : CustomItem
{

public static readonly string TemplateId = "{7887791C-0D04-40D2-A35A-71108CB6A981}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsGenreFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AssistiveToolsGenreFolderItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsGenreFolderItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsGenreFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}