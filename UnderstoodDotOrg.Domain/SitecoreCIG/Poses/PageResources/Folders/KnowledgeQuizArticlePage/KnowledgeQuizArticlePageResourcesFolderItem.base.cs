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
public partial class KnowledgeQuizArticlePageResourcesFolderItem : CustomItem
{

public static readonly string TemplateId = "{22720C19-23F2-4179-B18C-1F449DAD435D}";

#region Inherited Base Templates

private readonly FolderItem _FolderItem;
public FolderItem Folder { get { return _FolderItem; } }

#endregion

#region Boilerplate CustomItem Code

public KnowledgeQuizArticlePageResourcesFolderItem(Item innerItem) : base(innerItem)
{
	_FolderItem = new FolderItem(innerItem);

}

public static implicit operator KnowledgeQuizArticlePageResourcesFolderItem(Item innerItem)
{
	return innerItem != null ? new KnowledgeQuizArticlePageResourcesFolderItem(innerItem) : null;
}

public static implicit operator Item(KnowledgeQuizArticlePageResourcesFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}