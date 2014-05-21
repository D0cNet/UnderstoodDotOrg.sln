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
public partial class AssessmentQuizResultsFolderItem : CustomItem
{

public static readonly string TemplateId = "{B0AE97B6-8201-4A34-BFA7-2485BBAC53BC}";


#region Boilerplate CustomItem Code

public AssessmentQuizResultsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizResultsFolderItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizResultsFolderItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizResultsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}