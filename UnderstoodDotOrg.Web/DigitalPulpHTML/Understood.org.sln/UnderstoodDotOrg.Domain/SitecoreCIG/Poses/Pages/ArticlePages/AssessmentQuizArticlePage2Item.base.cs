using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class AssessmentQuizArticlePage2Item : CustomItem
{

public static readonly string TemplateId = "{DB6FA908-617D-4E57-94C2-48872C5908CD}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssessmentQuizArticlePage2Item(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AssessmentQuizArticlePage2Item(Item innerItem)
{
	return innerItem != null ? new AssessmentQuizArticlePage2Item(innerItem) : null;
}

public static implicit operator Item(AssessmentQuizArticlePage2Item customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


//Could not find Field Type for Link to Back Page
public CustomGeneralLinkField LinktoBackPage
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Back Page"]);
    }
}


//Could not find Field Type for Link to Result Page
public CustomGeneralLinkField LinktoResultPage
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Result Page"]);
    }
}

#endregion //Field Instance Methods
}
}