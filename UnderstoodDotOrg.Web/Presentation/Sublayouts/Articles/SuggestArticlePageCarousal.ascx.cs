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
using UnderstoodDotOrg.Domain.Search.JSON;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SuggestArticlePageCarousal : BaseSublayout
    {
        DefaultArticlePageItem ObjDefaultArticle;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindArticles();
        }

        public void BindArticles()
        {
            if (Sitecore.Context.Item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                ObjDefaultArticle = new DefaultArticlePageItem(Sitecore.Context.Item);
            }
            if (ObjDefaultArticle != null)
            {
                if (!ObjDefaultArticle.HideRelatedActiveLinks.Checked) // Show Articles
                {
                    var AllArticles = ObjDefaultArticle.RelatedLink.ListItems
                        .Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    if (AllArticles.Any())
                    {
                        rptDefaultArticles.DataSource = AllArticles
                            .Select(i => (DefaultArticlePageItem)i)
                            .Take(6).ToList();
                        rptDefaultArticles.DataBind();
                        frRelatedLinkTitle.Visible = true;
                    }
                    else
                    {
                        Handlers.SearchResultsService svc = new Handlers.SearchResultsService();

                        rptMoreArticle.DataSource = svc.SearchAllArticles("", "%7BC272C2C3-9405-49D0-9BC1-A64F76C750DC%7D", 1).Articles.Take(6);
                        rptMoreArticle.DataBind();
                        frRelatedLinkTitle.Visible = true;
                    }
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
