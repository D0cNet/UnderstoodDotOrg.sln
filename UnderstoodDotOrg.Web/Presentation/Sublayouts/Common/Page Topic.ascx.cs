using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Page_Topic : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // HylkByline.Visible = false;
            hlAuthorName.Visible = false;
           // For Basic ARticle , show desc as Author Bio if author have bio
            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId)
            {
                BasicArticlePageItem ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                if (ObjBasicArticle !=null)
                {
                    if (ObjBasicArticle.DefaultArticlePage.AuthorName.Item != null)
                    {
                        //frSummary.Item = ObjBasicArticle.DefaultArticlePage.AuthorName;
                        //frSummary.FieldName = "Author Name";
                        frAuthorName.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                        hlAuthorName.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.GetUrl();
                    }
                   
                }
               }
            else
            { 
                // show data of Summary field
                frSummary.Item = Sitecore.Context.Item;
                frSummary.FieldName = "Summary";
                
            }
        }
    }
}