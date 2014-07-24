using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class DonationAmountItem : CustomItem
{

public static readonly string TemplateId = "{2A2BBB82-52E5-429A-8752-CAED8AB98E48}";


#region Boilerplate CustomItem Code

public DonationAmountItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DonationAmountItem(Item innerItem)
{
	return innerItem != null ? new DonationAmountItem(innerItem) : null;
}

public static implicit operator Item(DonationAmountItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField DisplayAmount
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Amount"]);
	}
}


public CustomIntegerField Amount
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Amount"]);
	}
}


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Description"]);
	}
}


public CustomCheckboxField IsCustomAmount
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Is Custom Amount"]);
	}
}


#endregion //Field Instance Methods
}
}