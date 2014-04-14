using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;


namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class BasicArticle : System.Web.UI.UserControl
    {
        BasicArticlePageItem ObjBasicArticle;//Craete Basic Article Object for currnet Item.
       // System.Collections.Generic.List<DefaultArticlePageItem> FinalRelatedArticles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
            if (ObjBasicArticle != null)
            {

                if (ObjBasicArticle.DefaultArticlePage.AuthorName.Item != null)
                {
                    //Show Author details
                    frAuthorName.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorBio.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.FieldName = "Author Image";
                    hlAuthorImage.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                }
                if (ObjBasicArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjBasicArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjBasicArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }

                //if (ObjBasicArticle.DefaultArticlePage.HideRelatedActiveLinks.Checked == false) // Show Articles
                //{
                //    DefaultArticlePageItem ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
                //    //Get list of selected item
                //    FinalRelatedArticles = ObjBasicArticle.GetRelatedLinks(ObjDefaultArticle);
                //    if (FinalRelatedArticles != null)
                //    {
                //        rptMoreArticle.DataSource = FinalRelatedArticles;
                //        rptMoreArticle.DataBind();
                //    }
                //}

            }
        }
        /// <summary>
        /// Function : GetRelatedItemsList(DefaultArticlePageItem)
        /// Details: For Basic Articles Type: If Articles are selected to show in "Related Links" field, show only six articles from list
        /// else select any random six articles from tree.
        /// Owner: Yugali Bharote
        /// Edited: Yugali Bharote
        /// </summary>
        /// <param name="ObjDefaultArt"></param>
        /// <returns></returns>
        //private System.Collections.Generic.IEnumerable<Item> GetRelatedItemsList(BasicArticlePageItem ObjBasicArt)
        //{
        //    System.Collections.Generic.IEnumerable<DefaultArticlePageItem> ActualRelatedLinks = null;
        //    //if (ObjBasicArt.RelatedActiveLink.Checked == false)
        //    //{
        //    if (ObjBasicArt.DefaultArticlePage.RelatedLink.ListItems.ToList().Count >= 1) // Are Articles selected? Show first six if selected
        //    {
        //        List<DefaultArticlePageItem> RelatedArticles = ObjBasicArt.GetRelatedLinks(ObjBasicArt.DefaultArticlePage);

        //        System.Collections.Generic.IEnumerable<DefaultArticlePageItem> AllRelatedLinks =(DefaultArticlePageItem) ObjBasicArt.DefaultArticlePage.RelatedLink.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
        //        ActualRelatedLinks = from art in AllRelatedLinks
        //                             where  art.InheritsTemplate(DefaultArticlePageItem.TemplateId)
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
        //            var RandomRelatedLink = context.GetQueryable<SearchResultItem>()
        //                 .Where(i =>  i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
        //            ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
        //            if (ActualRelatedLinks != null)
        //            {
        //                if (ActualRelatedLinks.Count() > 6)
        //                {
        //                    ActualRelatedLinks = ActualRelatedLinks.Take(6);
        //                }

        //            }
        //        }
        //    }
        //    //}

        //    return ActualRelatedLinks;
        //}
        protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                if (RelatedLink != null)
                {
                    DefaultArticlePageItem def = e.Item.DataItem as DefaultArticlePageItem;
                    FieldRenderer frLinkTitle = e.FindControlAs<FieldRenderer>("frLinkTitle");
                    HyperLink hlLinkTitle = e.FindControlAs<HyperLink>("hlLinkTitle");
                    if (frLinkTitle != null)
                    {
                        frLinkTitle.Item = def.ContentPage.InnerItem;
                        //frLinkTitle.Item = RelatedLink;
                        //frLinkTitle.FieldName = "Page Title";
                        hlLinkTitle.NavigateUrl = frLinkTitle.Item.Paths.ContentPath;
                    }
                    FieldRenderer frLinkImage = e.FindControlAs<FieldRenderer>("frLinkImage");
                    if (frLinkImage != null)
                    {
                        frLinkImage.Item = def.InnerItem;
                        //frLinkImage.Item = RelatedLink;
                        //frLinkImage.FieldName = "Content Thumbnail";
                    }
                }

            }


        }
    }



}
