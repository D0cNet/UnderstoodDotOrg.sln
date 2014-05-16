using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool
{
public partial class DecisionQuestionCategoryFolderItem : CustomItem
{

public static readonly string TemplateId = "{6A33BDE0-F789-4B96-A3D1-96F438ED0CF5}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public DecisionQuestionCategoryFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator DecisionQuestionCategoryFolderItem(Item innerItem)
{
	return innerItem != null ? new DecisionQuestionCategoryFolderItem(innerItem) : null;
}

public static implicit operator Item(DecisionQuestionCategoryFolderItem customItem)
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


#endregion //Field Instance Methods
}
}