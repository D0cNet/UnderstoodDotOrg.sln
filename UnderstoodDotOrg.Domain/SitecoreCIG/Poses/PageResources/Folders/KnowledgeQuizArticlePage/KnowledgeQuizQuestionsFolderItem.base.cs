using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Folders.KnowledgeQuizArticlePage
{
public partial class KnowledgeQuizQuestionsFolderItem : CustomItem
{

public static readonly string TemplateId = "{CA4F2225-2061-41DB-9295-DFFC848FCE9C}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public KnowledgeQuizQuestionsFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator KnowledgeQuizQuestionsFolderItem(Item innerItem)
{
	return innerItem != null ? new KnowledgeQuizQuestionsFolderItem(innerItem) : null;
}

public static implicit operator Item(KnowledgeQuizQuestionsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}