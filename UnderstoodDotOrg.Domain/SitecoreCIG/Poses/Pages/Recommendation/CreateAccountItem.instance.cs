using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation
{
    public partial class CreateAccountItem
    {
        //Get promo Details
        public static IEnumerable<PromoItem> GetAllPromos(CreateAccountItem ObjRecCreateAccount)
        {
            IEnumerable<PromoItem> AllPromos = ObjRecCreateAccount.AllPromosForAccountCreation;
            return AllPromos;
        }
        private IEnumerable<PromoItem> _allPromos;
        private IEnumerable<PromoItem> AllPromosForAccountCreation
        {
            get
            {
                if (_allPromos == null)
                {
                    _allPromos = this.PromoContent.ListItems
                        .Where(t => t.TemplateID.ToString() == PromoItem.TemplateId.ToString())
                        .Select(x => new PromoItem(x));
                }

                return _allPromos;
            }
        }


        //get Recommendation Article Callout Details
        public static IEnumerable<ArticleCalloutItem> GetAllArticleCallouts(CreateAccountItem ObjRecCreateAccount)
        {
            IEnumerable<ArticleCalloutItem> AllArtCalls = ObjRecCreateAccount.AllArticleCalloutsForAccountCreation;
            return AllArtCalls;
        }
        private IEnumerable<ArticleCalloutItem> _allArtCallouts;
        private IEnumerable<ArticleCalloutItem> AllArticleCalloutsForAccountCreation
        {
            get
            {
                if (_allArtCallouts == null)
                {
                    _allArtCallouts = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == ArticleCalloutItem.TemplateId.ToString())
                        .Select(x => new ArticleCalloutItem(x));
                }

                return _allArtCallouts;
            }
        }
    }
}