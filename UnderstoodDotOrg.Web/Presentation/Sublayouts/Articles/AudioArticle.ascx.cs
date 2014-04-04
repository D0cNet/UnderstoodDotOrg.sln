using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
   
    public partial class AudioArticle : System.Web.UI.UserControl
    {
        AudioArticlePageItem ObjAudioArticle;
       protected void Page_Load(object sender, EventArgs e)
        {
            ObjAudioArticle = new AudioArticlePageItem(Sitecore.Context.Item);
            if (ObjAudioArticle != null)
            { 
                //Show Reviewer Details
                if (ObjAudioArticle.DefaultArticlePage.Reviewedby.Item  != null)
                {
                    frReviewedBy.Item = ObjAudioArticle.DefaultArticlePage.Reviewedby.Item;
                    frReviewedBy.FieldName = "Reviewer name";
                    if (ObjAudioArticle.DefaultArticlePage.ReviewedDate!= null)
                    {
                        dtReviewedDate.Field = "Reviewed Date";
                        dtReviewedDate.Format = "dd MMM yy";
                    }
                }
                if (ObjAudioArticle.DefaultArticlePage.HideRelatedActiveLinks.Checked == false)
                {
                    slSuggestedArticles.Visible = true;

                    ////Get list of selected item
                    //if (GetRelatedItemsList(ObjAudioArticle) != null)
                    //{
                    //    rptMoreArticle.DataSource = GetRelatedItemsList(ObjAudioArticle);
                    //    rptMoreArticle.DataBind();
                    //}
                }

            }
            
        }
       private System.Collections.Generic.IEnumerable<Item> GetRelatedItemsList(AudioArticlePageItem  ObjArticle)
       {
           System.Collections.Generic.IEnumerable<Item> ActualRelatedLinks = null;
           if (ObjArticle.DefaultArticlePage.HideRelatedActiveLinks.Checked == false)
           {
               // check are related links selected?
               if (ObjArticle.DefaultArticlePage.RelatedLink.ListItems.ToList().Count >= 1)
               {
                   System.Collections.Generic.IEnumerable<Item> AllRelatedLinks = ObjArticle.DefaultArticlePage.RelatedLink.ListItems;
                   ActualRelatedLinks = from art in AllRelatedLinks
                                        where (art.TemplateID.ToString() == BasicArticlePageItem.TemplateId.ToString()) || (art.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                                        select art;
                   if (ActualRelatedLinks != null)
                   {
                       if (ActualRelatedLinks.Count() > 6)
                       {
                           ActualRelatedLinks = ActualRelatedLinks.Take(6);
                       }

                   }

               }
               else
               {
                   //show related links based on parent interest
                   var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                   using (var context = index.CreateSearchContext())
                   {
                       //var allIndexedContent = context.GetQueryable<SearchResultItem>().Where(i => i.GetField("Applicable Personalities"));
                       //var allIndexedContent = context.GetQueryable<SearchResultItem>().Where(i => i.GetItem()
                   }
               }
           }
          
           return ActualRelatedLinks;
       }
       protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
       {
           //Item RelatedLink = e.Item.DataItem as Item;
           //if (RelatedLink != null)
           //{
           //    FieldRenderer frLinkTitle = e.FindControlAs<FieldRenderer>("frLinkTitle");
           //    if (frLinkTitle != null)
           //    {
           //        frLinkTitle.Item = RelatedLink;

           //    }
           //    FieldRenderer frLinkImage = e.FindControlAs<FieldRenderer>("frLinkImage");
           //    if (frLinkImage != null)
           //    {
           //        frLinkImage.Item = RelatedLink;

           //    }
           //}


       }

    }
}