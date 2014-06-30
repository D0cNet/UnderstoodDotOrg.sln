using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic 
{
    public partial class ArticleListing : BaseSublayout<TopicLandingPageItem>
    {
        protected string AjaxEndpoint
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.TopicArticlesEndpoint);
            }
        }

        protected void Page_Load(object sender, EventArgs e) 
        {
            bool hasMoreResults;
            articleListing.Articles = Model.GetTopicArticles(1, out hasMoreResults);
            if (articleListing.Articles.Any())
            {
                pnlMoreArticle.Visible = hasMoreResults;
            }
        }
    }
}