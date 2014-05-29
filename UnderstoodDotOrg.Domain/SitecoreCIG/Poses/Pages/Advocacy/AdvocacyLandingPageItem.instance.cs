using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy
{
    public partial class AdvocacyLandingPageItem
    {
        public List<AdvocacyArticlePageItem> GetAdvocacyArticles()
        {
            return InnerItem.Children.Where(i => i.IsOfType(AdvocacyArticlePageItem.TemplateId)).Select(i => (AdvocacyArticlePageItem)i).ToList();
        }
    }
}