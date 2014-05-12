using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
public partial class BehaviorAdvicePageItem : CustomItem
{

public static readonly string TemplateId = "{F42D9D95-D98C-4490-A488-B85F48CDB7D5}";

#region Inherited Base Templates

private readonly BasePageNEWItem _BasePageNEWItem;
public BasePageNEWItem BasePageNEW { get { return _BasePageNEWItem; } }

#endregion

#region Boilerplate CustomItem Code

public BehaviorAdvicePageItem(Item innerItem) : base(innerItem)
{
	_BasePageNEWItem = new BasePageNEWItem(innerItem);

}

public static implicit operator BehaviorAdvicePageItem(Item innerItem)
{
	return innerItem != null ? new BehaviorAdvicePageItem(innerItem) : null;
}

public static implicit operator Item(BehaviorAdvicePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField ChildChallenges
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Challenges"]);
	}
}


public CustomTextField TipTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Tip Title"]);
	}
}


public CustomTextField RelatedArticlesTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Articles Title"]);
	}
}


public CustomTreeListField ChildGrades
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Child Grades"]);
	}
}


public CustomTreeListField RelatedArticlesItems
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Articles Items"]);
	}
}


#endregion //Field Instance Methods
}
}