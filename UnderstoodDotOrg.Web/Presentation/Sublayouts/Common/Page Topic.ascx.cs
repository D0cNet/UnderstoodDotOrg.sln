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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Page_Topic : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // HylkByline.Visible = false;
            hlAuthorName.Visible = false;
            // For Basic ARticle , show link to Author Bio if author have bio
            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId)
            {
                BasicArticlePageItem ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                if (ObjBasicArticle != null && ObjBasicArticle.DefaultArticlePage.AuthorName.Item != null)
                {
                    frAuthorName.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    hlAuthorName.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.GetUrl();
                    hlAuthorName.Text = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Name;
                    hlAuthorName.Visible = true;
                    frSummary.Visible = false;
                }
            }
            else
            {
                if (Sitecore.Context.Item.TemplateID.ToString() != AboutUnderstoodItem.TemplateId)
                {
                    frSummary.Item = Sitecore.Context.Item;
                    frSummary.Visible = true;
                    hlAuthorName.Visible = false;
                }
                
            }
        }
    }
}