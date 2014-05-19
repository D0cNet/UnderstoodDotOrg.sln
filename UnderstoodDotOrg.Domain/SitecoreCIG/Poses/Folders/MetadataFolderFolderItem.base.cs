using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class MetadataFolderFolderItem : CustomItem
{

public static readonly string TemplateId = "{F786C5A2-D8C7-4E38-88E5-D0848E9D6094}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public MetadataFolderFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator MetadataFolderFolderItem(Item innerItem)
{
	return innerItem != null ? new MetadataFolderFolderItem(innerItem) : null;
}

public static implicit operator Item(MetadataFolderFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}