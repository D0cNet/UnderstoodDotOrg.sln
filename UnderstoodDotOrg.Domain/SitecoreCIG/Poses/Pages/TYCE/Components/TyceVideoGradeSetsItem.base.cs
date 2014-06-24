using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
public partial class TyceVideoGradeSetsItem : CustomItem
{

public static readonly string TemplateId = "{C096D34F-C8C3-4CA8-A164-A945D804FDF0}";


#region Boilerplate CustomItem Code

public TyceVideoGradeSetsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TyceVideoGradeSetsItem(Item innerItem)
{
	return innerItem != null ? new TyceVideoGradeSetsItem(innerItem) : null;
}

public static implicit operator Item(TyceVideoGradeSetsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for Introduction With Subtitles


public CustomMultiListField Grades
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Grades"]);
	}
}


//Could not find Field Type for Introduction Without Subtitles


//Could not find Field Type for Child Story With Subtitles


//Could not find Field Type for Child Story Without Subtitles


#endregion //Field Instance Methods
}
}