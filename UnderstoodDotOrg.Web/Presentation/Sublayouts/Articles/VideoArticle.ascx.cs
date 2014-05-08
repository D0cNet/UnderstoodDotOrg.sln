using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class VideoArticle : System.Web.UI.UserControl
    {
        VideoArticlePageItem ObjVideoArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjVideoArticle = new VideoArticlePageItem(Sitecore.Context.Item);
            if (ObjVideoArticle != null)
            {
                //Get Reviewer details
                if (ObjVideoArticle.DefaultArticlePage.Reviewedby.Item != null && ObjVideoArticle.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                    SBReviewedBy.Visible = true;
                else
                    SBReviewedBy.Visible = false;

            }
        }
    }
}