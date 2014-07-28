using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class AssessmentQuizModalItem : CustomItem
{

public static readonly string TemplateId = "{34E872D9-84D8-492B-B794-2BF3D0FC518F}";


#region Boilerplate CustomItem Code

public AssessmentQuizModalItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizModalItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizModalItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizModalItem customItem)
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


public CustomTextField Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content"]);
	}
}


public CustomTextField ReturntoQuizButton
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Return to Quiz Button"]);
	}
}


#endregion //Field Instance Methods
}
}