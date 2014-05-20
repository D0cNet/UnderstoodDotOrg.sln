using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.KnowledgeQuizArticlePage
{
public partial class KnowledgeQuizResultItem : CustomItem
{

public static readonly string TemplateId = "{6896B8F7-F001-4EE3-BBEA-88BD31D171AA}";


#region Boilerplate CustomItem Code

public KnowledgeQuizResultItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator KnowledgeQuizResultItem(Item innerItem)
{
	return innerItem != null ? new KnowledgeQuizResultItem(innerItem) : null;
}

public static implicit operator Item(KnowledgeQuizResultItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Explanation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Explanation"]);
	}
}


public CustomIntegerField MinimumCorrectAnswers
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Minimum Correct Answers"]);
	}
}


public CustomIntegerField MaximumCorrectAnswers
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Maximum Correct Answers"]);
	}
}


#endregion //Field Instance Methods
}
}