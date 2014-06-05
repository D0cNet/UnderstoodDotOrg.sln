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
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class PromotionalsList : BaseSublayout<DefaultArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.ShowPromotionalControl.Checked)
            {
                var promoItems = Model.PromotionalContent.ListItems
                    .Where(i => i != null && i.InheritsTemplate(PromoItem.TemplateId))
                    .Select(i => (PromoItem)i)
                    .Where(i => i.Active)
                    .Take(3).ToList();
                var additionalPromosNeeded = 3 - promoItems.Count();
                var dtPromos = promoItems;
                if (additionalPromosNeeded > 0)
                {
                    var additionalPromoItems = MainsectionItem.GetGlobals().GetPromosFolder().GetPromoItems()
                        .OrderBy(emp => Guid.NewGuid()).Select(i => (PromoItem)i).ToList().Where(i => i.Active);
                    dtPromos = promoItems.Union(additionalPromoItems).GroupBy(i => i.ID).Select(g => g.First()).ToList();
                }

                rptPromoList.DataSource = dtPromos.Take(3);
                rptPromoList.DataBind();
            }
        }
    }
}