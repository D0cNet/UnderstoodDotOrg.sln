using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;


namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class _404Page : System.Web.UI.UserControl
    {
        List<PromoItem> _promoList;
        Page404Item ObjPage404;

        protected void Page_Load(object sender, EventArgs e)
        {
            ObjPage404 = new Page404Item(Sitecore.Context.Item);
            if (ObjPage404 != null)
            {
                IEnumerable<Item> Promos = ObjPage404.PromoContent.ListItems.Where(t => t.TemplateID.ToString() == PromoItem.TemplateId);
                if (Promos != null)
                {
                    if (Promos.Count() > 3) Promos = Promos.Take(3);
                    _promoList = new List<PromoItem>(Promos.Count());
                    foreach (PromoItem p in Promos)
                    {
                        _promoList.Add(p);
                    }
                }
                if (_promoList != null)
                {
                    rptMorePromo.DataSource = _promoList;
                    rptMorePromo.DataBind();
                }
                frPageTitle.Item = frPageSummary.Item = frImage.Item = ObjPage404;


                frPromo1Title.Item = frPromo1Image.Item = ObjPage404.Promo1;
                hlPromo1.NavigateUrl = ObjPage404.Promo1.Item.Paths.FullPath;

                frPromo2Image.Item = frPromo2Title.Item = ObjPage404.Promo2;
                hlPromo2.NavigateUrl = ObjPage404.Promo2.Item.Paths.FullPath;
            }
        }

        protected void rptMorePromo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                PromoItem _curentPromo = e.Item.DataItem as PromoItem;
                if (_curentPromo != null)
                {
                    HyperLink hlPromoTitle = e.FindControlAs<HyperLink>("hlPromoTitle");
                    if (hlPromoTitle != null)
                    {
                        FieldRenderer frPromoTitle = e.FindControlAs<FieldRenderer>("frPromoTitle");
                        if (frPromoTitle != null)
                        {
                            frPromoTitle.Item = _curentPromo;
                        }
                        FieldRenderer frpromoDesc = e.FindControlAs<FieldRenderer>("frpromoDesc");
                        if (frpromoDesc != null)
                        {
                            frpromoDesc.Item = _curentPromo;
                        }
                        hlPromoTitle.NavigateUrl = _curentPromo.InnerItem.GetUrl();
                    }

                }
            }
        }
    }
}