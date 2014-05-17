using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages
{
    public partial class SubtopicLandingPageItem 
    {
        // TODO: implement paging for show more
        public IEnumerable<DefaultArticlePageItem> GetArticles()
        {
            return InnerItem.GetChildren()
                .FilterByContextLanguageVersion()
                .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                .Select(i => new DefaultArticlePageItem(i));
        }
    }
}