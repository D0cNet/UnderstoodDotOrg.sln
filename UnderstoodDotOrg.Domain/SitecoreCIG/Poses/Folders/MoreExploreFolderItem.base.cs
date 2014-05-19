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
public partial class MoreExploreFolderItem : CustomItem
{

public static readonly string TemplateId = "{C8C19A59-B961-411C-B86C-07E33D303DCA}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public MoreExploreFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator MoreExploreFolderItem(Item innerItem)
{
	return innerItem != null ? new MoreExploreFolderItem(innerItem) : null;
}

public static implicit operator Item(MoreExploreFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MoreExploreTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Explore Title"]);
	}
}


#endregion //Field Instance Methods
}
}