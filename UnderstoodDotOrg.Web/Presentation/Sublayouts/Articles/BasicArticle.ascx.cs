using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class BasicArticle : System.Web.UI.UserControl
    {
        BasicArticlePageItem ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
        protected void Page_Load(object sender, EventArgs e)
        {

            //Show Author details
            frAuthorName.Item = ObjBasicArticle.AuthorName.Item;
            frAuthorName.FieldName = "Author Name";
            frAuthorBio.Item = ObjBasicArticle.AuthorName.Item;
            frAuthorBio.FieldName = "Author Biodata";
            //Reviwer Details
            lnkReviewedBy.Item = ObjBasicArticle.Reviewedby.Item;
            lnkReviewedBy.Field = "Revierwer Name";

            HyplnkReviewedBy.Text = lnkReviewedBy.Text;
            Sitecore.Web.UI.WebControls.FieldRenderer.Render(ObjBasicArticle.AuthorName.Item, "Reviewed Date", "format=dd MMM 'YY");

            frReviewedDate.FieldName = "Reviewed Date";
            dtReviewdDate.Field = ObjBasicArticle.ReviewedDate.DateTime.ToString();
            dtReviewdDate.Format = "dd MMM 'YY";

        }
        protected void rptMoreArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if related links are present for item , Show "Related Link" first six links only as suggestion only if "Related Active Link"  is selected .. links will only first six.
            //else select randomly any six related link having same parent category
            //checke selected links if more than six, select First six only, else make links for selected items
            if (ObjBasicArticle.RelatedActiveLink.Checked == true)
            {
                // check are related links selected?
                if (ObjBasicArticle.RelatedLink.ListItems.ToList().Count  >= 1)
                { 
                   // var ActualRelatedLinks = ObjBasicArticle.RelatedLink.ListItems.Where (i => i.Template.CreateItemFrom(
                }
                
                
               // rptMoreArticle.DataSource = ActualRelatedLinks;
                //rptMoreArticle.DataBind();

            }
            


        
        }

    }
}