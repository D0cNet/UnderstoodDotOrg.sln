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
                    rptSectionList.DataSource = FinalSectionList;
                    rptSectionList.DataBind();

                    uxSections.DataSource = FinalSectionList;
                    uxSections.DataBind();
                }
            }
        }

        protected void rptSectionList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var itemLink = e.Item.FindControl("uxItemLink") as HyperLink;
            if (itemLink != null)
            {
                itemLink.Attributes["href"] = "#item" + e.Item.DisplayIndex;
            }
        }

        protected void uxSections_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var jumpLink = e.Item.FindControl("uxJumpLink") as Literal;
            if (jumpLink != null)
            {
                jumpLink.Text = string.Format("<a name=\"item{0}\"></a>", e.Item.DisplayIndex);
            }

            var moreLink = e.Item.FindControl("uxMore") as Placeholder;
            if (moreLink != null && e.Item.DisplayIndex == 3)
            {
                moreLink.Visible = true;
            }
        }
    }
}