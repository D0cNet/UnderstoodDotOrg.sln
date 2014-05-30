using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class TermsandConditionsItem : CustomItem
{

public static readonly string TemplateId = "{619DFBDC-CE75-43CA-82B6-0B3EA6D04173}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public TermsandConditionsItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator TermsandConditionsItem(Item innerItem)
{
	return innerItem != null ? new TermsandConditionsItem(innerItem) : null;
}

public static implicit operator Item(TermsandConditionsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TermsandConditionsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Terms and Conditions Text"]);
	}
}


public CustomTextField TermsandConditionsTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Terms and Conditions Title"]);
	}
}


#endregion //Field Instance Methods
}
}