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
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class QuizKeepReadingControl : System.Web.UI.UserControl
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

        IEnumerable<DefaultArticlePageItem> FinalRelatedArticles = null;
        //IEnumerable<Item> FinalRelatedQuizs = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId.ToString())
            {
                ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
                frHeadline.Item = ObjBasicArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjBasicArticle);

            }

            if (Sitecore.Context.Item.TemplateID.ToString() == DeepDiveArticlePageItem.TemplateId.ToString())
            {
                ObjDeepDiveArticle = new DeepDiveArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjDeepDiveArticle.DefaultArticlePage;
                frHeadline.Item = ObjDeepDiveArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjDeepDiveArticle);
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == ActionStyleListPageItem.TemplateId.ToString())
            {
                ObjActionStyleArticle = new ActionStyleListPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjActionStyleArticle.DefaultArticlePage;
                frHeadline.Item = ObjActionStyleArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjActionStyleArticle);
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == GlossaryPageItem.TemplateId.ToString())
            {
                ObjGlossaryArticle = new GlossaryPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjGlossaryArticle.DefaultArticlePage;
                frHeadline.Item = ObjGlossaryArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjGlossaryArticle);
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == SimpleExpertArticleItem.TemplateId.ToString())
            {
                ObjSimpleExpertArticle = new SimpleExpertArticleItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjSimpleExpertArticle.DefaultArticlePage;
                frHeadline.Item = ObjSimpleExpertArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjSimpleExpertArticle);
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId.ToString())
            {
                ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjChecklistArticle.DefaultArticlePage;
                frHeadline.Item = ObjChecklistArticle;
                FinalRelatedArticles = GetKeepReadingLinks(ObjChecklistArticle);
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == AssessmentQuizArticlePage1Item.TemplateId.ToString())
            {
                ObjAQuizPage1 = new AssessmentQuizArticlePage1Item(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                FinalRelatedArticles= GetKeepReadingLinks(ObjAQuizPage1);
                frHeadline.Item = ObjAQuizPage1;

            }
            if (Sitecore.Context.Item.TemplateID.ToString() == AssessmentQuizArticlePage2Item.TemplateId.ToString())
            {
                ObjAQuizPage2 = new AssessmentQuizArticlePage2Item(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                FinalRelatedArticles = GetKeepReadingLinks(ObjAQuizPage2);
                frHeadline.Item = ObjAQuizPage2;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == KnowledgeQuizQuestionArticlePageItem.TemplateId.ToString())
            {
                ObjKQuizPage = new KnowledgeQuizQuestionArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = null;
                FinalRelatedArticles = GetKeepReadingLinks(ObjKQuizPage);
                frHeadline.Item = ObjKQuizPage;
            }


          
                    if (FinalRelatedArticles != null)
                    {
                        if (FinalRelatedArticles.Count() > 3) FinalRelatedArticles = FinalRelatedArticles.Take(3);
                        rptKeepReading.DataSource = FinalRelatedArticles;
                        rptKeepReading.DataBind();
                    }

                
           


        }

        public IEnumerable<DefaultArticlePageItem> GetKeepReadingLinks(Item PageItem)
        {
            IEnumerable<Item> AllArticles = null;
            List<DefaultArticlePageItem> FinalArticles = null;
            if (PageItem.TemplateID.ToString()== BasicArticlePageItem.TemplateId)
            {
                BasicArticlePageItem ObjDefArt = (BasicArticlePageItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }

            if (PageItem.TemplateID.ToString()== DeepDiveArticlePageItem.TemplateId)
            {
                DeepDiveArticlePageItem ObjDefArt = (DeepDiveArticlePageItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }
            if (PageItem.TemplateID.ToString()== ActionStyleListPageItem.TemplateId)
            {
                ActionStyleListPageItem ObjDefArt = (ActionStyleListPageItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }
            if (PageItem.TemplateID.ToString() == GlossaryPageItem.TemplateId)
            {
                GlossaryPageItem ObjDefArt = (GlossaryPageItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }
            if (PageItem.TemplateID.ToString()== SimpleExpertArticleItem.TemplateId)
            {
                SimpleExpertArticleItem ObjDefArt = (SimpleExpertArticleItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }
            if (PageItem.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId)
            {
                ChecklistArticlePageItem ObjDefArt = (ChecklistArticlePageItem)PageItem;
                AllArticles = ObjDefArt.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }

            if (PageItem.TemplateID.ToString() == AssessmentQuizArticlePage1Item.TemplateId)
            {
                AssessmentQuizArticlePage1Item ObjAssQuiz1 = (AssessmentQuizArticlePage1Item)PageItem;
                AllArticles = ObjAssQuiz1.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));

            }
            if (PageItem.TemplateID.ToString() == AssessmentQuizArticlePage2Item.TemplateId)
            {
                AssessmentQuizArticlePage2Item ObjAssQuiz2 = (AssessmentQuizArticlePage2Item)PageItem;
                AllArticles = ObjAssQuiz2.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
            }
            if (PageItem.TemplateID.ToString() == KnowledgeQuizQuestionArticlePageItem.TemplateId)
            {
                KnowledgeQuizQuestionArticlePageItem ObjKQuiz = (KnowledgeQuizQuestionArticlePageItem)PageItem;
                AllArticles = ObjKQuiz.KeepReadingContent.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
            }

            if (AllArticles != null)
            {
                if (AllArticles.Count() > 3) AllArticles.Take(3);
                FinalArticles = new List<DefaultArticlePageItem>(AllArticles.Count());
                foreach (DefaultArticlePageItem DefItem in AllArticles)
                {
                    FinalArticles.Add(DefItem);
                }
            }
            //else
            //{
            //    //Select Random max 6 articles to show
            //    var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            //    using (var context = index.CreateSearchContext())
            //    {
            //        IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
            //             .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
            //        //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
            //        if (RandomRelatedLink != null)
            //        {
            //            if (RandomRelatedLink.Count() > 3) RandomRelatedLink.Take(3);
            //            FinalArticles = new List<DefaultArticlePageItem>(RandomRelatedLink.Count());
            //        }
            //        foreach (DefaultArticlePageItem DefItem in RandomRelatedLink)
            //        {
            //            FinalArticles.Add(DefItem);
            //        }
            //    }
            //}

            return FinalArticles;
        }

        protected void rptKeepReading_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                if (RelatedLink != null)
                {
                    FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    HyperLink hlPageTitle = e.FindControlAs<HyperLink>("hlPageTitle");
                    if (frPageTitle != null)
                    {
                        frPageTitle.Item = RelatedLink.ContentPage.InnerItem;
                        hlPageTitle.NavigateUrl = RelatedLink.ContentPage.InnerItem.GetUrl();
                        hlPageTitle.Visible = true;
                    }

                }

            }
        }
    }
}