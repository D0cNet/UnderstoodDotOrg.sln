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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class Promotionals_List : BaseSublayout<DefaultArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.ShowPromotionalControl)
            {
                var promoItems = Model.PromotionalContent.ListItems
                    .Where(i => i != null && i.InheritsTemplate(PromoItem.TemplateId))
                    .Take(3);

                rptPromoList.DataSource = promoItems;
                rptPromoList.DataBind();
            }
        }

        protected string GetCSSName(int Countrer)
        {
            if (Countrer == 0)
                return "purple-dark";
            if (Countrer == 1)
                return "purple-light";
            if (Countrer == 2)
                return "blue";
            else
                return "";
        }
        protected void rptPromoList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
            }
        }


    }
}