using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class PromotionalsList : BaseSublayout<DefaultArticlePageItem>
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
    }
}