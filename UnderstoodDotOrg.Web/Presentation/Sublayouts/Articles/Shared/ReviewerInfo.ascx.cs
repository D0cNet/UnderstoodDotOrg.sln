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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class ReviewerInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = (DefaultArticlePageItem)Sitecore.Context.Item;

            if (item != null)
            {
                if (item.Reviewedby.Item != null)//Reviwer Name
                {
                    frReviewedby.Item = item.Reviewedby.Item;
                    hlReviewdby.NavigateUrl = item.Reviewedby.Item.GetUrl();
					
					if (item.ReviewedDate.DateTime != null && item.ReviewedDate.DateTime != DateTime.MinValue)// Reviewed date 
					{
						dtReviewdDate.Field = "Reviewed Date";
						dtReviewdDate.Format = "dd MMM yy";

						uxReviewDate.Visible = true;
					}
				}                
            }
        }

       // DefaultArticlePageItem ObjDefaultArticle;
        
       // ChecklistArticlePageItem ObjChecklistArticle;
       // BasicArticlePageItem ObjBasicArticle;
       // AudioArticlePageItem ObjAudioArtcile;
       // VideoArticlePageItem ObjVideoArticle;
       // DeepDiveArticlePageItem ObjDeepDievArticle;
       //// TextOnlyTipsArticlePageItem ObjTextTipArticle;
       // ActionStyleListPageItem ObjActionStyleArticle;
       // GlossaryPageItem ObjGlossaryArticle;
       //// AssessmentQuizArticlePage1Item ObjAssesmtQuizPage1;
       //// AssessmentQuizArticlePage2Item ObjAssesmtQuizPage2;
       // AssessmentQuizArticlePageEndItem ObjAssesmtQuizEnd;
       //// KnowledgeQuizQuestionArticlePageItem ObjKnowledgeQuizPage;
       // KnowledgeQuizResultsArticlePageItem ObjKnowledgeQuizResult;
       // //SimpleExpertArticleItem ObjSimpleExpertArticle;
       // InfographicArticlePageItem ObjInfoGraphicArticle;

       // protected void Page_Load(object sender, EventArgs e)
       // {
       //     if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId)
       //     {
       //         ObjBasicArticle = (BasicArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId)
       //     {
       //         ObjChecklistArticle= (ChecklistArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjChecklistArticle.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == AudioArticlePageItem.TemplateId)
       //     {
       //         ObjAudioArtcile= (AudioArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjAudioArtcile.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == VideoArticlePageItem.TemplateId)
       //     {
       //         ObjVideoArticle= (VideoArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjVideoArticle.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == DeepDiveArticlePageItem.TemplateId)
       //     {
       //         ObjDeepDievArticle= (DeepDiveArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjDeepDievArticle.DefaultArticlePage;
       //     }
       //     //if (Sitecore.Context.Item.TemplateID.ToString() == TextOnlyTipsArticlePageItem.TemplateId)
       //     //{
       //     //    ObjTextTipArticle= (TextOnlyTipsArticlePageItem)Sitecore.Context.Item;
       //     //    ObjDefaultArticle = ObjTextTipArticle.DefaultArticlePage;
       //     //}
       //     if (Sitecore.Context.Item.TemplateID.ToString() == ActionStyleListPageItem.TemplateId)
       //     {
       //         ObjActionStyleArticle= (ActionStyleListPageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjActionStyleArticle.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == GlossaryPageItem.TemplateId)
       //     {
       //         ObjGlossaryArticle= (GlossaryPageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjGlossaryArticle.DefaultArticlePage;
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == AssessmentQuizArticlePageEndItem.TemplateId)
       //     {
       //         ObjAssesmtQuizEnd= (AssessmentQuizArticlePageEndItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = null;
       //         if (ObjAssesmtQuizEnd.Reviewedby.Item != null)//Reviwer Name
       //         {
       //             frReviewedby.Item = ObjAssesmtQuizEnd.Reviewedby.Item;
       //             hlReviewdby.NavigateUrl = string.Concat("http://", Request.Url.Host.ToString(), ObjAssesmtQuizEnd.Reviewedby.Item.GetUrl());
       //         }
       //         if (ObjAssesmtQuizEnd.ReviewedDate.DateTime != null)// Reviewed date 
       //         {
       //             dtReviewdDate.Field = "Reviewed Date";
       //             dtReviewdDate.Format = "dd MMM yy";
       //         }
       //     }
       //     if (Sitecore.Context.Item.TemplateID.ToString() == KnowledgeQuizResultsArticlePageItem.TemplateId)
       //     {
       //         ObjKnowledgeQuizResult= (KnowledgeQuizResultsArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = null;
       //         if (ObjAssesmtQuizEnd.Reviewedby.Item != null)//Reviwer Name
       //         {
       //             frReviewedby.Item = ObjAssesmtQuizEnd.Reviewedby.Item;
       //             hlReviewdby.NavigateUrl = string.Concat("http://", Request.Url.Host.ToString(), ObjAssesmtQuizEnd.Reviewedby.Item.GetUrl());
       //         }
       //         if (ObjAssesmtQuizEnd.ReviewedDate.DateTime != null)// Reviewed date 
       //         {
       //             dtReviewdDate.Field = "Reviewed Date";
       //             dtReviewdDate.Format = "dd MMM yy";
       //         }
       //     }
       //     //if (Sitecore.Context.Item.TemplateID.ToString() == SimpleExpertArticleItem.TemplateId)
       //     //{
       //     //    ObjSimpleExpertArticle= (SimpleExpertArticleItem)Sitecore.Context.Item;
       //     //    ObjDefaultArticle = ObjSimpleExpertArticle.DefaultArticlePage;
       //     //}
       //     if (Sitecore.Context.Item.TemplateID.ToString() == InfographicArticlePageItem.TemplateId)
       //     {
       //         ObjInfoGraphicArticle= (InfographicArticlePageItem)Sitecore.Context.Item;
       //         ObjDefaultArticle = ObjInfoGraphicArticle.DefaultArticlePage;
       //     }


       //     if (ObjDefaultArticle != null)
       //     {
       //         if (ObjDefaultArticle.Reviewedby.Item != null)//Reviwer Name
       //         {
       //             frReviewedby.Item = ObjDefaultArticle.Reviewedby.Item;
       //             hlReviewdby.NavigateUrl = string.Concat("http://", Request.Url.Host.ToString(), ObjDefaultArticle.Reviewedby.Item.GetUrl());
       //         }
       //         if (ObjDefaultArticle.ReviewedDate.DateTime != null)// Reviewed date 
       //         {
       //             dtReviewdDate.Field = "Reviewed Date";
       //             dtReviewdDate.Format = "dd MMM yy";
       //         }
       //     }

            
       // }
    }
}