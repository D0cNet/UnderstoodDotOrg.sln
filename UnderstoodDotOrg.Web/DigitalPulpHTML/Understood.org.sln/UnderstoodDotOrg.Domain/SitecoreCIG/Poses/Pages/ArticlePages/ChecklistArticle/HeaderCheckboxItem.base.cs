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
public partial class HeaderCheckboxItem : CustomItem
{

public static readonly string TemplateId = "{5E18D84C-743F-4316-8756-8ACA8231BBC0}";


#region Boilerplate CustomItem Code

public HeaderCheckboxItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HeaderCheckboxItem(Item innerItem)
{
	return innerItem != null ? new HeaderCheckboxItem(innerItem) : null;
}

public static implicit operator Item(HeaderCheckboxItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
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