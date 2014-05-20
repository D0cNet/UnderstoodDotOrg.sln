using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.ToolkitArticlePageTools
{
public partial class VideoToolkitResourceItem : CustomItem
{

public static readonly string TemplateId = "{8B92D2C0-ED28-4B2A-806E-6D83A10A9DFC}";


#region Boilerplate CustomItem Code

public VideoToolkitResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator VideoToolkitResourceItem(Item innerItem)
{
	return innerItem != null ? new VideoToolkitResourceItem(innerItem) : null;
}

public static implicit operator Item(VideoToolkitResourceItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField ActionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Action Text"]);
	}
}


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


#endregion //Field Instance Methods
}
}