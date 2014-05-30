using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;

using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class AboutAuthor : System.Web.UI.UserControl
    {
        DefaultArticlePageItem ObjDefaultArticle;    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                ObjDefaultArticle = (DefaultArticlePageItem)Sitecore.Context.Item;

            if (ObjDefaultArticle != null)
            {
                //Show Author details
                if (ObjDefaultArticle.AuthorName.Item != null)
                {
                    frAuthorName.Item = ObjDefaultArticle.AuthorName.Item;
                    frAuthorBio.Item = ObjDefaultArticle.AuthorName.Item;
                    frAuthorImage.Item = ObjDefaultArticle.AuthorName.Item;
                    hlAuthorImage.Visible = true;
                    hlAuthorImage.NavigateUrl = ObjDefaultArticle.AuthorName.Item.Paths.ContentPath;
                    hlAuthorMorePost.Visible = true;
                    hlAuthorMorePost.NavigateUrl = ObjDefaultArticle.AuthorName.Item.Paths.FullPath;
                }
                else
                    this.Visible = false;
            }
            else
                this.Visible = false;
        }
    }
}   