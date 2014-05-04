using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
   
    public partial class AudioArticle : System.Web.UI.UserControl
    {
        AudioArticlePageItem ObjAudioArticle;
       protected void Page_Load(object sender, EventArgs e)
        {
            ObjAudioArticle = new AudioArticlePageItem(Sitecore.Context.Item);
            if (ObjAudioArticle != null)
            { 
                //Show Reviewer Details
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
