using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Folders.AssessmentQuizFolder
{
public partial class AssessmentQuizArticlePageResourcesFolderItem : CustomItem
{

public static readonly string TemplateId = "{9D0A14DD-D745-41D1-A69D-52EE8E36F075}";


#region Boilerplate CustomItem Code

public AssessmentQuizArticlePageResourcesFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizArticlePageResourcesFolderItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizArticlePageResourcesFolderItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizArticlePageResourcesFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}