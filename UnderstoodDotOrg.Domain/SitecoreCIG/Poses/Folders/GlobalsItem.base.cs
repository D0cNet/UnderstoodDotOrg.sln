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
public partial class GlobalsItem : CustomItem
{

public static readonly string TemplateId = "{237D4B8C-720F-4729-A699-89D6E87F4A49}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public GlobalsItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator GlobalsItem(Item innerItem)
{
	return innerItem != null ? new GlobalsItem(innerItem) : null;
}

public static implicit operator Item(GlobalsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods

public CustomTextField GoogleAnalytics
{
    get
    {
        return new CustomTextField(InnerItem, InnerItem.Fields["Google Analytics"]);
    }
}
#endregion //Field Instance Methods
}
}