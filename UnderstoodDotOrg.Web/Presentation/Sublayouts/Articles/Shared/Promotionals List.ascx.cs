using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class Promotionals_List : System.Web.UI.UserControl
    {
        DefaultArticlePageItem ObjDefaultArticle;

        BasicArticlePageItem ObjBasicArticle;
        DeepDiveArticlePageItem ObjDeepDiveArticle;
        ActionStyleListPageItem ObjActionStyleArticle;
        GlossaryPageItem ObjGlossaryArticle;
        SimpleExpertArticleItem ObjSimpleExpertArticle;
        ChecklistArticlePageItem ObjChecklistArticle;
        AssessmentQuizArticlePage1Item ObjAQuizPage1;
        AssessmentQuizArticlePage2Item ObjAQuizPage2;
        KnowledgeQuizQuestionArticlePageItem ObjKQuizPage;

        IEnumerable<PromoItem> FinalRelatedArticles = null;
        bool ShowPromo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId.ToString())
            {
                ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
                if (ObjBasicArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjBasicArticle);
                }
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == DeepDiveArticlePageItem.TemplateId.ToString())
            {
                ObjDeepDiveArticle = new DeepDiveArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjDeepDiveArticle.DefaultArticlePage;
                if (ObjDeepDiveArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjDeepDiveArticle);
                }
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == ActionStyleListPageItem.TemplateId.ToString())
            {
                ObjActionStyleArticle = new ActionStyleListPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjActionStyleArticle.DefaultArticlePage;
                if (ObjActionStyleArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjActionStyleArticle);
                }
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == GlossaryPageItem.TemplateId.ToString())
            {
                ObjGlossaryArticle = new GlossaryPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjGlossaryArticle.DefaultArticlePage;
                if (ObjGlossaryArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjGlossaryArticle);
                }
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == SimpleExpertArticleItem.TemplateId.ToString())
            {
                ObjSimpleExpertArticle = new SimpleExpertArticleItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjSimpleExpertArticle.DefaultArticlePage;
                if (ObjSimpleExpertArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjSimpleExpertArticle);
                }
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId.ToString())
            {
                ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjChecklistArticle.DefaultArticlePage;
                if (ObjChecklistArticle.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjChecklistArticle);
                }
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == AssessmentQuizArticlePage1Item.TemplateId.ToString())
            {
                ObjAQuizPage1 = new AssessmentQuizArticlePage1Item(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                if (ObjAQuizPage1.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjAQuizPage1);
                }

            }
            if (Sitecore.Context.Item.TemplateID.ToString() == AssessmentQuizArticlePage2Item.TemplateId.ToString())
            {
                ObjAQuizPage2 = new AssessmentQuizArticlePage2Item(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                if (ObjAQuizPage2.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjAQuizPage2);
                }

            }
            if (Sitecore.Context.Item.TemplateID.ToString() == KnowledgeQuizQuestionArticlePageItem.TemplateId.ToString())
            {
                ObjKQuizPage = new KnowledgeQuizQuestionArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                if (ObjKQuizPage.ShowPromotionalControl.Checked == true)
                {
                    ShowPromo = true;
                    FinalRelatedArticles = GetPromoLinks(ObjKQuizPage);
                }

            }

            if (ShowPromo == true)
            {

                if (FinalRelatedArticles != null)
                {
                    if (FinalRelatedArticles.Count() > 3 && FinalRelatedArticles.Count()!=0) FinalRelatedArticles = FinalRelatedArticles.Take(3);

                    frPromo1.Item = FinalRelatedArticles.ElementAt(0).InnerItem;
                    hlPromo1.NavigateUrl = string.Concat( "http://",Request.Url.Host.ToString(),FinalRelatedArticles.ElementAt(0).InnerItem.GetUrl());
                    //hlPromo1.Text = FinalRelatedArticles.ElementAt(0).InnerItem.Name;
                    hlPromo1.Visible = true;

                    frPromo2.Item = FinalRelatedArticles.ElementAt(1).InnerItem;
                    hlPromo2.NavigateUrl = string.Concat( "http://",Request.Url.Host.ToString(),FinalRelatedArticles.ElementAt(1).InnerItem.GetUrl());
                    //hlPromo2.Text = FinalRelatedArticles.ElementAt(1).InnerItem.Name;
                    hlPromo2.Visible = true;


                    frPromo3.Item = FinalRelatedArticles.ElementAt(2).InnerItem;
                    hlPromo3.NavigateUrl =string.Concat( "http://",Request.Url.Host.ToString(), FinalRelatedArticles.ElementAt(2).InnerItem.GetUrl());
                    //hlPromo3.Text = FinalRelatedArticles.ElementAt(2).InnerItem.Name;
                    hlPromo3.Visible = true;
                }

            }


        }

        public IEnumerable<PromoItem> GetPromoLinks(Item PageItem)
        {
            IEnumerable<Item> AllArticles = null;
            List<PromoItem> FinalArticles = null;
            if (PageItem.InheritsTemplate(BasicArticlePageItem.TemplateId))
            {
                BasicArticlePageItem ObjDefArt = (BasicArticlePageItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }
            if (PageItem.InheritsTemplate(DeepDiveArticlePageItem.TemplateId))
            {
                DeepDiveArticlePageItem ObjDefArt = (DeepDiveArticlePageItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }
            if (PageItem.InheritsTemplate(ActionStyleListPageItem.TemplateId))
            {
                ActionStyleListPageItem ObjDefArt = (ActionStyleListPageItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }
            if (PageItem.InheritsTemplate(GlossaryPageItem.TemplateId))
            {
                GlossaryPageItem ObjDefArt = (GlossaryPageItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }
            if (PageItem.InheritsTemplate(SimpleExpertArticleItem.TemplateId))
            {
                SimpleExpertArticleItem ObjDefArt = (SimpleExpertArticleItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }
            if (PageItem.InheritsTemplate(ChecklistArticlePageItem.TemplateId))
            {
                ChecklistArticlePageItem ObjDefArt = (ChecklistArticlePageItem)PageItem;
                AllArticles = ObjDefArt.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            }


            //if (PageItem.TemplateID.ToString() == AssessmentQuizArticlePage1Item.TemplateId)
            //{
            //    AssessmentQuizArticlePage1Item ObjAssQuiz1 = (AssessmentQuizArticlePage1Item)PageItem;
            //    AllArticles = ObjAssQuiz1.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));

            //}
            //if (PageItem.TemplateID.ToString() == AssessmentQuizArticlePage2Item.TemplateId)
            //{
            //    AssessmentQuizArticlePage2Item ObjAssQuiz2 = (AssessmentQuizArticlePage2Item)PageItem;
            //    AllArticles = ObjAssQuiz2.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));
            //}
            //if (PageItem.TemplateID.ToString() == KnowledgeQuizQuestionArticlePageItem.TemplateId)
            //{
            //    KnowledgeQuizQuestionArticlePageItem ObjKQuiz = (KnowledgeQuizQuestionArticlePageItem)PageItem;
            //    AllArticles = ObjKQuiz.PromotionalContent.ListItems.Where(t => t.InheritsTemplate(PromoItem.TemplateId));
            //}

            //if (AllArticles != null)
            //{
            //    if (AllArticles.Count() > 3) AllArticles.Take(3);
            //    FinalArticles = new List<PromoItem>(AllArticles.Count());
            //    foreach (PromoItem DefItem in AllArticles)
            //    {
            //        FinalArticles.Add(DefItem);
            //    }
            //}
            //else
            //{
            //    //Select Random max 6 articles to show
            //    var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            //    using (var context = index.CreateSearchContext())
            //    {
            //        IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
            //             .Where(i => i.GetItem().InheritsTemplate(PromoItem.TemplateId));
            //        //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
            //        if (RandomRelatedLink != null)
            //        {
            //            if (RandomRelatedLink.Count() > 3) RandomRelatedLink.Take(3);
            //            FinalArticles = new List<PromoItem>(RandomRelatedLink.Count());
            //        }
            //        foreach (PromoItem DefItem in RandomRelatedLink)
            //        {
            //            FinalArticles.Add(DefItem);
            //        }
            //    }
            //}

            return FinalArticles;
        }
    }
}