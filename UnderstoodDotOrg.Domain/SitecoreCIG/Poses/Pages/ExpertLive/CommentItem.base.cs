using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive
{
public partial class CommentItem : CustomItem
{

public static readonly string TemplateId = "{4BD0BF04-35FB-4912-AD11-20844FAFB924}";


#region Boilerplate CustomItem Code

public CommentItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator CommentItem(Item innerItem)
{
	return innerItem != null ? new CommentItem(innerItem) : null;
}

public static implicit operator Item(CommentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CommentTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Comment Title"]);
	}
}


public CustomTextField Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content"]);
	}
}


#endregion //Field Instance Methods
}
}