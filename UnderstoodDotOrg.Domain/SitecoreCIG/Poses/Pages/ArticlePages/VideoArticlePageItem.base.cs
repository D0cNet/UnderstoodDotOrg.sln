using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class VideoArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{D84F2F6F-7B29-49B6-B940-5546CDBBE21B}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public VideoArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator VideoArticlePageItem(Item innerItem)
{
	return innerItem != null ? new VideoArticlePageItem(innerItem) : null;
}

public static implicit operator Item(VideoArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField VideoFile
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Video File"]);
	}
}


public CustomTextField IntroText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Intro Text"]);
	}
}


public CustomTextField Quote
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Quote"]);
	}
}


public CustomTextField Transcript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Transcript"]);
	}
}


#endregion //Field Instance Methods
}
}