using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class SavedProfileQuestionsControlItem : CustomItem
{

public static readonly string TemplateId = "{BD262A99-86FC-4996-8E77-02A8A9A425DE}";


#region Boilerplate CustomItem Code

public SavedProfileQuestionsControlItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SavedProfileQuestionsControlItem(Item innerItem)
{
	return innerItem != null ? new SavedProfileQuestionsControlItem(innerItem) : null;
}

public static implicit operator Item(SavedProfileQuestionsControlItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Question1Text
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 1 Text"]);
	}
}


public CustomTextField Question2Text
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 2 Text"]);
	}
}


public CustomTextField Question3Text
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 3 Text"]);
	}
}


public CustomTextField Question1Link
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 1 Link"]);
	}
}


public CustomTextField Question2Link
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 2 Link"]);
	}
}


public CustomTextField Question3Link
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question 3 Link"]);
	}
}


#endregion //Field Instance Methods
}
}