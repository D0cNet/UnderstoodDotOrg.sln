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
public partial class AssistiveToolsCategoryFolderItem : CustomItem
{

public static readonly string TemplateId = "{4FE2EEFC-110A-44E3-BBD7-4905A43C33CB}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsCategoryFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AssistiveToolsCategoryFolderItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsCategoryFolderItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsCategoryFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}