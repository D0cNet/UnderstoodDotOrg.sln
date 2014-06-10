using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
    public partial class BasicArticlePageItem
    {
        public List<DefaultArticlePageItem> GetRelatedLinks(DefaultArticlePageItem ObjDefArt)
        {
            // Item SiteRoot=Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"));
            IEnumerable<Item> AllArticles = ObjDefArt.RelatedLink.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
            List<DefaultArticlePageItem> FinalArticles = null;
            if (AllArticles != null)
            {
                if (AllArticles.Count() > 6) AllArticles.Take(6);
                FinalArticles = new List<DefaultArticlePageItem>(AllArticles.Count());
                foreach (DefaultArticlePageItem DefItem in AllArticles)
                {
                    
                    FinalArticles.Add(DefItem);
                }
            }

            return FinalArticles;
        }
    }
}