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
using UnderstoodDotOrg.Framework.UI;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Glossary_Article : BaseSublayout<GlossaryPageItem>
    {
        protected string CurrentAnchorName;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Model.DefaultArticlePage.Reviewedby.Item != null && Model.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                SBReviewedBy.Visible = true;
            else
                SBReviewedBy.Visible = false;

            sbSidebarPromo.Visible = Model.DefaultArticlePage.ShowPromotionalControl.Checked;

            List<string> relatedArticles = Model.GetTermAnchorList().ToList();

            relatedArticles.Sort((x, y) => string.Compare(x, y));

            rptTermCollection.DataSource = relatedArticles;
            rptTermCollection.DataBind();

            rptAlphabet.DataSource = relatedArticles;
            rptAlphabet.DataBind();
        }

        protected void rptTermCollection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                string DistinctTerm = e.Item.DataItem as string;
                if (DistinctTerm != null)
                {
                    CurrentAnchorName = DistinctTerm;
                    Repeater rptListTermbyAnchor = e.FindControlAs<Repeater>("rptListTermbyAnchor");
                    List<GlossaryTermItem> FinalRelatedArticles = GlossaryPageItem.GetRelatedTermsInfo(Model, DistinctTerm).ToList();
                    if (FinalRelatedArticles != null)
                    {
                        FinalRelatedArticles.Sort((x, y) => string.Compare(x.GlossaryTermTitle, y.GlossaryTermTitle));
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
                    //FieldRenderer frTermAnchor = e.FindControlAs<FieldRenderer>("frTermAnchor");
                    //if (frTermAnchor != null)
                    //{
                    //    frTermAnchor.Item = GTerm.InnerItem;
                    //}

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
                string DistinctTerm = e.CommandArgument.ToString();
                Response.Redirect(string.Concat(Request.Url.ToString(), "#", DistinctTerm));
                //IEnumerable<GlossaryTermItem> FinalRelatedArticles = GlossaryPageItem.GetRelatedTermsInfo(ObjGlossrayArticle, DistinctTerm);
                //if (FinalRelatedArticles != null)
                //{
                //    rptTermCollection.DataSource = FinalRelatedArticles;
                //    rptTermCollection.DataBind();
                //}
            }
        }


    }
}