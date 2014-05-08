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
                    sbAboutAuthor.Visible = true;
                    ////Show Author details
                    //frAuthorName.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorBio.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorImage.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorImage.FieldName = "Author Image";
                    //hlAuthorImage.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                    //hlAuthorMorePost.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Paths.FullPath;
                }
                
                //Get Reviewer Name
                if (ObjDeepDiveArticle.DefaultArticlePage.Reviewedby.Item != null && ObjDeepDiveArticle.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                    SBReviewedBy.Visible = true;
                else
                    SBReviewedBy.Visible = false;

                if (ObjDeepDiveArticle.ShowPromotionalControl.Checked == true)
                {
                    sbSidebarPromo.Visible = true;
                }
                else
                {
                    sbSidebarPromo.Visible = false;
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