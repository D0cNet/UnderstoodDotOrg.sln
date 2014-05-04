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

using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SuggestArticlePageCarousal : System.Web.UI.UserControl
    {

        DefaultArticlePageItem ObjDefaultArticle;
        AudioArticlePageItem ObjAudioArticle;
        ChecklistArticlePageItem ObjChecklistArticle;
        SimpleExpertArticleItem ObjSimpleExpertArticle;
        SlideshowArticlePageItem ObjSlideShowArticle;
        VideoArticlePageItem ObjVideoArticle;
        BasicArticlePageItem ObjBasicArticle;
        TextOnlyTipsArticlePageItem ObjTextTipsArticle;
        TakeActionPageItem ObjTakeActionPage;
        IEnumerable<DefaultArticlePageItem> FinalRelatedArticles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ObjDefaultArticle = new DefaultArticlePageItem(Sitecore.Context.Item);
            if (Sitecore.Context.Item.TemplateID.ToString() == AudioArticlePageItem.TemplateId.ToString())
            {
                ObjAudioArticle = new AudioArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjAudioArticle.DefaultArticlePage;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == TextOnlyTipsArticlePageItem.TemplateId.ToString())
            {
                ObjTextTipsArticle = new TextOnlyTipsArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjTextTipsArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == VideoArticlePageItem.TemplateId.ToString())
            {
                ObjVideoArticle = new VideoArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjVideoArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId.ToString())
            {
                ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjChecklistArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == SimpleExpertArticleItem.TemplateId.ToString())
            {
                ObjSimpleExpertArticle = new SimpleExpertArticleItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjSimpleExpertArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == SlideshowArticlePageItem.TemplateId.ToString())
            {
                ObjSlideShowArticle = new SlideshowArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjSlideShowArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId.ToString())
            {
                ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == TakeActionPageItem.TemplateId.ToString())
            {
                ObjTakeActionPage = new TakeActionPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                if (ObjTakeActionPage.HideRelatedActiveLinks.Checked == false) // Show Articles
                {
                    //Get list of selected item
                    FinalRelatedArticles = GetRelatedLinks(ObjTakeActionPage);
                    if (FinalRelatedArticles != null)
                    {
                        rptMoreArticle.DataSource = FinalRelatedArticles;
                        rptMoreArticle.DataBind();
                    }

                }
            }
            if (ObjDefaultArticle != null)
            {
                if (ObjDefaultArticle.HideRelatedActiveLinks.Checked == false) // Show Articles
                {
                    //Get list of selected item
                    FinalRelatedArticles = GetRelatedLinks(ObjDefaultArticle);
                    if (FinalRelatedArticles != null)
                    {
                        rptMoreArticle.DataSource = FinalRelatedArticles;
                        rptMoreArticle.DataBind();
                    }

                }
            }
        }
        public IEnumerable<DefaultArticlePageItem> GetRelatedLinks(TakeActionPageItem ObjDefArt)
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
            else
            {
                //Select Random max 6 articles to show
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    if (RandomRelatedLink != null)
                    {
                        if (RandomRelatedLink.Count() > 6) RandomRelatedLink.Take(6);
                        FinalArticles = new List<DefaultArticlePageItem>(RandomRelatedLink.Count());
                    }
                    foreach (DefaultArticlePageItem DefItem in RandomRelatedLink)
                    {
                        FinalArticles.Add(DefItem);
                    }
                }
            }

            return FinalArticles;
        }
        public IEnumerable<DefaultArticlePageItem> GetRelatedLinks(DefaultArticlePageItem ObjDefArt)
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
            else
            {
                //Select Random max 6 articles to show
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    if (RandomRelatedLink != null)
                    {
                        if (RandomRelatedLink.Count() > 6) RandomRelatedLink.Take(6);
                        FinalArticles = new List<DefaultArticlePageItem>(RandomRelatedLink.Count());
                    }
                    foreach (DefaultArticlePageItem DefItem in RandomRelatedLink)
                    {
                        FinalArticles.Add(DefItem);
                    }
                }
            }

            return FinalArticles;
        }
        //private System.Collections.Generic.IEnumerable<Item> GetRelatedItemsList(DefaultArticlePageItem ObjDefaultArt)
        //{
        //    System.Collections.Generic.IEnumerable<Item> ActualRelatedLinks = null;
        //    // if (ObjDefaultArt.HideRelatedActiveLinks.Checked == false)
        //    //{
        //    if (ObjDefaultArt.RelatedLink.ListItems.ToList().Count >= 1) // Are Articles selected? Show first six if selected
        //    {
        //        System.Collections.Generic.IEnumerable<Item> AllRelatedLinks = ObjDefaultArt.RelatedLink.ListItems;
        //        ActualRelatedLinks = from art in AllRelatedLinks
        //                             where (art.InheritsTemplate(DefaultArticlePageItem.TemplateId))
        //                             select art;
        //        if (ActualRelatedLinks != null)
        //        {
        //            if (ActualRelatedLinks.Count() > 6)
        //            {
        //                ActualRelatedLinks = ActualRelatedLinks.Take(6);
        //            }

        //        }
        //    }
        //    else // Show random six articles
        //    {
        //        var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
        //        using (var context = index.CreateSearchContext())
        //        {
        //            var RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
        //                 .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
        //            //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
        //            ActualRelatedLinks = RandomRelatedLink;
        //            if (ActualRelatedLinks != null)
        //            {
        //                if (ActualRelatedLinks.Count() > 6)
        //                {
        //                    ActualRelatedLinks = ActualRelatedLinks.Take(6);
        //                }

        //            }
        //        }
        //        // }
        //    }
        //    return ActualRelatedLinks;
        //}

        protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                //CHECK FOR HEAR TEMPPLATE SET H2 TAG
                //IF ITEM TEMPLATE, SET ALL ARTICLE DATA.

                if (RelatedLink != null)
                {
                    //  DefaultArticlePageItem def = e.Item.DataItem as DefaultArticlePageItem;
                    FieldRenderer frLinkTitle = e.FindControlAs<FieldRenderer>("frLinkTitle");
                    HyperLink hlLinkTitle = e.FindControlAs<HyperLink>("hlLinkTitle");
                    if (frLinkTitle != null)
                    {
                        frLinkTitle.Item = RelatedLink.ContentPage.InnerItem;
                        hlLinkTitle.NavigateUrl = frLinkTitle.Item.Paths.ContentPath;
                    }
                    FieldRenderer frLinkImage = e.FindControlAs<FieldRenderer>("frLinkImage");
                    if (frLinkImage != null)
                    {
                        frLinkImage.Item = RelatedLink.InnerItem;

                    }
                }

            }


        }

    }
}
