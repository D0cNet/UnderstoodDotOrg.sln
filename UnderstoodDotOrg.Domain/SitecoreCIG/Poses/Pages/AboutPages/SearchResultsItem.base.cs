using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class SearchResultsItem : CustomItem
{

public static readonly string TemplateId = "{683A5B21-DB5D-4F25-9B75-584AF270D6E9}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SearchResultsItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator SearchResultsItem(Item innerItem)
{
	return innerItem != null ? new SearchResultsItem(innerItem) : null;
}

public static implicit operator Item(SearchResultsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ShowingResultsLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Showing Results Label"]);
	}
}


public CustomTextField ResultsForLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Results For Label"]);
	}
}


public CustomTextField SearchInsteadForLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Search Instead For Label"]);
	}
}


public CustomTextField NoResultsMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["No Results Message"]);
	}
}


public CustomIntegerField SearchResultSummaryCharacterLimit
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Search Result Summary Character Limit"]);
	}
}


public CustomTextField ToolWidgetsHeading
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tool Widgets Heading"]);
	}
}


public CustomTreeListField ToolWidgets
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Tool Widgets"]);
	}
}


#endregion //Field Instance Methods
}
}