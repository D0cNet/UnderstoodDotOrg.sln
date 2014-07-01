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
public partial class EducationalInstitutionItem : CustomItem
{

public static readonly string TemplateId = "{70ABBAFF-9F79-42AA-8FFB-CE050F62F9C9}";


#region Boilerplate CustomItem Code

public EducationalInstitutionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EducationalInstitutionItem(Item innerItem)
{
	return innerItem != null ? new EducationalInstitutionItem(innerItem) : null;
}

public static implicit operator Item(EducationalInstitutionItem customItem)
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


public CustomTextField EducationLevel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Education Level"]);
	}
}


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}


#endregion //Field Instance Methods
}
}