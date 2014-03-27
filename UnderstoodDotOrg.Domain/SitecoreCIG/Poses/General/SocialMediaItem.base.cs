using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
public partial class SocialMediaItem : CustomItem
{

public static readonly string TemplateId = "{5E8C841F-72A4-4C43-8E49-1637B463FDDA}";


#region Boilerplate CustomItem Code

public SocialMediaItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SocialMediaItem(Item innerItem)
{
	return innerItem != null ? new SocialMediaItem(innerItem) : null;
}

public static implicit operator Item(SocialMediaItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomTextField Script
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Script"]);
	}
}


#endregion //Field Instance Methods
}
}