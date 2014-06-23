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
    public partial class ReviewerInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = (DefaultArticlePageItem)Sitecore.Context.Item;

            if (item != null)
            {
				if (item.Reviewedby.Item != null 
                    && item.ReviewedDate.DateTime != null 
                    && item.ReviewedDate.DateTime != DateTime.MinValue)
				{
					frReviewedBy.Item = item.Reviewedby.Item;
					hlReviewedBy.NavigateUrl = item.Reviewedby.Item.GetUrl();

					uxReviewDate.Visible = true;
					pnlReviewBy.Visible = true;
				}
            }
        }
    }
}