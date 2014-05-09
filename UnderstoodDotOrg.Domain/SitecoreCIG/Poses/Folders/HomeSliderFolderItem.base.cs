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
public partial class HomeSliderFolderItem : CustomItem
{

public static readonly string TemplateId = "{F9E8D828-A8B6-48E1-9393-5E03FE2C9EB0}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public HomeSliderFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator HomeSliderFolderItem(Item innerItem)
{
	return innerItem != null ? new HomeSliderFolderItem(innerItem) : null;
}

public static implicit operator Item(HomeSliderFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField RandomizeSlides
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Randomize Slides"]);
	}
}


#endregion //Field Instance Methods
}
}