using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class ArticleEntryMessageFolderItem : CustomItem
{

public static readonly string TemplateId = "{033AC7CE-C503-4FEF-94E9-4125E9C18C18}";


#region Boilerplate CustomItem Code

public ArticleEntryMessageFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ArticleEntryMessageFolderItem(Item innerItem)
{
	return innerItem != null ? new ArticleEntryMessageFolderItem(innerItem) : null;
}

public static implicit operator Item(ArticleEntryMessageFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}