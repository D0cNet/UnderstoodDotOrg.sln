using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
public partial class TyceVideoItem : CustomItem
{

public static readonly string TemplateId = "{F9EE6BB1-B790-4042-BEDF-E4E58CEAE2DD}";


#region Boilerplate CustomItem Code

public TyceVideoItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TyceVideoItem(Item innerItem)
{
	return innerItem != null ? new TyceVideoItem(innerItem) : null;
}

public static implicit operator Item(TyceVideoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Video
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video"]);
	}
}


#endregion //Field Instance Methods
}
}