using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SuggestArticlePageCarousal : System.Web.UI.UserControl
    {

        DefaultArticlePageItem ObjDefaultArticle;
        AudioArticlePageItem ObjAudioArticle;
        ChecklistArticlePageItem ObjChecklistArticle;

        System.Collections.Generic.IEnumerable<Item> FinalRelatedArticles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ObjDefaultArticle = new DefaultArticlePageItem(Sitecore.Context.Item);
            if (Sitecore.Context.Item.TemplateID.ToString() == AudioArticlePageItem.TemplateId.ToString())
            {
                ObjAudioArticle = new AudioArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjAudioArticle.DefaultArticlePage;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == ChecklistArticlePageItem.TemplateId.ToString())
            {
                ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjChecklistArticle.DefaultArticlePage;
            }

            Response.Write(Sitecore.Context.Item.TemplateID.ToString());
            if (ObjDefaultArticle.HideRelatedActiveLinks.Checked == false) // Show Articles
            {
                //Get list of selected item
                FinalRelatedArticles = GetRelatedItemsList(ObjDefaultArticle);
                if (FinalRelatedArticles != null)
                {
                    rptMoreArticle.DataSource = FinalRelatedArticles;
                    rptMoreArticle.DataBind();
                }
            }
        }
        /// <summary>
        /// Function :GetRelatedItemsList(DefaultArticlePageItem)
        /// Details: If Articles are selected to show in "Related Links" field, show only six articles from list
        /// else select any random six articles from tree.
        /// Owner: Yugali Bharote
        /// Edited : Yugali Bharote
        /// </summary>
        /// <param name="ObjDefaultArt"></param>
        /// <returns></returns>
        private System.Collections.Generic.IEnumerable<Item> GetRelatedItemsList(DefaultArticlePageItem ObjDefaultArt)
        {
            System.Collections.Generic.IEnumerable<Item> ActualRelatedLinks = null;
            // if (ObjDefaultArt.HideRelatedActiveLinks.Checked == false)
            //{
            if (ObjDefaultArt.RelatedLink.ListItems.ToList().Count >= 1) // Are Articles selected? Show first six if selected
            {
                System.Collections.Generic.IEnumerable<Item> AllRelatedLinks = ObjDefaultArt.RelatedLink.ListItems;
                ActualRelatedLinks = from art in AllRelatedLinks
                                     where (art.TemplateID.ToString() == BasicArticleItem.TemplateId.ToString()) || (art.InheritsTemplate(DefaultArticlePageItem.TemplateId))
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
                    var RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().TemplateID.ToString() == BasicArticleItem.TemplateId.ToString() || i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    ActualRelatedLinks = RandomRelatedLink;
                    if (ActualRelatedLinks != null)
                    {
                        if (ActualRelatedLinks.Count() > 6)
                        {
                            ActualRelatedLinks = ActualRelatedLinks.Take(6);
                        }

                    }
                }
                // }
            }
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
