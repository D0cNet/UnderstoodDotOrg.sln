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
public partial class AdvocacyMainFolderItem : CustomItem
{

public static readonly string TemplateId = "{2E4CE8E9-70F6-45EC-834B-91EBC3E486EA}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdvocacyMainFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator AdvocacyMainFolderItem(Item innerItem)
{
	return innerItem != null ? new AdvocacyMainFolderItem(innerItem) : null;
}

public static implicit operator Item(AdvocacyMainFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField AdvocacyfromPartner
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Advocacy from Partner"]);
	}
}


#endregion //Field Instance Methods
}
}