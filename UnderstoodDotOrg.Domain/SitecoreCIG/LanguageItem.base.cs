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
public partial class LanguageItem : CustomItem
{

public static readonly string TemplateId = "{F68F13A6-3395-426A-B9A1-FA2DC60D94EB}";


#region Boilerplate CustomItem Code

public LanguageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator LanguageItem(Item innerItem)
{
	return innerItem != null ? new LanguageItem(innerItem) : null;
}

public static implicit operator Item(LanguageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField Fallback
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Fallback"]);
	}
}


//Could not find Field Type for Charset


public CustomMultiListField FallbackLanguage
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["FallbackLanguage"]);
	}
}


//Could not find Field Type for Code page


//Could not find Field Type for Dictionary


//Could not find Field Type for Encoding


//Could not find Field Type for Iso


//Could not find Field Type for Regional Iso Code


//Could not find Field Type for WorldLingo Language Identifier


#endregion //Field Instance Methods
}
}