using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class LanguageLinkItem : CustomItem
{

public static readonly string TemplateId = "{6255514C-1435-4CEC-8761-A8CA5D921E55}";


#region Boilerplate CustomItem Code

public LanguageLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator LanguageLinkItem(Item innerItem)
{
	return innerItem != null ? new LanguageLinkItem(innerItem) : null;
}

public static implicit operator Item(LanguageLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField LanguageName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Language Name"]);
	}
}


public CustomLookupField SitecoreLanguage
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Sitecore Language"]);
	}
}


#endregion //Field Instance Methods
}
}