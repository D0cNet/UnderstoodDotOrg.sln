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
public partial class TYCEGradeGroupItem : CustomItem
{

public static readonly string TemplateId = "{A2B66DF2-A44E-4862-8045-D296A2FA059D}";


#region Boilerplate CustomItem Code

public TYCEGradeGroupItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TYCEGradeGroupItem(Item innerItem)
{
	return innerItem != null ? new TYCEGradeGroupItem(innerItem) : null;
}

public static implicit operator Item(TYCEGradeGroupItem customItem)
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


public CustomMultiListField Grades
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Grades"]);
	}
}


#endregion //Field Instance Methods
}
}