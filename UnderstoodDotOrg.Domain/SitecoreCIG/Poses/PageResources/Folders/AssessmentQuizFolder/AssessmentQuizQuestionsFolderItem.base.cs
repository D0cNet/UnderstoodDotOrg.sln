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
public partial class AssessmentQuizQuestionsFolderItem : CustomItem
{

public static readonly string TemplateId = "{56FDCD7A-840F-409A-B4CF-69BF70FEC634}";


#region Boilerplate CustomItem Code

public AssessmentQuizQuestionsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizQuestionsFolderItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizQuestionsFolderItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizQuestionsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}