using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class DeepDiveArticle : BaseSublayout<DeepDiveArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Model.ShowKeyTakeawayContent)
            {
                divKeyTakeaways.Visible = false;
            }

            litKeyTakeAwayText.Text = DictionaryConstants.KeyTakeAwayText;
            sbAboutAuthor.Visible = Model.DefaultArticlePage.AuthorName != null;
            SBReviewedBy.Visible = Model.DefaultArticlePage.Reviewedby.Item != null && Model.DefaultArticlePage.ReviewedDate.DateTime != null;
            sbSidebarPromo.Visible = Model.DefaultArticlePage.ShowPromotionalControl.Checked;

            var finalSectionList = Model.GetSectionData();
            rptSectionList.DataSource = finalSectionList;
            rptSectionList.DataBind();

            rptSections.DataSource = finalSectionList.Take(3);
            rptSections.DataBind();
            if (finalSectionList.Count > 3)
            {
                rptExtraSections.DataSource = finalSectionList.Skip(3);
                rptExtraSections.DataBind();
            }
        }
    }
}