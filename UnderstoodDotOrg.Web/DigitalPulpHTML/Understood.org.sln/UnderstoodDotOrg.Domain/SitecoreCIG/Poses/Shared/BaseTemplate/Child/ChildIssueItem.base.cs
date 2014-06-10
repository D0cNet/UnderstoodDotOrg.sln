using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
public partial class ChildIssueItem : CustomItem
{

public static readonly string TemplateId = "{FB6B3A57-321D-4223-9C2E-4549E87A7EF6}";


#region Boilerplate CustomItem Code

public ChildIssueItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ChildIssueItem(Item innerItem)
{
	return innerItem != null ? new ChildIssueItem(innerItem) : null;
}

public static implicit operator Item(ChildIssueItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField IssueName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Issue Name"]);
	}
}


public CustomTextField IssueDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Issue Description"]);
	}
}


#endregion //Field Instance Methods
}
}