using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Glossarypage;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Glossary_Article : System.Web.UI.UserControl
    {
        GlossaryPageItem ObjGlossrayArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjGlossrayArticle = new GlossaryPageItem(Sitecore.Context.Item);
            if (ObjGlossrayArticle != null)
            {

                if (ObjGlossrayArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjGlossrayArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjGlossrayArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }
                if (ObjGlossrayArticle.ShowPromotionalControl.Checked == true)
                {
                    sbSidebarPromo.Visible = true;
                }
                else
                {
                    sbSidebarPromo.Visible = false;
                }
                //Get list of selected item
                IEnumerable<string> FinalRelatedArticles = GlossaryPageItem.GetTermAnchorList(ObjGlossrayArticle);
                if (FinalRelatedArticles != null)
                {
                    rptTermCollection.DataSource = FinalRelatedArticles;
                    rptTermCollection.DataBind();
                    rptAlphabet.DataSource = FinalRelatedArticles;
                    rptAlphabet.DataBind();
                }


            }
        }

        protected void rptTermCollection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                string DistinctTerm = e.Item.DataItem as string;
                if (DistinctTerm != null)
                {
                    Repeater rptListTermbyAnchor = e.FindControlAs<Repeater>("rptListTermbyAnchor");
                    IEnumerable<GlossaryTermItem> FinalRelatedArticles = GlossaryPageItem.GetRelatedTermsInfo(ObjGlossrayArticle, DistinctTerm);
                    if (FinalRelatedArticles != null)
                    {
                        rptListTermbyAnchor.DataSource = FinalRelatedArticles;
                        rptListTermbyAnchor.DataBind();
                    }
                }
            }
        }

        protected void rptListTermbyAnchor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                GlossaryTermItem GTerm = e.Item.DataItem as GlossaryTermItem;
                if (GTerm != null)
                {
                    FieldRenderer frTermAnchor = e.FindControlAs<FieldRenderer>("frTermAnchor");
                    if (frTermAnchor != null)
                    {
                        frTermAnchor.Item = GTerm.InnerItem;
                    }

                    FieldRenderer frTermTitle = e.FindControlAs<FieldRenderer>("frTermTitle");
                    if (frTermTitle != null)
                    {
                        frTermTitle.Item = GTerm;
                    }
                    FieldRenderer frTermDefinition = e.FindControlAs<FieldRenderer>("frTermDefinition");
                    if (frTermDefinition != null)
                    {
                        frTermDefinition.Item = GTerm;
                    }

                }

            }
        }



        protected void rptAlphabet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AlphabetClick")
            {
                string DistinctTerm = e.Item.DataItem as string;
                IEnumerable<GlossaryTermItem> FinalRelatedArticles = GlossaryPageItem.GetRelatedTermsInfo(ObjGlossrayArticle, DistinctTerm);
                if (FinalRelatedArticles != null)
                {
                    rptTermCollection.DataSource = FinalRelatedArticles;
                    rptTermCollection.DataBind();
                }
            }
        }
    }
}