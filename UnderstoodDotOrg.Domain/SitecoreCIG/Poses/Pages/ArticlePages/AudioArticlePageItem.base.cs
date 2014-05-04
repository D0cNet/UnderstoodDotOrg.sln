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
public partial class AudioArticlePageItem : CustomItem
{

public static readonly string TemplateId = "{F1826F3A-1F30-4D63-8EDC-A0093E185D6A}";

#region Inherited Base Templates

private readonly DefaultArticlePageItem _DefaultArticlePageItem;
public DefaultArticlePageItem DefaultArticlePage { get { return _DefaultArticlePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AudioArticlePageItem(Item innerItem) : base(innerItem)
{
	_DefaultArticlePageItem = new DefaultArticlePageItem(innerItem);

}

public static implicit operator AudioArticlePageItem(Item innerItem)
{
	return innerItem != null ? new AudioArticlePageItem(innerItem) : null;
}

public static implicit operator Item(AudioArticlePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomFileField AudioFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Audio File"]);
	}
}


public CustomTextField CincopaID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Cincopa ID"]);
	}
}


public CustomTextField DescriptionAltText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description Alt Text"]);
	}
}


#endregion //Field Instance Methods
}
}