using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Glossarypage;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Infographic_Article_Page : System.Web.UI.UserControl
    {
        InfographicArticlePageItem ObjInfographArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjInfographArticle = new InfographicArticlePageItem(Sitecore.Context.Item);
            if(ObjInfographArticle!=null)
            {
                //Get Reviewer Details
                if (ObjInfographArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjInfographArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjInfographArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }
            }

        }
    }
}