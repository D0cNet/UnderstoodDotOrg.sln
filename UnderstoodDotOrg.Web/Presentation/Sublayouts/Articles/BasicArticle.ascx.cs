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
        System.Collections.Generic.IEnumerable<Item> FinalRelatedArticles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
            if (ObjBasicArticle != null)
            {
                if (ObjBasicArticle.AuthorName.Item != null)
                {
                    Response.Write(ObjBasicArticle.AuthorName.Item["Author Name"]);
                    Response.Write(ObjBasicArticle.InnerItem.Language.GetDisplayName());
                    //Show Author details
                    Response.Write(ObjBasicArticle.AuthorName.Item.Language.GetDisplayName());
                    frAuthorName.Item = ObjBasicArticle.AuthorName.Item;
                    frAuthorBio.Item = ObjBasicArticle.AuthorName.Item;
                    frAuthorImage.Item = ObjBasicArticle.AuthorName.Item;
                    frAuthorImage.FieldName = "Author Image";
                    hlAuthorImage.NavigateUrl = ObjBasicArticle.AuthorName.Item.Paths.ContentPath;
                }
                if (ObjBasicArticle.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjBasicArticle.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjBasicArticle.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }

                if (ObjBasicArticle.RelatedActiveLink.Checked == false) // Show Articles
                {
                    //Get list of selected item
                    FinalRelatedArticles = GetRelatedItemsList(ObjBasicArticle);
                    if (FinalRelatedArticles != null)
                    {
                        rptMoreArticle.DataSource = FinalRelatedArticles;
                        rptMoreArticle.DataBind();
                    }
                }

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
        private System.Collections.Generic.IEnumerable<Item> GetRelatedItemsList(BasicArticlePageItem ObjBasicArt)
        {
            System.Collections.Generic.IEnumerable<Item> ActualRelatedLinks = null;
            //if (ObjBasicArt.RelatedActiveLink.Checked == false)
            //{
            if (ObjBasicArt.RelatedLink.ListItems.ToList().Count >= 1) // Are Articles selected? Show first six if selected
            {
                System.Collections.Generic.IEnumerable<Item> AllRelatedLinks = ObjBasicArt.RelatedLink.ListItems;
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
            else // Show random six articles
            {
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    var RandomRelatedLink = context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().TemplateID.ToString() == BasicArticleItem.TemplateId.ToString() || i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    if (ActualRelatedLinks != null)
                    {
                        if (ActualRelatedLinks.Count() > 6)
                        {
                            ActualRelatedLinks = ActualRelatedLinks.Take(6);
                        }

                    }
                }
            }
            //}

            return ActualRelatedLinks;
        }
        protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item RelatedLink = e.Item.DataItem as Item;
            if (RelatedLink != null)
            {
                FieldRenderer frLinkTitle = e.FindControlAs<FieldRenderer>("frLinkTitle");
                if (frLinkTitle != null)
                {
                    frLinkTitle.Item = RelatedLink;

                }
                FieldRenderer frLinkImage = e.FindControlAs<FieldRenderer>("frLinkImage");
                if (frLinkImage != null)
                {
                    frLinkImage.Item = RelatedLink;

                }
            }


        }
    }



}
