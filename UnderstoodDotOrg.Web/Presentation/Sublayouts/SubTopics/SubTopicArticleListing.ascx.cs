using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics 
{
    public partial class SubTopicArticleListing : BaseSublayout<SubtopicLandingPageItem>
    {
        protected bool HasFeatured { get; set; }

        protected string AjaxEndpoint
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.SubtopicArticlesEndpoint);
            }
        }

        protected void Page_Load(object sender, EventArgs e) 
        {
            bool hasMoreResults;

            // First look for featured articles, otherwise fall back to all articles under this subtopic
            var featuredArticles = Model.GetFeaturedArticles(1, out hasMoreResults);
            HasFeatured = featuredArticles.Any();

            articleListing.Articles = HasFeatured
                ? featuredArticles
                : Model.GetArticles(1, null, out hasMoreResults);

            if (!hasMoreResults)
            {
                pnlShowMore.CssClass += " hidden";
            }
        }
    }
}