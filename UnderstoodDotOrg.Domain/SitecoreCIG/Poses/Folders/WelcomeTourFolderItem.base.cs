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
public partial class WelcomeTourFolderItem : CustomItem
{

public static readonly string TemplateId = "{9930BFDB-7C75-4FDC-87CF-7A23E95A65C5}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public WelcomeTourFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator WelcomeTourFolderItem(Item innerItem)
{
	return innerItem != null ? new WelcomeTourFolderItem(innerItem) : null;
}

public static implicit operator Item(WelcomeTourFolderItem customItem)
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


public CustomTextField Subheading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sub heading"]);
	}
}


#endregion //Field Instance Methods
}
}