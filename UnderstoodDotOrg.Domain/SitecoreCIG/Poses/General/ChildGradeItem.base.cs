using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class ChildGradeItem : CustomItem
{

public static readonly string TemplateId = "{C57B3ECA-D47C-48DC-BF27-3169DA6C0283}";

#region Inherited Base Templates

private readonly ChildDemographicItem _ChildDemographicItem;
public ChildDemographicItem ChildDemographic { get { return _ChildDemographicItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChildGradeItem(Item innerItem) : base(innerItem)
{
	_ChildDemographicItem = new ChildDemographicItem(innerItem);

}

public static implicit operator ChildGradeItem(Item innerItem)
{
	return innerItem != null ? new ChildGradeItem(innerItem) : null;
}

public static implicit operator Item(ChildGradeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Video
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Video"]);
	}
}


#endregion //Field Instance Methods
}
}