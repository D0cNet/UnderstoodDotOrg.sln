using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings
{
    public partial class ArticleEntry : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (DataSource != null)
            {
                DefaultArticlePageItem article = DataSource;

                frPageTitle.Item = article;
                imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(190, 107);
                hlThumbnail.NavigateUrl = hlTitle.NavigateUrl = article.GetUrl();
            }
        }
    }
}