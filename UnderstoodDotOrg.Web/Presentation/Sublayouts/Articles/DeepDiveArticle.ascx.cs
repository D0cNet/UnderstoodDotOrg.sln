using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class DeepDiveArticle : System.Web.UI.UserControl
    {
        DeepDiveArticlePageItem ObjDeepDiveArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjDeepDiveArticle = new DeepDiveArticlePageItem(Sitecore.Context.Item);
            if (ObjDeepDiveArticle != null)
            {
                //Get Authors Details
                if (ObjDeepDiveArticle.DefaultArticlePage.AuthorName != null)
                {
                    frAuthorName.Item = ObjDeepDiveArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.Item = ObjDeepDiveArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorBio.Item = ObjDeepDiveArticle.DefaultArticlePage.AuthorName.Item;
                    hlAuthorImage.NavigateUrl = ObjDeepDiveArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                }
                
                //Get Reviewer Name
                if (ObjDeepDiveArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjDeepDiveArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjDeepDiveArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }

                List<DeepDiveSectionInfoPageItem> FinalSectionList = DeepDiveArticlePageItem.GetSectionData(ObjDeepDiveArticle);
                if (FinalSectionList != null)
                {
                    rptSectionPage.DataSource = FinalSectionList;
                    rptSectionPage.DataBind();

                    rptSectionList.DataSource = FinalSectionList;
                    rptSectionList.DataBind();
                }
            }
        }

        protected void rptSectionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DeepDiveSectionInfoPageItem SecItem = e.Item.DataItem as DeepDiveSectionInfoPageItem;
                if (SecItem != null)
                {
                    FieldRenderer frSectionTitle = e.FindControlAs<FieldRenderer>("frSectionTitle");
                    frSectionTitle.Item = SecItem;
                    HyperLink hlSectionTitle = e.FindControlAs<HyperLink>("hlSectionTitle");
                    hlSectionTitle.NavigateUrl = SecItem.InnerItem.Uri.Path;

                }
            }
           
        }

        protected void rptSectionPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DeepDiveSectionInfoPageItem SecItem = e.Item.DataItem as DeepDiveSectionInfoPageItem;
                if (SecItem != null)
                {
                    FieldRenderer frSectionTitle = e.FindControlAs<FieldRenderer>("frSectionTitle");
                    frSectionTitle.Item = SecItem;
                    FieldRenderer frSectionSubTitle = e.FindControlAs<FieldRenderer>("frSectionSubTitle");
                    frSectionSubTitle.Item = SecItem;
                    FieldRenderer frSectionContent = e.FindControlAs<FieldRenderer>("frSectionContent");
                    frSectionContent.Item = SecItem;

                }
            }
           
        }
    }
}