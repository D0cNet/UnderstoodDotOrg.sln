using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ChecklistArticle
{
public partial class TopicCheckboxItem : CustomItem
{

public static readonly string TemplateId = "{F24CEAAE-D88D-4773-8F21-A1EA2815B193}";


#region Boilerplate CustomItem Code

public TopicCheckboxItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TopicCheckboxItem(Item innerItem)
{
	return innerItem != null ? new TopicCheckboxItem(innerItem) : null;
}

public static implicit operator Item(TopicCheckboxItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TopicTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Topic Title"]);
	}
}


public CustomCheckboxField ShowCheckbox
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Checkbox"]);
	}
}


#endregion //Field Instance Methods
}
}