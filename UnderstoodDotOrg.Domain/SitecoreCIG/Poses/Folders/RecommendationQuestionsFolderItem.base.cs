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
public partial class RecommendationQuestionsFolderItem : CustomItem
{

public static readonly string TemplateId = "{A5E4B2B6-C447-48A9-BF8F-52E5206E8992}";


#region Boilerplate CustomItem Code

public RecommendationQuestionsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RecommendationQuestionsFolderItem(Item innerItem)
{
	return innerItem != null ? new RecommendationQuestionsFolderItem(innerItem) : null;
}

public static implicit operator Item(RecommendationQuestionsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}