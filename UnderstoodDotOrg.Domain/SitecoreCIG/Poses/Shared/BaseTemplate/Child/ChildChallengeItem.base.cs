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
public partial class ChildChallengeItem : CustomItem
{

public static readonly string TemplateId = "{E8016E46-1F90-469C-A42D-62F1A95FCDDC}";


#region Boilerplate CustomItem Code

public ChildChallengeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ChildChallengeItem(Item innerItem)
{
	return innerItem != null ? new ChildChallengeItem(innerItem) : null;
}

public static implicit operator Item(ChildChallengeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ChallengeName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Challenge Name"]);
	}
}


public CustomTextField ChallengeDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Challenge Description"]);
	}
}


#endregion //Field Instance Methods
}
}