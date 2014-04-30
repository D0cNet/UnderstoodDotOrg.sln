using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using  UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
public partial class AdvocacyArticlePageItem 
{
    public static IEnumerable<ArticleCalloutItem> GetAllArticleCallouts(AdvocacyArticlePageItem ObjAdvocacyArticle)
    {
        IEnumerable<ArticleCalloutItem> AllSlideItems = ObjAdvocacyArticle.AllArticleCallouts;
        return AllSlideItems;
    }
    private IEnumerable<ArticleCalloutItem> _allArticleCallouts;
    private IEnumerable<ArticleCalloutItem> AllArticleCallouts
    {
        get
        {
            if (_allArticleCallouts == null)
            {
                _allArticleCallouts = this.InnerItem.GetChildren()
                    .Where(t => t.TemplateID.ToString() == ArticleCalloutItem.TemplateId.ToString())
                    .Select(x => new ArticleCalloutItem(x));
            }

            return _allArticleCallouts;
        }
    }
}
}