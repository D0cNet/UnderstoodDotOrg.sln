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
public partial class AssistiveToolsIssueFolderItem : CustomItem
{

public static readonly string TemplateId = "{00F6F8A3-915B-4ED2-8437-4BB77B9236C8}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsIssueFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AssistiveToolsIssueFolderItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsIssueFolderItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsIssueFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}