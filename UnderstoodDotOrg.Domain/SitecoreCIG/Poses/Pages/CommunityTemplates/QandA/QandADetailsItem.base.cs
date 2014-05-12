using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA
{
public partial class QandADetailsItem : CustomItem
{

public static readonly string TemplateId = "{34874488-A715-4575-8952-7C7739CCB1AC}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public QandADetailsItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

}

public static implicit operator QandADetailsItem(Item innerItem)
{
	return innerItem != null ? new QandADetailsItem(innerItem) : null;
}

public static implicit operator Item(QandADetailsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField QuestionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Title"]);
	}
}


public CustomTextField WikiId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WikiId"]);
	}
}


public CustomTextField QuestionBody
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Body"]);
	}
}


public CustomTextField WikiPageId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["WikiPageId"]);
	}
}


public CustomTextField ContentId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ContentId"]);
	}
}


public CustomTextField QuestionAuthor
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question Author"]);
	}
}


#endregion //Field Instance Methods
}
}