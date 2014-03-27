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
public partial class ParentToolkitFolderItem : CustomItem
{

public static readonly string TemplateId = "{C6087ECF-9931-4E3B-82CB-7F230D824D08}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public ParentToolkitFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator ParentToolkitFolderItem(Item innerItem)
{
	return innerItem != null ? new ParentToolkitFolderItem(innerItem) : null;
}

public static implicit operator Item(ParentToolkitFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Heading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Heading"]);
	}
}


#endregion //Field Instance Methods
}
}