using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;


namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class CreateAccount : System.Web.UI.UserControl
    {
        CreateAccountItem ObjAccountCreateion;
        IEnumerable<PromoItem> _allArticlePromos;
        IEnumerable<ArticleCalloutItem> _allArticleCallouts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAccountCreateion = new CreateAccountItem(Sitecore.Context.Item);
            if (ObjAccountCreateion != null)
            {
                frPageTitle.Item = frPageSummary.Item = frrecommendationHeader.Item =frImageContent.Item= ObjAccountCreateion.InnerItem;
                //Set promo Details
                _allArticlePromos = CreateAccountItem.GetAllPromos(ObjAccountCreateion);
                if (_allArticlePromos != null)
                {
                    if (_allArticlePromos.Count() > 2) _allArticlePromos = _allArticlePromos.Take(2);
                    rptPromoDetails.DataSource = _allArticlePromos;
                    rptPromoDetails.DataBind();
                }

                _allArticleCallouts = CreateAccountItem.GetAllArticleCallouts(ObjAccountCreateion);
                if (_allArticleCallouts != null)
                {
                    rptRecommendationCallouts.DataSource = _allArticleCallouts;
                    rptRecommendationCallouts.DataBind();
                }

            }
        }

        protected void rptRecommendationCallouts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ArticleCalloutItem currentCallout = e.Item.DataItem as ArticleCalloutItem;
                if (currentCallout != null)
                {
                    FieldRenderer frCalloutNumber = e.FindControlAs<FieldRenderer>("frCalloutNumber");
                    if (frCalloutNumber != null)
                    {
                        frCalloutNumber.Item = currentCallout;
                    }
                    FieldRenderer frCalloutDescription = e.FindControlAs<FieldRenderer>("frCalloutDescription");
                    if (frCalloutDescription != null)
                    {
                        frCalloutDescription.Item = currentCallout;
                    }
                }
            }
        }

        protected void rptPromoDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                PromoItem currentPromo = e.Item.DataItem as PromoItem;
                if (currentPromo != null)
                {
                    Panel pnlImageType = e.FindControlAs<Panel>("pnlImageType");
                    if (pnlImageType != null)
                    {
                        if (currentPromo.ShowMediaFile.Checked==true)
                        {
                           pnlImageType.CssClass+=" video";
                            
                        }
                        HyperLink hlPromoMedia = e.FindControlAs<HyperLink>("hlPromoMedia");
                        if (hlPromoMedia != null)
                        {
                            FieldRenderer frPromoMedia = e.FindControlAs<FieldRenderer>("frPromoMedia");
                            if (frPromoMedia != null)
                            {
                                frPromoMedia.Item = currentPromo;
                            }
                        }
                        FieldRenderer frPromoTitle = e.FindControlAs<FieldRenderer>("frPromoTitle");
                        if (frPromoTitle != null)
                        {
                            frPromoTitle.Item = currentPromo;
                        }
                    }
                }
                
            }

        }

        //Get Promo list

    }
}