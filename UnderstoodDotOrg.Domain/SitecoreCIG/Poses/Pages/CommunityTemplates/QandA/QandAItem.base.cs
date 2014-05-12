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
public partial class QandAItem : CustomItem
{

public static readonly string TemplateId = "{63E4F29F-A2E3-4F2E-BB29-61036750D6BB}";

#region Inherited Base Templates

private readonly CommunityBaseTemplateItem _CommunityBaseTemplateItem;
public CommunityBaseTemplateItem CommunityBaseTemplate { get { return _CommunityBaseTemplateItem; } }

#endregion

#region Boilerplate CustomItem Code

public QandAItem(Item innerItem) : base(innerItem)
{
	_CommunityBaseTemplateItem = new CommunityBaseTemplateItem(innerItem);

}

public static implicit operator QandAItem(Item innerItem)
{
	return innerItem != null ? new QandAItem(innerItem) : null;
}

public static implicit operator Item(QandAItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}