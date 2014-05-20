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
public partial class AudioToolkitResourceItem : CustomItem
{

public static readonly string TemplateId = "{840C49AF-E3C0-43EE-9A8A-89FFFC02AC55}";


#region Boilerplate CustomItem Code

public AudioToolkitResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AudioToolkitResourceItem(Item innerItem)
{
	return innerItem != null ? new AudioToolkitResourceItem(innerItem) : null;
}

public static implicit operator Item(AudioToolkitResourceItem customItem)
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