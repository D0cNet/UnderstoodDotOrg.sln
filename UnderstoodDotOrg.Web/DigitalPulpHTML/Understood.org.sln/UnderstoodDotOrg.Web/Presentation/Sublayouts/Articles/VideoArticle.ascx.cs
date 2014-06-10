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
    public partial class VideoArticle : System.Web.UI.UserControl
    {
        AudioArticlePageItem ObjAudioArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAudioArticle = new AudioArticlePageItem(Sitecore.Context.Item);
            if (ObjAudioArticle != null)
            {
                //Get Reviewer details
                if (ObjAudioArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjAudioArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjAudioArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }

            }
        }
    }
}