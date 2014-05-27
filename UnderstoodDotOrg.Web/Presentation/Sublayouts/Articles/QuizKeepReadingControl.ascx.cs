using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class QuizKeepReadingControl : BaseSublayout<DefaultArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var keepRadingArticles = Model.KeepReadingContent.ListItems
                .Where(i => i != null && i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                .Take(3);

            rptKeepReading.DataSource = keepRadingArticles;
            rptKeepReading.DataBind();
        }

        protected void rptKeepReading_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                if (RelatedLink != null)
                {
                    var frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    var hlPageTitle = e.FindControlAs<HyperLink>("hlPageTitle");
                    if (frPageTitle != null)
                    {
                        frPageTitle.Item = RelatedLink.ContentPage.InnerItem;
                        hlPageTitle.NavigateUrl = RelatedLink.ContentPage.InnerItem.GetUrl();
                        hlPageTitle.Visible = true;
                    }

                }

            }
        }
    }
}