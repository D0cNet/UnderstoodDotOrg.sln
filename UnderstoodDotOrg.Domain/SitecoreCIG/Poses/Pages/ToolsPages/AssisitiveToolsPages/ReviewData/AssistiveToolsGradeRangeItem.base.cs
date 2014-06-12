using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData
{
public partial class AssistiveToolsGradeRangeItem : CustomItem
{

public static readonly string TemplateId = "{CFE0BFB9-F307-4730-9F60-7BF5E7AA954B}";

#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsGradeRangeItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);

}

public static implicit operator AssistiveToolsGradeRangeItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsGradeRangeItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsGradeRangeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomIntegerField GradeLowerBound
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Grade Lower Bound"]);
	}
}


public CustomIntegerField GradeUpperBound
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Grade Upper Bound"]);
	}
}


#endregion //Field Instance Methods
}
}