using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Framework.UI;
using Sitecore.Data;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SuggestArticlePageCarousal : BaseSublayout
    {
        DefaultArticlePageItem ObjDefaultArticle;
        List<DefaultArticlePageItem> FinalRelatedArticles = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ObjDefaultArticle = new DefaultArticlePageItem(Sitecore.Context.Item);
            if (Sitecore.Context.Item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                ObjDefaultArticle = new DefaultArticlePageItem(Sitecore.Context.Item);
            }
            if (ObjDefaultArticle != null)
            {
                if (!ObjDefaultArticle.HideRelatedActiveLinks.Checked) // Show Articles
                {
                    //Get list of selected item
                    FinalRelatedArticles = GetRelatedLinks(ObjDefaultArticle);
                    if (FinalRelatedArticles != null)
                    {
                        rptMoreArticle.DataSource = FinalRelatedArticles;
                        rptMoreArticle.DataBind();
                    }
                    frRelatedLinkTitle.Visible = true;
                }
                else
                {
                    frRelatedLinkTitle.Visible = false;
                    rptMoreArticle.DataSource = null;
                    rptMoreArticle.DataBind();
                }
            }
        }

        public List<DefaultArticlePageItem> GetRelatedLinks(DefaultArticlePageItem ObjDefArt)
        {
            var AllArticles = ObjDefArt.RelatedLink.ListItems
                .Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
            if (AllArticles.Any())
            {
                return AllArticles
                    .Select(i => (DefaultArticlePageItem)i)
                    .Take(6).ToList();
            }
            else
            {
                //Select Random max 6 articles to show
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    var defaultArticlePageTemplateId = new ID(DefaultArticlePageItem.TemplateId);
                    return context.GetQueryable<SearchResultItem>()
                        .Where(sri => sri.TemplateId == defaultArticlePageTemplateId).ToList()
                        .Select(i => i.GetItem())
                        .Where(i => i != null)
                        .OrderBy(i => Guid.NewGuid())
                        .Take(6)
                        .Select(i => (DefaultArticlePageItem)i).ToList();
                }
            }
        }

        protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                //CHECK FOR HEAR TEMPPLATE SET H2 TAG
                //IF ITEM TEMPLATE, SET ALL ARTICLE DATA.

                if (RelatedLink != null)
                {
                    var frLinkTitle = e.FindControlAs<FieldRenderer>("frLinkTitle");
                    var hlLinkTitle = e.FindControlAs<HyperLink>("hlLinkTitle");
                    if (frLinkTitle != null)
                    {
                        frLinkTitle.Item = RelatedLink.ContentPage.InnerItem;
                        hlLinkTitle.NavigateUrl = frLinkTitle.Item.Paths.ContentPath;
                    }
                    var frLinkImage = e.FindControlAs<FieldRenderer>("frLinkImage");
                    if (frLinkImage != null)
                    {
                        frLinkImage.Item = RelatedLink.InnerItem;
                    }
                }
            }
        }

    }
}
