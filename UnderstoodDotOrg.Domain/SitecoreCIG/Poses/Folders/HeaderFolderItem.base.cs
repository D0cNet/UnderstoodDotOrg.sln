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
public partial class HeaderFolderItem : CustomItem
{

public static readonly string TemplateId = "{5C4355E1-B735-4E8A-8EBB-0B86F95D6BD0}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public HeaderFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator HeaderFolderItem(Item innerItem)
{
	return innerItem != null ? new HeaderFolderItem(innerItem) : null;
}

public static implicit operator Item(HeaderFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CompanyName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Company Name"]);
	}
}


public CustomTextField SearchLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Search Label"]);
	}
}


public CustomImageField CompanyLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Company Logo"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomGeneralLinkField LogoLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Logo Link"]);
	}
}


public CustomGeneralLinkField SignIn
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Sign In"]);
	}
}


public CustomImageField MobileCompanyLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Mobile Company Logo"]);
	}
}


public CustomTextField MobileLogoTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Mobile Logo Title"]);
	}
}


#endregion //Field Instance Methods
}
}