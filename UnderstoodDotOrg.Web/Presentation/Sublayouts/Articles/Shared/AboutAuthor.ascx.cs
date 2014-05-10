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
       
       
       
        BasicArticlePageItem ObjBasicArticle;
        SimpleExpertArticleItem ObjSimpleExpertArticle;
        DeepDiveArticlePageItem ObjDeepDiveArticle;
        ActionStyleListPageItem ObjActionStyleArticle;
       
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.TemplateID.ToString() == BasicArticlePageItem.TemplateId.ToString())
            {
                ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjBasicArticle.DefaultArticlePage;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == SimpleExpertArticleItem.TemplateId.ToString())
            {
                ObjSimpleExpertArticle = new SimpleExpertArticleItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjSimpleExpertArticle.DefaultArticlePage;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == DeepDiveArticlePageItem.TemplateId.ToString())
            {
                ObjDeepDiveArticle = new DeepDiveArticlePageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjDeepDiveArticle.DefaultArticlePage;
            }
            if (Sitecore.Context.Item.TemplateID.ToString() == ActionStyleListPageItem.TemplateId.ToString())
            {
                ObjActionStyleArticle = new ActionStyleListPageItem(Sitecore.Context.Item);
                ObjDefaultArticle = ObjActionStyleArticle.DefaultArticlePage;
            }




            if (ObjDefaultArticle.AuthorName.Item!= null)
            {
                //Show Author details
                frAuthorName.Item = ObjDefaultArticle.AuthorName.Item;
                frAuthorBio.Item = ObjDefaultArticle.AuthorName.Item;
                frAuthorImage.Item = ObjDefaultArticle.AuthorName.Item;
                //frAuthorImage.FieldName = "Author Image";
                hlAuthorImage.NavigateUrl = ObjDefaultArticle.AuthorName.Item.Paths.ContentPath;
                hlAuthorMorePost.NavigateUrl = ObjDefaultArticle.AuthorName.Item.Paths.FullPath;
            }
        }
    }
}