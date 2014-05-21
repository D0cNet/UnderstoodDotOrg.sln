using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.AssessmentQuizArticlePage
{
public partial class AssessmentQuizResultItem : CustomItem
{

public static readonly string TemplateId = "{C97DF56E-C644-4BAF-8ED0-5B050300C397}";


#region Boilerplate CustomItem Code

public AssessmentQuizResultItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AssessmentQuizResultItem(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizResultItem(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizResultItem customItem)
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


public CustomTextField Detail
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Detail"]);
	}
}


public CustomIntegerField MinimumValue
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Minimum Value"]);
	}
}


public CustomIntegerField MaximumValue
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Maximum Value"]);
	}
}


#endregion //Field Instance Methods
}
}