using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent
{
public partial class ParentInterestItem : CustomItem
{

public static readonly string TemplateId = "{49DC2843-2B4B-4448-854E-811E73F02360}";


#region Boilerplate CustomItem Code

public ParentInterestItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ParentInterestItem(Item innerItem)
{
	return innerItem != null ? new ParentInterestItem(innerItem) : null;
}

public static implicit operator Item(ParentInterestItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField InterestName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Interest Name"]);
	}
}


public CustomTextField InterestDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Interest Description"]);
	}
}


#endregion //Field Instance Methods
}
}