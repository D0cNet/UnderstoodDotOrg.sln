using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Glossarypage
{
public partial class GlossaryTermItem : CustomItem
{

public static readonly string TemplateId = "{7E66AA33-F154-4398-941C-2D1E6B076590}";


#region Boilerplate CustomItem Code

public GlossaryTermItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator GlossaryTermItem(Item innerItem)
{
	return innerItem != null ? new GlossaryTermItem(innerItem) : null;
}

public static implicit operator Item(GlossaryTermItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField GlossaryTermTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Glossary Term Title"]);
	}
}


public CustomTextField GlossaryTermDefinition
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Glossary Term Definition"]);
	}
}


public CustomTextField GlossaryTermAlternateSpellings
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Glossary Term Alternate Spellings"]);
	}
}


public CustomTextField TermAnchor
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Term Anchor"]);
	}
}


#endregion //Field Instance Methods
}
}