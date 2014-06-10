using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Slideshow;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class SlideshowArticlePageItem 
{
    public static IEnumerable<SlidesPageItem> GetAllSlides(SlideshowArticlePageItem ObjSlideArticle)
    {
        IEnumerable<SlidesPageItem> AllSlideItems = ObjSlideArticle.AllSlides;
        return AllSlideItems;
    }
    private IEnumerable<SlidesPageItem> _allSlides;
    private IEnumerable<SlidesPageItem> AllSlides
    {
        get
        {
            if (_allSlides == null)
            {
                _allSlides = this.InnerItem.GetChildren()
                    .Where(t => t.TemplateID.ToString() == SlidesPageItem.TemplateId.ToString())
                    .Select(x => new SlidesPageItem(x));
            }

            return _allSlides;
        }
    }
}
}