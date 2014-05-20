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
public partial class WordToolkitResourceItem : CustomItem
{

public static readonly string TemplateId = "{AF94A5B7-6A04-435C-A91F-FA8EEE1521EE}";


#region Boilerplate CustomItem Code

public WordToolkitResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WordToolkitResourceItem(Item innerItem)
{
	return innerItem != null ? new WordToolkitResourceItem(innerItem) : null;
}

public static implicit operator Item(WordToolkitResourceItem customItem)
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


public CustomFileField Link
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Link"]);
	}
}


#endregion //Field Instance Methods
}
}