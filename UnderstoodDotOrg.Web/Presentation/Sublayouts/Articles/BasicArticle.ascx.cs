using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;


namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class BasicArticle : BaseSublayout<BasicArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litAtAGlanceHeader.Text = DictionaryConstants.AtAGlanceText;
            litKeyTakeAwayText.Text = DictionaryConstants.KeyTakeAwayText;

            sbAboutAuthor.Visible = Model.DefaultArticlePage.AuthorName.Item != null;
            
            sbSidebarPromo.Visible = Model.DefaultArticlePage.ShowPromotionalControl.Checked;
            sbCommentsSummary.Visible = Model.DefaultArticlePage.ShowCommentTeaser.Checked;

            if (!Model.ShowAtaGlanceContent)
            {
                divAtAGlance.Visible = false;
            }
            if (!Model.ShowKeyTakeawayContent)
            {
                divKeyTakeAways.Visible = false;
            }
        }
    }
}
