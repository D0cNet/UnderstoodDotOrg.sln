using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle
{
    public partial class TextOnlyTipsArticlePageItem
    {
        public IEnumerable<TextTipPageItem> GetSlides()
        {
            return InnerItem.GetChildren().Where(t => t.IsOfType(TextTipPageItem.TemplateId)).Select(x => new TextTipPageItem(x));
        }
    }
}