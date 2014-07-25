using Sitecore.Data.Items;
using System;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class ReviewerInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = (DefaultArticlePageItem)Sitecore.Context.Item;

            bool displayReviewerInfo = false;

            if (item != null)
            {
                ReviewerBioItem reviewer = item.Reviewedby.Item;
                if (reviewer != null && !reviewer.ReviewerName.Rendered.IsNullOrEmpty())
                {
                    frReviewedBy.Item = reviewer;

                    if (item.ReviewedDate.DateTime != null
                        && item.ReviewedDate.DateTime != DateTime.MinValue)
                    {
                        uxReviewDate.Visible = true;
                    }

                    displayReviewerInfo = true;
                }
            }

            this.Visible = displayReviewerInfo;
        }
    }
}