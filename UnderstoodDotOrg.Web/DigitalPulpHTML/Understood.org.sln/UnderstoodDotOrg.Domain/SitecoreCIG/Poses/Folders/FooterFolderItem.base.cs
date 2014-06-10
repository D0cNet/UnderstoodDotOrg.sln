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
public partial class FooterFolderItem : CustomItem
{

public static readonly string TemplateId = "{9EE3D4D4-C8BD-4BAD-94CD-26581124EB92}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public FooterFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator FooterFolderItem(Item innerItem)
{
	return innerItem != null ? new FooterFolderItem(innerItem) : null;
}

public static implicit operator Item(FooterFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TopText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Top Text"]);
	}
}


public CustomTextField BottomText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Bottom Text"]);
	}
}


#endregion //Field Instance Methods
}
}