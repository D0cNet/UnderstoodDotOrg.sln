using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle ;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle
{
public partial class TextOnlyTipsArticlePageItem 
{
    public static IEnumerable<TextTipPageItem> GetAllSlides(TextOnlyTipsArticlePageItem ObjSlideArticle)
    {
        IEnumerable<TextTipPageItem> AllSlideItems = ObjSlideArticle.AllSlides;
        return AllSlideItems;
    }
    private IEnumerable<TextTipPageItem> _allSlides;
    private IEnumerable<TextTipPageItem> AllSlides
    {
        get
        {
            if (_allSlides == null)
            {
                _allSlides = this.InnerItem.GetChildren()
                    .Where(t => t.TemplateID.ToString() == TextTipPageItem.TemplateId.ToString())
                    .Select(x => new TextTipPageItem(x));
            }

            return _allSlides;
        }
    }

  }
}