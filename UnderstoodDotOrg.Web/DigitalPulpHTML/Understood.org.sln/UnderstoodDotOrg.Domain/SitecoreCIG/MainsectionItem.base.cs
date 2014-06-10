using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG
{
public partial class MainsectionItem : CustomItem
{

public static readonly string TemplateId = "{E3E2D58C-DF95-4230-ADC9-279924CECE84}";


#region Boilerplate CustomItem Code

public MainsectionItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MainsectionItem(Item innerItem)
{
	return innerItem != null ? new MainsectionItem(innerItem) : null;
}

public static implicit operator Item(MainsectionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}